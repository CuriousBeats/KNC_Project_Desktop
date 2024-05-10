import os
import sys

import io
import datetime
from google.oauth2 import service_account
from googleapiclient.discovery import build
from googleapiclient.http import MediaIoBaseDownload, MediaFileUpload
from googleapiclient.errors import HttpError
from update_from_drive import is_drive_file_newer, list_files_in_folder, service_account_login, FOLDER_ID

def get_local_file_path(file):

    if os.path.exists(file):
        return file
    else:
        prependList = ["assets/","KNCDesktopApp/", "KNCDesktopApp/assets/"]
        for prepend in prependList:
            if os.path.exists(prepend+file):
                return prepend+file
    return False

def get_drive_file_id(file, service, item_id):
    #check the drive for a file with the name of file
    #if folder_id is specified, check only in that folder
    #if the file is found, return the file id
    #otherwise, return False
    file_list = list_files_in_folder(service,item_id)
    file = file.split("/")
    if file[0] == "assets":
        file = file[1:]
    for f in file_list:
        if f['name'] == file[0]:
            #if it's the file we're looking for, return the id
            if len(file) == 1:
                return f['id'], item_id
            #if it's a folder (and not the target), check the contents of the folder
            else:
                file = file[1:]
                #join the remaining parts of the file name
                file = "/".join(file)
                return get_drive_file_id(file, service, f['id'])
    return False, item_id

def upload_file(file, service, parent_folder=FOLDER_ID):
    #upload the file or folder to the drive
    #if it is a folder, upload all contents of the folder
    #if it is a file, make sure it is in its correct location
    #return the file id
    if os.path.isdir(file):
        file_metadata = {
            'name': os.path.basename(file),
            'mimeType': 'application/vnd.google-apps.folder',
            'parents': [parent_folder]
        }
        try:
            #create a folder inside FOLDER_ID
            folder = service.files().create(body=file_metadata).execute()
            parent_folder = folder['id']
        except HttpError as error:
            print("An error occurred while uploading the folder.")
            return False
        try:
            for dir in os.listdir(file):
                upload_file(os.path.join(file, dir), service, parent_folder)
        except FileNotFoundError as error:
            print("Could not find any files in the folder. If the folder is empty, this is expected.")
    else:
        file_metadata = {
            'name': os.path.basename(file),
            'parents': [parent_folder]
        }
        media = MediaFileUpload(file)
        service.files().create(body=file_metadata, media_body=media).execute()

def delete_file(file_id, service):
    #delete the file or folder with the id file_id
    #if it is a folder, delete all contents of the folder
    #if it is a file, delete it
    #return True if the file was deleted, False otherwise
    try:
        #check if the file is a folder
        file = service.files().get(fileId=file_id).execute()
        if file['mimeType'] == 'application/vnd.google-apps.folder':
            #delete all contents of the folder
            file_list = list_files_in_folder(service,file_id)
            for f in file_list:
                delete_file(f['id'], service)
            service.files().delete(fileId=file_id).execute()
        else:
            service.files().delete(fileId=file_id).execute()
        return True
    except HttpError as error:
        print(f"An error occurred: {error}")
        return False

def rename_file(file_id, new_name, service):
    #rename the file or folder with the id file_id to new_name
    #return True if the file was renamed, False otherwise
    file_metadata = {
        'name': new_name
    }
    try:
        service.files().update(fileId=file_id, body=file_metadata).execute()
        return True
    except HttpError as error:
        print(f"An error occurred: {error}")
        return False

    print(f"An unknown error occurred while renaming the file: {file_id} to {new_name}")
    return False

def delete_action(file, service):
    #check the drive for the file
    #if it exists, delete it
    #otherwise, return an error
    file_id,parent_folder = get_drive_file_id(file, service, FOLDER_ID)
    if file_id:
        return delete_file(file_id, service)
    else:
        raise FileNotFoundError(f"Deletion failed: file not found on drive: {file}")

def create_action(file, service):
    #check the local directory for the file
    #check the drive for the file
    # if the file does not exist on the drive, upload it
    # if the file does not exist locally, return an error
    local_file = get_local_file_path(file)
    if local_file:
        drive_file_id, parent_folder = get_drive_file_id(file, service,FOLDER_ID)
        if drive_file_id:
            print(f"File already exists on drive: {file}")
            return False
        else:
            upload_file(local_file, service, parent_folder)
    else:
        raise FileNotFoundError(f"File not found: {file}")

