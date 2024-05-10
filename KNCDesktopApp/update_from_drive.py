import os
import io
import datetime
from google.oauth2 import service_account
from googleapiclient.discovery import build
from googleapiclient.http import MediaIoBaseDownload
from googleapiclient.errors import HttpError
import time
SCOPES = ['https://www.googleapis.com/auth/drive']
SERVICE_ACCOUNT_FILE = 'serviceAccnt_secret.json'
FOLDER_ID = '1BbceTU8BJY8fnsYelKtRuIxk3RBeBW80'  # ID of the google drive folder to download

def service_account_login():
    creds = service_account.Credentials.from_service_account_file(
            SERVICE_ACCOUNT_FILE, scopes=SCOPES)
    service = build('drive', 'v3', credentials=creds)
    return service

def list_files_in_folder(service, item_id):
    query = f"'{item_id}' in parents"
    response = service.files().list(q=query, 
                                    spaces='drive', 
                                    fields='nextPageToken, files(id, name, mimeType, modifiedTime, parents)',
                                    pageToken=None).execute()
    return response.get('files', [])

def is_drive_file_newer(drive_modified_time, local_file_path):
    if not os.path.exists(local_file_path):
        return True  # If the local file does not exist, the Drive file is considered newer.
    local_modified_time = datetime.datetime.fromtimestamp(os.path.getmtime(local_file_path))
    drive_modified_time = datetime.datetime.strptime(drive_modified_time, '%Y-%m-%dT%H:%M:%S.%fZ')
    return drive_modified_time > local_modified_time

def download_file(service, file_id, file_path, drive_modified_time, local_files_set):
    if file_path in local_files_set and not is_drive_file_newer(drive_modified_time, file_path):
        print(f"File '{file_path}' is up-to-date. Skipping download.")
        local_files_set.remove(file_path)
        return local_files_set
    request = service.files().get_media(fileId=file_id)
    fh = io.BytesIO()
    downloader = MediaIoBaseDownload(fh, request)
    done = False
    try:
        while done is False:
            status, done = downloader.next_chunk()
        with open(file_path, 'wb') as f:
            fh.seek(0)
            f.write(fh.read())
        print(f"File '{file_path}' was downloaded successfully.")
    except HttpError as error:
        print(f"An error occurred: {error}")
    if file_path in local_files_set:
        local_files_set.remove(file_path)  # Remove the path from the set after downloading
    return local_files_set

def delete_local_files_not_on_drive(local_files_dict):
    for file_path in local_files_dict['files']:
        if os.path.isdir(file_path):
            os.rmdir(file_path)
            print(f"Deleted local folder not on Drive: {file_path}")
        else:
            os.remove(file_path)
            print(f"Deleted local file not on Drive: {file_path}")
    c = 0
    pathType = 'dirs'
    while local_files_dict and c < 1000:
        if local_files_dict['files']:
            pathType = 'files'
            dir_path = local_files_dict['files'].pop()
        elif local_files_dict['dirs']:
            pathType = 'dirs'
            dir_path = local_files_dict['dirs'].pop()
        else:
            break
        try:
            if os.path.isdir(dir_path):
                #remove the folder 
                os.rmdir(dir_path)
                print(f"Deleted local folder not on Drive: {dir_path}")
                c = 0
            else:
                os.remove(dir_path)
                print(f"Deleted local file not on Drive: {dir_path}")
                #remove the file from the local_files_dict
                c = 0
        except:
            #if the file or folder is not empty, add it back to the local_files_dict
            local_files_dict[pathType].add(dir_path)
            c += 1
    if c == 1000:
        print(f"Error: Could not delete local files not on Drive: {local_files_dict['dirs']}")

def download_folder(service, item_id, local_path, local_files_dict):
    #check if the path exists
    if not os.path.exists(local_path):
        os.makedirs(local_path)
    try:
        items = list_files_in_folder(service, item_id)
    except HttpError as error:
        print("Error with the google drive API. Waiting 10 seconds and attempting again")
        time.sleep(10)
        try:
            items = list_files_in_folder(service, item_id)
        except HttpError as error:
            print("Retry failed. Exiting")
            return
        
    for item in items:
        # If the item is a file, download it
        if item['mimeType'] != 'application/vnd.google-apps.folder':
            file_path = os.path.join(local_path, item['name'])
            local_files_dict['files'] = download_file(service, item['id'], file_path, item['modifiedTime'], local_files_dict['files'])
        else:
            # If the item is a folder, recursively download its contents
            if 'assets' not in item['name'] and os.path.join(local_path, item['name']) in local_files_dict['dirs']:
                local_files_dict['dirs'].remove(os.path.join(local_path, item['name']))
            new_local_path = os.path.join(local_path, item['name'])
            local_files_dict = download_folder(service, item['id'], new_local_path, local_files_dict)
    return local_files_dict

def get_all_local_files(local_download_path, local_files_dict):
    for root, dirs, files in os.walk(local_download_path):
        for file in files:
            local_files_dict['files'].add(os.path.join(root, file))
        for dir in dirs:
            local_files_dict = get_all_local_files(os.path.join(root, dir), local_files_dict)
            local_files_dict['dirs'].add(os.path.join(root, dir))
    return local_files_dict

def main():
    local_download_path = './assets'  # Local path to download the folder
    print(f"Syncing files with Google Drive...")
    service = service_account_login()
    local_files_dict = {}
    local_files_dict['files'] = set()
    local_files_dict['dirs'] = set()
    print(f"Gathering files from {local_download_path}...")
    local_files_dict = get_all_local_files(local_download_path, local_files_dict)
    print(f"Downloading files from Google Drive...")
    local_files_dict = download_folder(service, FOLDER_ID, local_download_path, local_files_dict)
    print(f"Deleting local files not on Google Drive...")
    delete_local_files_not_on_drive(local_files_dict)

if __name__ == "__main__":
    main()
