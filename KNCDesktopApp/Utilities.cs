using SkiaSharp;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Diagnostics;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace KNCDesktopApp
{
    public static class Utilities
    {
        private static int resizeValue = 450;
        private static int resizePdf = 200;
        public static Bitmap ResizeImage(Image originalImage, int canvasWidth, int canvasHeight)
        {
            var canvas = new Bitmap(canvasWidth, canvasHeight);
            using (var graphics = Graphics.FromImage(canvas))
            {
                graphics.Clear(Color.Transparent); // Set background color

                // Calculate the scaled image dimensions
                float scaleFactor = Math.Min((float)canvasWidth / originalImage.Width, (float)canvasHeight / originalImage.Height);
                int scaledWidth = (int)(originalImage.Width * scaleFactor);
                int scaledHeight = (int)(originalImage.Height * scaleFactor);

                // Calculate top-left corner to center the image
                int offsetX = (canvasWidth - scaledWidth) / 2;
                int offsetY = (canvasHeight - scaledHeight) / 2;

                // Draw the image centered
                graphics.DrawImage(originalImage, offsetX, offsetY, scaledWidth, scaledHeight);
            }

            return canvas;
        }

        public static Bitmap RenderPdfPageToImage(string pdfFilePath, int page = 0)
        {
            using (FileStream pdfStream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.Read))
            {
                // Call the ToImage method without RenderOptions, assuming the simplified version matches your library
                SKBitmap image = PDFtoImage.Conversion.ToImage(pdfStream, false, null, page);
                // convert the SKBitmap to a normal Bitmap so that it is easy to display and work with
                return Extensions.ToBitmap(image);
            }
        }

        public static List<Bitmap> RenderPdfToImages(string pdfFilePath, int page = 0)
        {
            List<Bitmap> pagesAsImages = new List<Bitmap>();
            using (FileStream pdfStream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.Read))
            {
                IEnumerable<SKBitmap> images = PDFtoImage.Conversion.ToImages(pdfStream, leaveOpen: false, dpi: 300);
                foreach (var picture in images)
                {
                    pagesAsImages.Add(Extensions.ToBitmap(picture));
                }

            }
            return pagesAsImages; 
        }


        // pass in folder path containing images, as well as a array of image names. return the ImageElement list of the ImageElements in the same order as the array of image names
        public static List<ImageElement> AddImagesToArray(List<String> images, string folderPath)
        {
            List<ImageElement> imageArray = new List<ImageElement>();
            Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();

            var files = Directory.GetFiles(folderPath);
            int count = 0;
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string extension = Path.GetExtension(file).ToLower(); // Ensure extension comparison is case-insensitive
                Bitmap bitmap = null;

                if (extension == ".pdf")
                {
                    // Handle PDF rendering to bitmap
                    bitmap = RenderPdfPageToImage(file); // Assuming RenderPdfPageToImage does not lock the file
                }
                else if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                {
                    // Load the image in a way that does not lock the file
                    using (var tempImage = Image.FromFile(file))
                    {
                        bitmap = new Bitmap(tempImage);
                    }
                }

                if (bitmap != null)
                {
                    //Debug.WriteLine($"Resizing image {file}");
                    Bitmap resizedBitmap = ResizeImage(bitmap, resizeValue, resizeValue); // Ensure this doesn't lock the file either

                    ImageElement imageElement = new ImageElement(fileName, resizedBitmap, count, file, false);
                    pictureDictionary[fileName] = imageElement;
                    count++;
                }
            }

            // Reorder images based on the input list
            count = 0;
            foreach (string imageName in images)
            {
                if (pictureDictionary.TryGetValue(imageName, out ImageElement foundImage))
                {
                    foundImage.Index = count;
                    imageArray.Add(foundImage);
                    count++;
                }
            }

            return imageArray;
        }

        public static List<ImageElement> AddPdfsToArray(List<String> pdfList, string folderPath, BackgroundWorker worker)
        {
            int totalImages = pdfList.Count;
            List<ImageElement> imageArray = new List<ImageElement>();

            if (pdfList.Count > 0)
            {
                Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();

                var files = Directory.GetFiles(folderPath);
                int count = 0;
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string extension = Path.GetExtension(file).ToLower(); // Ensure extension comparison is case-insensitive
                    List<Bitmap> bitmaps = new List<Bitmap>();

                    if (fileName == pdfList[0])
                    {

                        if (extension == ".pdf")
                        {
                            // Handle PDF rendering to bitmap
                            bitmaps = RenderPdfToImages(file); // Assuming RenderPdfPageToImage does not lock the file
                        }

                        if (bitmaps != null)
                        {
                            for (int i = 0; i < bitmaps.Count; i++)
                            {
                                Debug.WriteLine($"Resizing image {file}");
                                Bitmap resizedBitmap = ResizeImage(bitmaps[i], resizePdf, resizePdf); // Ensure this doesn't lock the file either
                                ImageElement imageElement = new ImageElement(fileName, resizedBitmap, count, file, false);
                                imageArray.Add(imageElement);
                                // Calculate and report progress

                                int progressPercentage = (int)((double)i / bitmaps.Count * 100);
                                Debug.WriteLine($"Reporting {progressPercentage}%");
                                worker.ReportProgress(progressPercentage);
                            }
                        }
                    }
                }
            }

            // catch case. will return an empty array if no items in pdflist
            return imageArray;
        }


        public static void AddItemsToDataGrid(List<ImageElement> imageArray, DataGridView dataGridView, String column1, String column2, String column3)
        {
            dataGridView.Rows.Clear();
            if (imageArray.Count > 4)
            {
                dataGridView.Size = new Size(495, 664);
            }
            else
            {
                dataGridView.Size = new Size(473, 664);
            }
            for (int i = 0; i < imageArray.Count; i++)
            {
                int rowIndex = dataGridView.Rows.Add();
                // Set the image in the "testimagepreview" column

                dataGridView.Rows[rowIndex].Height = resizePdf;
                dataGridView.Rows[rowIndex].Cells[column1].Value = imageArray[i].Image;

                // Set the filename in the "testfilename" column
                dataGridView.Rows[rowIndex].Cells[column2].Value = $"Page {i}";

                // Set the text for the button in the "testremovebutton" column
                //dataGridView.Rows[rowIndex].Cells[column3].Value = "Delete";
                //dataGridView.Rows[rowIndex].Cells[column3].Style.Padding = new Padding(0, 0, 0, 0);
            }

            dataGridView.ClearSelection();
        }


        public static List<ImageElement> LoadInNewImages(int indexToAdd, List<ImageElement> currentImages)
        {
            List<ImageElement> imageArray = new List<ImageElement>();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                Filter = "Image files (*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png",
                Multiselect = false  // Allow selection of multiple files
            };

            int count = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    try
                    {
                        // Load the image in a way that does not lock the file
                        Bitmap resizedBitmap;
                        using (var tempImage = Image.FromFile(fileName))
                        {
                            resizedBitmap = ResizeImage(new Bitmap(tempImage), resizeValue, resizeValue); // Assuming ResizeImage returns a new Bitmap instance
                        } // tempImage gets disposed here, releasing the lock on the file

                        string name = Path.GetFileName(fileName);
                        string path = fileName;
                        bool isNew = true; // Since these are new images, assuming isNew should be true

                        ImageElement newElement = new ImageElement(name, resizedBitmap, (indexToAdd + count), path, isNew);
                        imageArray.Add(newElement);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                    count++;
                }

                return imageArray;
            }
            else
            {
                imageArray.AddRange(currentImages);
                return imageArray;
            }
            
        }

        public static List<ImageElement> LoadInNewPDFs(int indexToAdd, List<ImageElement> currentImages)
        {
            List<ImageElement> imageArray = new List<ImageElement>();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                Filter = "PDF Files (*.pdf)|*.pdf",
                Multiselect = false // Allow selection of multiple files
            };

            int count = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    try
                    {
                        List<Bitmap> images = RenderPdfToImages(fileName); // Make sure this function doesn't lock the file
                        for (int i = 0; i < images.Count; i++)
                        {
                            Bitmap resizedBitmap = ResizeImage(images[i], resizePdf, resizePdf);
                            string name = Path.GetFileName(fileName);
                            string path = fileName;
                            bool isNew = true; // Since these are being loaded anew

                            ImageElement newElement = new ImageElement(name, resizedBitmap, (indexToAdd + count), path, isNew);
                            imageArray.Add(newElement);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading PDF: {ex.Message}");
                    }
                    count++;
                }
                return imageArray;
            }
            else return currentImages;
        }


        public static void DeleteUnreferencedImages(string folderPath, List<Announcement> announcementsList)
        {

            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            // Step 2 & 3: Iterate through announcements and their images, remove found entries from the dictionary
            foreach (var announcement in announcementsList)
            {
                foreach (var imageName in announcement.Images)
                {
                    fileDict.Remove(imageName); // Remove the file name if it exists, does nothing if it doesn't exist
                }
            }

            // Step 4: Delete any remaining files that were not referenced by the announcements
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                Debug.WriteLine($"Deleting unreferenced file: {fullPath}\n{remainingFile}");
                // delete file from drive
                RunPythonScript("update_drive.py", $"assets/announcements/images/{remainingFile}", "delete");               
                Debug.WriteLine("File Deleted from drive and now being deleted from local");
                File.Delete(fullPath); // Delete the file from the directory
            }
        }

        public static void DeleteUnreferencedImages(string folderPath, List<Event> eventsList)
        {
            Debug.WriteLine($"Attempting to delete the unreferenced images in {folderPath}");
            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            // Step 2 & 3: Iterate through announcements and their images, remove found entries from the dictionary
            foreach (var eventData in eventsList)
            {
                Debug.WriteLine($"{eventData.Title}    {eventData.Images[0]}");

                foreach (var imageName in eventData.Images)
                {
                    fileDict.Remove(imageName); // Remove the file name if it exists, does nothing if it doesn't exist
                }
            }

            // Step 4: Delete any remaining files that were not referenced by the announcements
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                Debug.WriteLine($"Deleting unreferenced file: {fullPath}\n{remainingFile}");

                // delete file from drive
                RunPythonScript("update_drive.py", $"assets/events/images/{remainingFile}", "delete");
                
                Debug.WriteLine("File Deleted from drive and now being deleted from local");
                File.Delete(fullPath); // Delete the file from the directory
            }
        }

        public static void DeleteUnreferencedImages(string folderPath, List<Trail> trailsList)
        {
            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            // Step 2 & 3: Iterate through announcements and their images, remove found entries from the dictionary
            foreach (var eventData in trailsList)
            {
                foreach (var imageName in eventData.Images)
                {
                    fileDict.Remove(imageName); // Remove the file name if it exists, does nothing if it doesn't exist
                }
            }

            // Step 4: Delete any remaining files that were not referenced by the announcements
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                //Debug.WriteLine($"Deleting unreferenced file: {fullPath}");

                Debug.WriteLine($"Deleting unreferenced file: {fullPath}\n{remainingFile}\nRunning: python update_drive.py assets/trails/images/{remainingFile} delete");

                // delete file from drive
                RunPythonScript("update_drive.py", $"assets/trails/images/{remainingFile}", "delete");

                Debug.WriteLine("File Deleted from drive and now being deleted from local");

                File.Delete(fullPath); // Delete the file from the directory
            }
        }

        public static void DeleteUnreferencedImages(string folderPath, List<TrailStop> trailStopsList)
        {
            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            // Step 2 & 3: Iterate through announcements and their images, remove found entries from the dictionary
            foreach (var currentStop in trailStopsList)
            {
                foreach (var imageName in currentStop.Images)
                {
                    fileDict.Remove(imageName); // Remove the file name if it exists, does nothing if it doesn't exist
                }
            }

            // Step 4: Delete any remaining files that were not referenced by the announcements
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                Debug.WriteLine($"Deleting unreferenced file: {fullPath}");

                //Debug.WriteLine($"FULL PATH = {fullPath}");
                string shortHand = TrimPathFromFolder(fullPath, "assets");
                //Debug.WriteLine($"TRIMMED PATH = {shortHand}");

                // delete file from google drive
                Debug.WriteLine($"deleting file {shortHand} from drive");

                Debug.WriteLine($"calling python update_drive.py {shortHand} delete");
                RunPythonScript("update_drive.py", shortHand, "delete");
                // copy file from destination path to the image to the google drive.
                Debug.WriteLine("File is now being deleted locally");
                File.Delete(fullPath); // Delete the file from the directory
            }
        }


        public static void DeleteUnreferencedAudio(string folderPath, List<TrailStop> trailStopsList)
        {
            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            // Step 2 & 3: Iterate through announcements and their images, remove found entries from the dictionary
            foreach (var currentStop in trailStopsList)
            {
                fileDict.Remove(currentStop.Audio); // remove the audio file for each stop from the dictionary
            }

            // Step 4: Delete any remaining files that were not referenced by the announcements
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                Debug.WriteLine($"Deleting unreferenced file: {fullPath}");
                string shortHand = TrimPathFromFolder(fullPath, "assets");
                RunPythonScript("update_drive.py", shortHand, "delete");
                // delete from google drive
                File.Delete(fullPath); // Delete the file from the directory
            }
        }

        public static void DeleteUnreferencedPdfs(string folderPath, List<Exhibit> exhibits)
        {
            // Ensure the directory exists
            if (!Directory.Exists(folderPath)) return;

            // Step 1: Create a dictionary of all files in the folderPath
            var fileDict = new Dictionary<string, bool>();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                Debug.WriteLine($"adding {file} to dictionary");
                fileDict[Path.GetFileName(file)] = true; // Use file name as key
            }

            foreach(var currentEx in exhibits)
            {
                foreach (var imageName in currentEx.Pdfs)
                {
                    fileDict.Remove(imageName); // Remove the file name if it exists, does nothing if it doesn't exist
                }
            }
            


            // Step 4: Delete any remaining files that were not referenced by the exhibit
            foreach (var remainingFile in fileDict.Keys)
            {
                string fullPath = Path.Combine(folderPath, remainingFile);
                Debug.WriteLine($"Deleting unreferenced file: {fullPath}");
                RunPythonScript("update_drive.py", $"assets/exhibits/pdfs/{remainingFile}", "delete");

                File.Delete(fullPath); // Delete the file from the directory
            }
        }

        public static void WriteAnnouncementsToJson(string jsonPath, List<Announcement> announcementsList)
        {
            var announcementsToWrite = new List<object>();

            for (int i = 0; i < announcementsList.Count; i++)
            {
                var announcement = announcementsList[i];
                var announcementData = new
                {
                    id = i,
                    title = announcement.Title,
                    subtitle1 = announcement.Subtitle1,
                    subtitle2 = announcement.Subtitle2,
                    description = announcement.Description,
                    images = announcement.Images
                };

                announcementsToWrite.Add(announcementData);
            }

            var wrapper = new { announcements = announcementsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            Debug.WriteLine("Announcements should be saved to json file");

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            Debug.WriteLine("Deleting the announcements.json file in the drive");

            RunPythonScript("update_drive.py", "assets/announcements/announcements.json", "delete");
            Debug.WriteLine("Creating the announcements.json file in the drive");

            RunPythonScript("update_drive.py", "assets/announcements/announcements.json", "create");


        }

        public static void WriteEventsToJson(string jsonPath, List<Event> eventsList)
        {
            var eventsToWrite = new List<object>();
            int count = 0;
            foreach (var eventItem in eventsList)
            {
                var eventData = new
                {
                    id = count,
                    title = eventItem.Title,
                    day = eventItem.Day,
                    month = eventItem.Month,
                    year = eventItem.Year,
                    startTime = eventItem.StartTime,
                    endTime = eventItem.EndTime,
                    location = eventItem.Location,
                    images = eventItem.Images
                };

                eventsToWrite.Add(eventData);
                count++;
            }

            var wrapper = new { events = eventsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            // sync to google drive. since its a json file, we need to delete, and then reupload

            Debug.WriteLine("Deleting the events.json file in the drive");

            RunPythonScript("update_drive.py", "assets/events/events.json", "delete");
            Debug.WriteLine("Creating the events.json file in the drive");

            RunPythonScript("update_drive.py", "assets/events/events.json", "create");


        }

        public static List<string> ProcessImageElements(string folderPath, List<ImageElement> imageElements)
        {
            // Ensure the folder exists
            Directory.CreateDirectory(folderPath); // This will create the directory if it does not exist and do nothing if it does
            
            var processedImages = new List<string>();

            foreach (var imageElement in imageElements)
            {
                string destinationPath = Path.Combine(folderPath, imageElement.Name);
                Debug.WriteLine(destinationPath);
                // Check if the file already exists in the folder
                if (!File.Exists(destinationPath))
                {
                    // If the file does not exist, copy it from the ImageElement.Path to the folder
                    File.Copy(imageElement.Path, destinationPath);
                    string shortHand = TrimPathFromFolder(destinationPath, "assets");

                    // add file to google drive
                    Debug.WriteLine($"running python script: update_drive.py {shortHand} create");
                    RunPythonScript("update_drive.py", shortHand, "create");
                    // copy file from destination path to the image to the google drive.
                    Debug.WriteLine($"adding file {imageElement.Name} to {shortHand}");
                }

                // Add the image name to the list
                processedImages.Add(imageElement.Name);
            }

            return processedImages;
        }

        public static string ProcessAudioFile(string folderPath, AudioFile audioFile)
        {

            if (audioFile == null)
            {
                return "";
            }

            string audioFilePath = audioFile.Path;


            Directory.CreateDirectory(folderPath);
            string audioFileName = Path.GetFileName(audioFilePath);
            string destinationPath = Path.Combine(folderPath, audioFileName);

            Debug.WriteLine($"moving file {audioFilePath} to {destinationPath}");
            if (File.Exists(audioFilePath)) 
            {
                File.Copy(audioFilePath, destinationPath);
                string shortHand = TrimPathFromFolder(destinationPath, "assets");
                Debug.WriteLine($"running python script: update_drive.py {shortHand} create");
                RunPythonScript("update_drive.py", shortHand, "create");
                Debug.WriteLine($"adding file {audioFileName} to {shortHand}");
            }
            return audioFileName;
        }


        public static string TrimPathFromFolder(string fullPath, string folderName)
        {
            // Normalize the path to use forward slashes
            string normalizedPath = fullPath.Replace('\\', '/');

            // Use forward slash as the directory separator in the search pattern
            string searchPattern = folderName + "/";

            // Find the index of the folder in the path
            int folderIndex = normalizedPath.IndexOf(searchPattern, StringComparison.OrdinalIgnoreCase);

            if (folderIndex == -1)
            {
                throw new ArgumentException($"The path does not contain the folder '{folderName}'.");
            }

            // Return the substring from the folder name onward
            return normalizedPath.Substring(folderIndex);
        }

        public static List<string> ProcessImageElementsForPdf(string folderPath, List<ImageElement> imageElements)
        {
            // Ensure the folder exists
            Directory.CreateDirectory(folderPath); // This will create the directory if it does not exist and do nothing if it does

            var processedImages = new List<string>();

            // make sure the array is not empty
            if (imageElements.Count > 0)
            {
                var imageElement = imageElements[0];
                string destinationPath = Path.Combine(folderPath, imageElement.Name);

                // Check if the file already exists in the folder
                if (!File.Exists(destinationPath))
                {
                    // If the file does not exist, copy it from the ImageElement.Path to the folder
                    File.Copy(imageElement.Path, destinationPath);

                    string shortHand = TrimPathFromFolder(destinationPath, "assets");

                    // add file to google drive
                    Debug.WriteLine($"writing file {shortHand} to drive");
                    RunPythonScriptAsync("update_drive.py", shortHand, "create");
                    Debug.WriteLine($"adding file {imageElement.Name} to {folderPath}");
                }

                // Add the image name to the list
                processedImages.Add(imageElement.Name);
            }

            return processedImages;
        }

        public static void WriteExhibitsToJson(string jsonPath, List<Exhibit> exhibitsList)
        {
            var exhibitsToWrite = new List<object>();

            for (int i = 0; i<exhibitsList.Count; i++)
            {
                var exhibit = exhibitsList[i];
                var exhibitData = new
                {
                    id = i,
                    isCurrent = exhibit.IsCurrent,
                    title = exhibit.Title,
                    dateCreated = exhibit.DateCreated,
                    designer = exhibit.Designer,
                    pdfs = exhibit.Pdfs
                };
                Debug.WriteLine($"writing exhibit {exhibit.Title} to json");
                foreach (var element in exhibit.Pdfs)
                {
                    Debug.WriteLine(element);

                }
                exhibitsToWrite.Add(exhibitData);
            }

            var wrapper = new { exhibits = exhibitsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            // sync to google drive. since its a json file, we need to delete, and then reupload

            Debug.WriteLine("Deleting the exhibits.json file in the drive");

            RunPythonScript("update_drive.py", "assets/exhibits/exhibits.json", "delete");
            Debug.WriteLine("Creating the exhibits.json file in the drive");

            RunPythonScript("update_drive.py", "assets/exhibits/exhibits.json", "create");
        }
/*
        public static void RenameExhibitFolders(string parentDirectoryPath, List<Exhibit> exhibitsList)
        {
            // in this function, i is the index of the exhibit list. We want the new id to be equivalent to the 

            // Phase 1: Rename folders to temporary names
            for (int i = 0; i < exhibitsList.Count; i++)
            {
                var exhibit = exhibitsList[i];
                string originalFolderPath = Path.Combine(parentDirectoryPath, $"Exhibit{exhibit.Id}");
                string tempFolderPath = Path.Combine(parentDirectoryPath, $"Temp{i}");

                if (Directory.Exists(originalFolderPath))
                {
                    Directory.Move(originalFolderPath, tempFolderPath);
                }
            }

            Thread.Sleep(2000);

            // Get all temporary folders
            var tempFolders = Directory.GetDirectories(parentDirectoryPath, "Temp*");

            // Phase 2: Rename temporary folders back to the 'Exhibit{index}'
            foreach (var tempFolder in tempFolders)
            {
                string indexStr = tempFolder.Split(new[] { "Temp" }, StringSplitOptions.None).Last();
                string finalFolderPath = Path.Combine(parentDirectoryPath, $"Exhibit{indexStr}");

                if (Directory.Exists(tempFolder))
                {
                    Directory.Move(tempFolder, finalFolderPath);
                }
            }
        }*/

        public static void WriteTrailsToJson(string jsonPath, List<Trail> trailsList)
        {
            var trailsToWrite = new List<object>();

            for (int i = 0; i < trailsList.Count;i++)
            {
                var trail = trailsList[i];
                var trailData = new
                {
                    id = i,
                    name = trail.Name,
                    address = trail.Address,
                    length = trail.Length,
                    is_loop = trail.Is_Loop,
                    difficulty = trail.Difficulty,
                    description = trail.Description,
                    images = trail.Images
                };

                trailsToWrite.Add(trailData);
            }

            var wrapper = new { trails = trailsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            // sync to google drive. since its a json file, we need to delete, and then reupload

            Debug.WriteLine("Deleting the trails.json file in the drive");

            RunPythonScript("update_drive.py", "assets/trails/trails.json", "delete");
            Debug.WriteLine("Creating the trails.json file in the drive");

            RunPythonScript("update_drive.py", "assets/trails/trails.json", "create");



        }

        public static void RenameTrailFoldersNoPython(string parentDirectoryPath, List<Trail> trailsList)
        {
            // trailslist should be in order now, so the index of a trail will now represent its new ID. 
            // we will rename each trail{id} folder to temp{index} which is going to be its new id.  


            // Phase 1: Rename folders to temporary names
            for (int i = 0; i < trailsList.Count; i++)
            {
                var trail = trailsList[i];
                Debug.WriteLine($"TrailID = {trail.Id}");
                string originalFolderPath = Path.Combine(parentDirectoryPath, $"trail{trail.Id}");
                string tempFolderPath = Path.Combine(parentDirectoryPath, $"Temp{i}");

                if (Directory.Exists(originalFolderPath))
                {
                    //Directory.Move(originalFolderPath, tempFolderPath);
                    string shorthand = TrimPathFromFolder(originalFolderPath, "assets");
                    Debug.WriteLine($"shortened path = {shorthand}");
                    Debug.WriteLine($"last folder in shortened path = {Path.GetFileName(shorthand)}");
                    RunPythonScriptAsync("update_drive.py", $"Temp{i}", "rename", shorthand);
                    Directory.Move(originalFolderPath, tempFolderPath);


                }
            }

            Thread.Sleep(2500);

            // Get all temporary folders
            var tempFolders = Directory.GetDirectories(parentDirectoryPath, "Temp*");
            var sortedPaths = tempFolders.OrderBy(path =>
            {
                // Get the last folder name in the path
                string folderName = Path.GetFileName(path);
                // Extract the number from the folder name using a regular expression
                string numberPart = Regex.Match(folderName, @"\d+").Value;
                return int.Parse(numberPart);
            }).ToList();
            int count = 0;
            // Phase 2: Rename temporary folders back to the 'Exhibit{index}'
            foreach (var tempFolder in sortedPaths)
            {
                Debug.WriteLine($"reordered temp folder = {TrimPathFromFolder(tempFolder, "assets")}");
                string indexStr = tempFolder.Split(new[] { "Temp" }, StringSplitOptions.None).Last();
                string finalFolderPath = Path.Combine(parentDirectoryPath, $"trail{indexStr}");

                if (Directory.Exists(tempFolder))
                {
                    string shorthand = TrimPathFromFolder(tempFolder, "assets");
                    //Debug.WriteLine($"shortened path = {shorthand}");
                    //Debug.WriteLine($"last folder in shortened path = {Path.GetFileName(shorthand)}");
                    RunPythonScriptAsync("update_drive.py", $"trail{count}", "rename", shorthand);
                    Directory.Move(tempFolder, finalFolderPath);

                }
                count++;
            }
        }

        public static void RenameTrailFolders(string parentDirectoryPath, List<Trail> trailsList)
        {
            List<Task> tasks = new List<Task>();

            // Phase 1: Rename folders to temporary names
            for (int i = 0; i < trailsList.Count; i++)
            {
                var trail = trailsList[i];
                string originalFolderPath = Path.Combine(parentDirectoryPath, $"trail{trail.Id}");
                string tempFolderPath = Path.Combine(parentDirectoryPath, $"Temp{i}");

                if (Directory.Exists(originalFolderPath))
                {
                    string shorthand = TrimPathFromFolder(originalFolderPath, "assets");

                    Debug.WriteLine($"calling python update_drive Temp{i} rename {shorthand}\nRenaming folder {shorthand} to Temp{i}");
                    var task = RunPythonScriptAsync("update_drive.py", $"Temp{i}", "rename", shorthand);
                    tasks.Add(task);
                    Directory.Move(originalFolderPath, tempFolderPath);
                }
            }

            // Synchronously wait for all tasks in Phase 1 to complete
            Task.WhenAll(tasks).GetAwaiter().GetResult();
            Debug.WriteLine("All folders renamed to temp in drive");
            // Phase 2: Collect and rename temporary folders
            var tempFolders = Directory.GetDirectories(parentDirectoryPath, "Temp*");
            var sortedPaths = tempFolders.OrderBy(path =>
            {
                string folderName = Path.GetFileName(path);
                string numberPart = Regex.Match(folderName, @"\d+").Value;
                return int.Parse(numberPart);
            }).ToList();

            tasks.Clear();  // Clear previous tasks
            int count = 0;

            foreach (var tempFolder in sortedPaths)
            {
                string finalFolderPath = Path.Combine(parentDirectoryPath, $"trail{count}");

                if (Directory.Exists(tempFolder))
                {
                    string shorthand = TrimPathFromFolder(tempFolder, "assets");
                    Debug.WriteLine($"calling python update_drive Temp{count} rename {shorthand}\nRenaming folder Temp{count} to {shorthand}");

                    var task = RunPythonScriptAsync("update_drive.py", $"trail{count}", "rename", shorthand);
                    tasks.Add(task);
                    Directory.Move(tempFolder, finalFolderPath);
                }
                count++;
            }

            // Synchronously wait for all tasks in Phase 2 to complete
            Task.WhenAll(tasks).GetAwaiter().GetResult();
            Debug.WriteLine("All folders successfully renamed");
        }

        public static void WriteStopsToJson(string jsonPath, List<TrailStop> stopsList)
        {
            var stopsToWrite = new List<object>();

            Debug.WriteLine($"The path to the file is {jsonPath}");
            for (int i = 0; i < stopsList.Count; i++)
            {
                var trailStop = stopsList[i];
                var trailStopData = new
                {
                    id = i,
                    name = trailStop.Name,
                    description = trailStop.Description,
                    images = trailStop.Images,
                    audio = trailStop.Audio,
                    is_audio = trailStop.Is_Audio
                };

                stopsToWrite.Add(trailStopData);
            }

            var wrapper = new { trailStops = stopsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            Debug.WriteLine("Stops should be saved to json file");

            // Write the JSON data to the file
            if (stopsList.Count > 0)
            {
                File.WriteAllText(jsonPath, jsonData);


            }
            else
            {
                // JSON content you want to write
                string jsonContent = @"{ ""trailStops"": []}";

                // File path where you want to save the JSON file
    

                // Check if the file already exists
                bool fileExists = File.Exists(jsonPath);

                // Write the JSON string to a file
                File.WriteAllText(jsonPath, jsonContent);

            }

            //Debug.WriteLine($"FULL PATH = {fullPath}");
            string shortHand = TrimPathFromFolder(jsonPath, "assets");
            //Debug.WriteLine($"TRIMMED PATH = {shortHand}");

            // add file to google drive
            Debug.WriteLine($"deleting file {shortHand} from drive");
            RunPythonScript("update_drive.py", shortHand, "delete");
            Debug.WriteLine($"writing file {shortHand} to drive");

            RunPythonScript("update_drive.py", shortHand, "create");
            // copy file from destination path to the image to the google drive.
            Debug.WriteLine("File is now being deleted locally");

        }

        public static void ReplaceFile(string pathToOldFile, string pathToNewFile)
        {
            Debug.WriteLine($"old file path = {pathToOldFile}, new file path = {pathToNewFile}");


            try
            {
                // Check if the old file exists
                if (File.Exists(pathToOldFile))
                {
                    // Delete the old file
                    File.Delete(pathToOldFile);
                    Debug.WriteLine("FILE HAS BEEN FOUND");
                }
                else
                {
                    throw new FileNotFoundException("The old file does not exist.", pathToOldFile);
                }

                // Get the directory of the old file
                string directory = Path.GetDirectoryName(pathToOldFile);

                // Get the name of the old file
                string oldFileName = Path.GetFileName(pathToOldFile);

                // Combine the directory of the old file with the name of the old file to get the destination path
                string destinationPath = Path.Combine(directory, oldFileName.ToLower());

                // Move the new file to the destination path, effectively renaming it to the old file's name
                File.Move(pathToNewFile, destinationPath);

                string shortHand = TrimPathFromFolder(destinationPath, "assets");
                Debug.WriteLine($"running script\npython update_drive.py {shortHand} delete");

                RunPythonScript("update_drive.py", shortHand, "delete");
                Debug.WriteLine($"running script\npython update_drive.py {shortHand} create");
                RunPythonScript("update_drive.py", shortHand, "create");
                Debug.WriteLine($"old file path = {pathToOldFile}\nnewFilePath = {pathToNewFile}\nIf this debug line is written, the file {oldFileName}, should be moved to {directory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static void WriteContactsToJson(string jsonPath, List<Contact> contactList)
        {
            var contactsToWrite = new List<object>();

            foreach (var contactItem in contactList)
            {
                var contactData = new
                {
                    id = contactItem.Id,
                    name = contactItem.Name,
                    position = contactItem.Position,
                    phone = contactItem.Phone,
                    email = contactItem.Email,
                };

                contactsToWrite.Add(contactData);
            }

            var wrapper = new { contacts = contactsToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            Debug.WriteLine("Deleting the contacts.json file in the drive");

            RunPythonScript("update_drive.py", "assets/contacts.json", "delete");
            Debug.WriteLine("Creating the contacts.json file in the drive");

            RunPythonScript("update_drive.py", "assets/contacts.json", "create");
        }

        public static void WriteAddressesToJson(string jsonPath, List<Address> addressList)
        {
            var addressToWrite = new List<object>();

            foreach (var addressItem in addressList)
            {
                var addressData = new
                {
                    id = addressItem.Id,
                    name = addressItem.Name,
                    street = addressItem.Street,
                    city = addressItem.City,
                    state = addressItem.State,
                    zip = addressItem.Zip,
                };

                addressToWrite.Add(addressData);
            }

            var wrapper = new { addressess = addressToWrite };

            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonPath, jsonData);

            Debug.WriteLine("Deleting the addresses.json file in the drive");

            RunPythonScript("update_drive.py", "assets/addresses.json", "delete");
            Debug.WriteLine("Creating the addresses.json file in the drive");

            RunPythonScript("update_drive.py", "assets/addresses.json", "create");
        }

        public static void RunPythonScript(string scriptName, params string[] arguments)
        {
            Console.WriteLine("Preparing to run Python script...");

            // Construct the script path based on the current directory
            string scriptPath = scriptName; // Just the script name if in the same directory

            // Join all the arguments with a space
            string args = string.Join(" ", arguments.Select(arg => $"\"{arg}\""));

            // Set up the process start info to use cmd.exe to run the Python script
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.Arguments = $"/c python \"{scriptPath}\" {args}";
            psi.UseShellExecute = true;
            psi.WindowStyle = ProcessWindowStyle.Minimized; // Set the window to start minimized

            Console.WriteLine("Running Python script...");
            //Process.Start(psi);
            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }

        /*        public static void RunPythonScriptAsync(string scriptName, params string[] arguments)
                {
                    Console.WriteLine("Preparing to run Python script...");

                    // Construct the script path based on the current directory
                    string scriptPath = scriptName; // Just the script name if in the same directory

                    // Join all the arguments with a space
                    string args = string.Join(" ", arguments.Select(arg => $"\"{arg}\""));

                    // Set up the process start info to use cmd.exe to run the Python script
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = $"/c python \"{scriptPath}\" {args}";
                    psi.UseShellExecute = true;
                    psi.WindowStyle = ProcessWindowStyle.Minimized; // Set the window to start minimized

                    Console.WriteLine("Running Python script...");
                    //Process.Start(psi);
                    Process.Start(psi);
                }*/
        public static Task RunPythonScriptAsync(string scriptName, params string[] arguments)
        {
            Console.WriteLine("Preparing to run Python script...");

            // Construct the script path based on the current directory
            string scriptPath = scriptName; // Just the script name if in the same directory

            // Join all the arguments with a space
            string args = string.Join(" ", arguments.Select(arg => $"\"{arg}\""));

            // Set up the process start info to use cmd.exe to run the Python script
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                Arguments = $"/c python \"{scriptPath}\" {args}",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized // Set the window to start minimized
            };

            Console.WriteLine("Running Python script...");
            var process = Process.Start(psi);

            // Create a TaskCompletionSource to represent the operation
            var tcs = new TaskCompletionSource<object>();

            // Register an event to know when the process exits
            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) =>
            {
                tcs.SetResult(null); // Signal completion
            };

            return tcs.Task;
        }


    }
}