def rename_action(dir, oldDir, service):
    #check that a file with the name of dir exists locally
    #check that a file with the name of oldDir exists on the drive
    #if both exist, rename the drive file to dir
    #otherwise, return an error
    drive_file_id,parent_folder = get_drive_file_id(oldDir, service,FOLDER_ID)
    if drive_file_id:
        return rename_file(drive_file_id, dir, service)
    else:
        raise FileNotFoundError(f"File not found on drive: {oldDir}")

def update_action(dir, service):
    #check the local directory for the file
    #check the drive for the file
    #if the file exists locally but not on the drive, upload it
    #if the file exists on the drive but not locally, delete it
    #if the file exists on both, update the contents of the drive file to match the local file
    local_file = get_local_file_path(dir)
    drive_file_id,parent_folder = get_drive_file_id(dir, service, FOLDER_ID)
    if local_file:
        if drive_file_id:
            #check each file on the drive in the folder. Delete any files not in the local folder,
            #upload any files not on the drive, and update any files that are on both where the local file is newer
            if os.path.isdir(local_file):
                drive_files = list_files_in_folder(service, drive_file_id)
                for f in drive_files:
                    if f['name'] not in os.listdir(local_file):
                        delete_file(f['id'], service)
                    else:
                        local_file_path = os.path.join(local_file, f['name'])
                        if not is_drive_file_newer(f['modifiedTime'], local_file_path):
                            parent_folder = f['parents'][0]
                            upload_file(local_file_path, service, parent_folder)
            upload_file(local_file, service, drive_file_id)
        else:
            upload_file(local_file, service, parent_folder)
    else:
        if drive_file_id:
            delete_file(drive_file_id, service)
        else:
            raise FileNotFoundError(f"File not found: {dir}")

def validate_action(actionType):
    actionDict = {0:"update",1:"delete",2:"create",3:"rename"}
    if isinstance(actionType,int):
        if actionType in range(0,4):
            actionType = actionDict[actionType]
        else:
            print("Error: actionType out of range. Options: 0/update, 1/delete, 2/create, 3/rename")
            raise ValueError("Invalid actionType")
    elif not isinstance(actionType,str):
        print("Error: actionType must be a string or integer")
        raise ValueError("Invalid actionType")
    elif actionType.lower() not in actionDict.values():
        print("Error: actionType must be one of the following: update, delete, create, rename")
        raise ValueError("Invalid actionType")
    return actionType.lower()

def main(dir, actionType = 0, oldDir = None):
    #for the kinds of actions that can be called to this function, given the directory passed.
    # update - generally update the folder contents and modify anything on the drive that is needed, including
    #   deleting or creating files or the folder itself. The code infers what to do
    # delete - check that the folder specified no longer exists, and delete it on the drive
    # create - check that the folder specified does not exist on the drive, and upload it and its contents
    # rename - find the directory on the drive by the name of oldDir, and rename it to dir
    # actionType can be a string or integer, and is case-insensitive
    actionType = validate_action(actionType)
    service = service_account_login()

    if actionType == "update":
        update_action(dir, service)
        print(f"Updated {dir} on the drive.")
    elif actionType == "delete":
        delete_action(dir, service)
        print(f"Deleted {dir} from the drive.")
    elif actionType == "create":
        create_action(dir, service)
        print(f"Uploaded to the drive.")
    elif actionType == "rename":
        rename_action(dir, oldDir, service)
        print(f"Renamed {oldDir} to {dir} on the drive.")

    return f"Successefully {actionType}d {dir} on the drive."

    
if __name__ == "__main__":
    #take input from command line args
    # args = sys.argv
    args = sys.argv
    if len(args) == 2:
        main(args[1])
    elif len(args) == 3:
        main(args[1], args[2])
    elif len(args) == 4:
        main(args[1], args[2], args[3])
    else:
        print("Error: invalid number of arguments. Usage: python update_drive.py <directory> <actionType> <oldDir>")
        sys.exit(1)
