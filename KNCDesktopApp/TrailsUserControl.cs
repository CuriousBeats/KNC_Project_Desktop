using KNCDesktopApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QRCoder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace KNCDesktopApp
{
    public partial class TrailsUserControl : UserControl
    {
        public TrailsUserControl()
        {
            InitializeComponent();
        }

        List<Trail> trailsList = new List<Trail>();
        List<TrailStop> trailStopsList = new List<TrailStop>();
        Trail selectedTrail = null;
        TrailStop selectedTrailStop = null;
        List<Trail> tempTrailsList = new List<Trail>();
        List<TrailStop> tempStopsList = new List<TrailStop>();
        bool orderingTrails = false;
        bool orderingStops = false;
        AudioFile audioFile = null;
        ImageElement currentTrailMap = null;

        Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();
        List<ImageElement> imageArray = new List<ImageElement>();

        // current directory is the directory that overarches the AppFilesFolder. 
        string assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        string designDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design");

        private void EditGenTrailInfo_Button_Click(object sender, EventArgs e)
        {
            selectedTrail = SelectTrail_ComboBox.SelectedItem as Trail;

            EditTrail_GenInfoPanel.Show();
            EditStop_Panel.Hide();
            ModifyTrailOptions_Panel.Hide();
            EditTrail_DeleteTrail_Button.Show();
            imageArray.Clear();
            EditGenInfoPanel_Label.Text = "Editing " + selectedTrail.Name + " general info";
            //fill in the info in the edit trail panel
            EditTrail_ID_Label.Text = "Trail ID = " + selectedTrail.Id;
            EditTrail_Name_TextBox.Text = selectedTrail.Name;
            EditTrail_Address_TextBox.Text = selectedTrail.Address;
            EditTrail_Length_TextBox.Text = selectedTrail.Length;
            EditTrail_IsLoop_CheckBox.Checked = selectedTrail.Is_Loop;
            EditTrail_Difficulty_TextBox.Text = selectedTrail.Difficulty;
            EditTrail_Description_TextBox.Text = selectedTrail.Description;

            //Utilities.InitializeAnyListView(Path.Combine(assetsDirectory, "trails/images"), selectedTrail.Images, EditTrails_ListView, Square_ImageList, imageArray, pictureDictionary);

            imageArray = Utilities.AddImagesToArray(selectedTrail.Images, Path.Combine(assetsDirectory, "trails/images"));

            if (imageArray.Count > 0)
            {
                trailImage_Label.Text = imageArray[0].Name;
                trails_PictureBox.Image = imageArray[0].Image;
            }
            else
            {
                trailImage_Label.Text = "No Image for this trail yet";
                trails_PictureBox.Image = null;
            }
            //Utilities.AddItemsToDataGrid(imageArray, EditTrails_DataGridView, "imagePreview", "fileName", "removeButton");

        }



        public void AddTrailsFromFile(string pathToJson)
        {
            string json = File.ReadAllText(pathToJson);
            var trailRoot = JsonConvert.DeserializeObject<TrailRoot>(json);
            if (trailRoot?.Trails != null)
            {
                trailsList.AddRange(trailRoot.Trails);
            }
        }

        private void AddTrailStopsFromFile(string path)
        {
            string json = File.ReadAllText(path);
            //Debug.WriteLine(json);
            var trailStopRoot = JsonConvert.DeserializeObject<TrailStopRoot>(json);
            if (trailStopRoot?.trailStops.Count > 0)
            {
                for (int i = 0; i < trailStopRoot.trailStops.Count; i++)
                {
                    Debug.WriteLine($"{trailStopRoot.trailStops[i].Name}, is audio = {trailStopRoot.trailStops[i].Is_Audio}");

                }
                trailStopsList.AddRange(trailStopRoot.trailStops);
            }
            else
            {
                Debug.WriteLine("No trailstops for this trail");
            }
        }
        private void EditExistingTrail_Button_Click(object sender, EventArgs e)
        {
            ModifyTrail_Panel.Hide();
            ModifyTrailOptions_Panel.Show();
            EditTrails_StartOver_Button.Show();
            EditTrail_DeleteTrail_Button.Hide();

            //first clear the list
            trailsList.Clear();
            SelectTrail_ComboBox.DataSource = null;

            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "trails/trails.json");
            Debug.WriteLine(pathToJson);
            // add the trail from the json file and save to the trailsList
            AddTrailsFromFile(pathToJson);
            //debug and make sure all trails are listed
            for (int i = 0; i < trailsList.Count; i++)
            {
                Debug.WriteLine(trailsList[i].Id);
                Debug.WriteLine(trailsList[i].Name);
                Debug.WriteLine(trailsList[i].Address);
                Debug.WriteLine(trailsList[i].Length);
                Debug.WriteLine(trailsList[i].Is_Loop);
                Debug.WriteLine(trailsList[i].Difficulty);
                Debug.WriteLine(trailsList[i].Description);
                //selectTrail_ComboBox.Items.Add(trailsList[i].Name);
            };
            SelectTrail_ComboBox.DataSource = trailsList;
            SelectTrail_ComboBox.DisplayMember = "Name";
            SelectTrail_ComboBox.ValueMember = "Id";
            SelectTrail_ComboBox.SelectedIndex = -1;
        }

        private void ModifyTrails_CreateTrail_Button_Click(object sender, EventArgs e)
        {
            ModifyTrail_Panel.Hide();
            EditTrail_GenInfoPanel.Show();
            EditTrails_StartOver_Button.Show();

            //first clear the list
            trailsList.Clear();

            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "trails/trails.json");
            Debug.WriteLine(pathToJson);
            AddTrailsFromFile(pathToJson);
            //debug and make sure all trails are listed
            for (int i = 0; i < trailsList.Count; i++)
            {
                Debug.WriteLine(trailsList[i].Id);
                Debug.WriteLine(trailsList[i].Name);
                Debug.WriteLine(trailsList[i].Address);
                Debug.WriteLine(trailsList[i].Length);
                Debug.WriteLine(trailsList[i].Is_Loop);
                Debug.WriteLine(trailsList[i].Difficulty);
                Debug.WriteLine(trailsList[i].Description);
            };

            imageArray.Clear();

            EditGenInfoPanel_Label.Text = "Creating New Trail";
            //fill in the info in the edit trail panel
            EditTrail_ID_Label.Text = "Trail ID = " + trailsList.Count;
            EditTrail_Name_TextBox.Text = "";
            EditTrail_Address_TextBox.Text = "";
            EditTrail_Length_TextBox.Text = "";
            EditTrail_IsLoop_CheckBox.Checked = false;
            EditTrail_Difficulty_TextBox.Text = "";
            EditTrail_Description_TextBox.Text = "";

            trailImage_Label.Text = "No Image Selected";
            trails_PictureBox.Image = null;

        }

        public void EditTrails_StartOver_Button_Click(object sender, EventArgs e)
        {
            EditTrail_GenInfoPanel.Hide();
            EditStop_Panel.Hide();
            EditTrails_StartOver_Button.Hide();
            ModifyTrail_Panel.Show();
            ModifyTrailOptions_Panel.Hide();
            SelectTrail_ComboBox.Show();
            redorderTrails_Panel.Hide();
            tempTrailsList.Clear();
            trailsList.Clear();
            editStopsOptions_Panel.Hide();
            LoadTrailStop_Button.Hide();
            trailMap_Panel.Hide();
            currentTrailMap = null;
            save_TrailMap_Button.Hide();

            EditTrail_DeleteTrail_Button.Hide();
            orderingTrails = false;
            orderingStops = false;
            selectedTrail = null;
            deleteTrailStop_Button.Hide();

            audio_Panel.Hide();
            EditGenTrailInfo_Button.Hide();
            AddStopToTrail_Button.Hide();
            ReorderStops_Button.Hide();
            EditStopOnTrail_Button.Hide();
            ModifyTrailOptions_Label.Hide();
            AudioFile audioFile = null;
            audioName_Label.Text = "No Audio File";
            TrailStopDescription_TextBox.Show();
            trails_PictureBox.Image = null;
            trailStops_PictureBox.Image = null;
            trailMap_PictureBox.Image = null;
            selectedTrailStop = null;
            selectedTrail = null;
        }

        public void ResetVisually()
        {
            EditTrail_GenInfoPanel.Hide();
            EditStop_Panel.Hide();
            EditTrails_StartOver_Button.Hide();
            ModifyTrail_Panel.Show();
            ModifyTrailOptions_Panel.Hide();
            SelectTrail_ComboBox.Show();
            redorderTrails_Panel.Hide();

            editStopsOptions_Panel.Hide();
            LoadTrailStop_Button.Hide();
            trailMap_Panel.Hide();
            save_TrailMap_Button.Hide();

            EditTrail_DeleteTrail_Button.Hide();

            deleteTrailStop_Button.Hide();
            audio_Panel.Hide();
            EditGenTrailInfo_Button.Hide();
            AddStopToTrail_Button.Hide();
            ReorderStops_Button.Hide();
            EditStopOnTrail_Button.Hide();
            ModifyTrailOptions_Label.Hide();

            TrailStopDescription_TextBox.Show();
        }



        private void SelectTrail_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTrail = SelectTrail_ComboBox.SelectedItem as Trail;
            Debug.WriteLine(selectedTrail.Name);
            ModifyTrailOptions_Label.Show();
            ModifyTrailOptions_Label.Text = "What would you like to do to\n" + selectedTrail.Name;
            ModifyTrailOptions_Label.Show();

            EditGenTrailInfo_Button.Show();
            AddStopToTrail_Button.Show();
            ReorderStops_Button.Show();
            EditStopOnTrail_Button.Show();
        }

        private void EditStopOnTrail_Button_Click(object sender, EventArgs e)
        {
            selectedTrail = SelectTrail_ComboBox.SelectedItem as Trail;

            EditTrail_GenInfoPanel.Hide();
            EditTrails_StartOver_Button.Show();
            editStopsOptions_Panel.Show();
            ModifyTrailOptions_Panel.Hide();

            trailStopsList.Clear();
            // for some reason have to refresh the data in the array, so set to null, then update at the end.
            // UI was not updating the TrailStops into the combobox, this was easiest solution
            SelectTrailStop_ComboBox.DataSource = null;

            //load trailstops from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json");
            Debug.WriteLine(pathToJson);
            AddTrailStopsFromFile(pathToJson);

            if (trailStopsList.Count > 0)
            {
                //debug and make sure all trails are listed
                for (int i = 0; i < trailStopsList.Count; i++)
                {
                    Debug.WriteLine(trailStopsList[i].Id);
                    Debug.WriteLine(trailStopsList[i].Name);
                    Debug.WriteLine(trailStopsList[i].Description);
                };
                SelectTrailStop_ComboBox.DataSource = trailStopsList;
                SelectTrailStop_ComboBox.DisplayMember = "Name";
                SelectTrailStop_ComboBox.ValueMember = "Id";
                SelectTrailStop_ComboBox.SelectedIndex = -1;


                SelectTrailStop_ComboBox.Show();

            }
            else
            {
                //ModifyTrailOptions_Panel.Hide();
                editStopsOptions_Panel.Hide();
                DialogResult result = MessageBox.Show("There are no stops for the selected trail, would you like to create a new stop? Select 'No' to start over.",
                                                      "Confirm",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // User selected 'Yes', proceed with the operation
                    AddStopToTrail_Button_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    // User selected 'No', which we're using as 'Start Over'
                    EditTrails_StartOver_Button_Click(sender, e);
                }
            }



        }

        private void AddStopToTrail_Button_Click(object sender, EventArgs e)
        {
            selectedTrail = SelectTrail_ComboBox.SelectedItem as Trail;

            EditStop_Panel.Show();
            EditTrail_GenInfoPanel.Hide();
            ModifyTrailOptions_Panel.Hide();

            EditStopPanel_Label.Text = $"Adding New Stop to Trail \"{selectedTrail.Name}\"";

            trailStopsList.Clear();
            // for some reason have to refresh the data in the array, so set to null, then update at the end.
            // UI was not updating the TrailStops into the combobox, this was easiest solution

            //load trailstops from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json");
            Debug.WriteLine(pathToJson);
            AddTrailStopsFromFile(pathToJson);

            //debug and make sure all trails are listed
            for (int i = 0; i < trailStopsList.Count; i++)
            {
                Debug.WriteLine(trailStopsList[i].Id);
                Debug.WriteLine(trailStopsList[i].Name);
                Debug.WriteLine(trailStopsList[i].Description);
            };

            imageArray.Clear();

            TrailStopID_Label.Text = $"ID = {trailStopsList.Count}";
            TrailStopName_TextBox.Text = "";
            TrailStopDescription_TextBox.Text = "";
            TrailStop_IsAudio_CheckBox.Checked = false;


            ImageName_Label.Text = "No Image selected";

            string data = $"{selectedTrail.Id}-{trailStopsList.Count}";
            GenerateAndDisplayQRCode(data);


        }

        private void EditTrail_DeleteTrail_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Trail? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ResetVisually();

                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";



                int index = selectedTrail.Id;
                string name = selectedTrail.Name;
                trailsList.RemoveAll(a => a.Id == selectedTrail.Id);
                string removedFolder = Path.Combine(assetsDirectory, $"trails/trail{index}");
                Directory.Delete(removedFolder, true);
                string shortHand = Utilities.TrimPathFromFolder(removedFolder, "assets");
                Debug.WriteLine($"Deleting file {shortHand} from drive");
                Task.Run(() =>
                {
                    // delete the folder corresponding to the trail
                    Utilities.RunPythonScript("update_drive.py", shortHand, "delete");
                    // update the trails.json file
                    Utilities.WriteTrailsToJson(Path.Combine(assetsDirectory, $"trails/trails.json"), trailsList);
                    //update the trailFolder names in case removing the trail changes the IDs of other trails
                    Utilities.RenameTrailFolders(Path.Combine(assetsDirectory, $"trails"), trailsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, $"trails/images"), trailsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail: \"{name}\" deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditTrails_StartOver_Button_Click(sender, e);


                    }));
                });




            }


        }


        private void LoadTrailStop_Button_Click(object sender, EventArgs e)
        {
            //EditTrail_GenInfoPanel.Show();
            EditStop_Panel.Show();
            //EditStop_Panel.Hide();
            ModifyTrailOptions_Panel.Hide();
            deleteTrailStop_Button.Show();
            LoadTrailStop_Button.Show();
            editStopsOptions_Panel.Hide();
            deleteTrailStop_Button.Show();

            EditStopPanel_Label.Text = $"Editing Stop \"{selectedTrailStop.Name}\"";

            // load info into labels and textboxes
            TrailStopID_Label.Text = $"ID = {selectedTrailStop.Id}";
            TrailStopName_TextBox.Text = selectedTrailStop.Name;
            TrailStopDescription_TextBox.Text = selectedTrailStop.Description;
            TrailStop_IsAudio_CheckBox.Checked = selectedTrailStop.Is_Audio;
            audioName_Label.Text = selectedTrailStop.Audio;

            imageArray = Utilities.AddImagesToArray(selectedTrailStop.Images, Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"));

            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                trailStops_PictureBox.Image = imageArray[0].Image;
            }
            else
            {
                ImageName_Label.Text = "No image for this stop";
                trailStops_PictureBox.Image = null;
            }

            if (selectedTrailStop.Is_Audio)
            {
                audio_Panel.Show();
                TrailStopDescription_TextBox.Hide();
                audioName_Label.Text = selectedTrailStop.Audio;
            }

            string data = $"{selectedTrail.Id}-{selectedTrailStop.Id}";
            GenerateAndDisplayQRCode(data);


        }

        private void GenerateAndDisplayQRCode(string data)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    QR_PictureBox.Image = Utilities.ResizeImage(qrCodeImage, 170, 170);
                }
            }
        }

        private Bitmap GenerateQRForPrinting(string data)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(100);
                    return qrCodeImage;
                }
            }
        }



        private void SelectTrailStop_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTrailStop = SelectTrailStop_ComboBox.SelectedItem as TrailStop;
            LoadTrailStop_Button.Show();
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rowBeingDragged;


        private void SaveTrailStop_Button_Click(object sender, EventArgs e)
        {
            ResetVisually();
            int index = trailStopsList.Count;
            string name = TrailStopName_TextBox.Text;
            string description = TrailStopDescription_TextBox.Text;
            //List<string> images = null;
            string audio = "";
            bool is_audio = TrailStop_IsAudio_CheckBox.Checked;
            if (audioFile != null && is_audio)
            {
                // if the is_audio flag is set and there is a file selected, make sure that the filename is carried over
                audio = Path.GetFileName(audioFile.Path); // assuming that audiofile is not null
            }
            if (audioFile == null && is_audio)
            {
                // in the situation where the user selects is_audio but does not provide an audio file, just erase the user selection
                is_audio = false;
            }

            // show dialog for google drive sync

            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";


            if (selectedTrailStop == null)
            {
                //this should only run if its a new trail stop
                Debug.WriteLine("Saving new trail stop");

                selectedTrailStop = new TrailStop(index, name, description, Utilities.ProcessImageElements(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"), imageArray), audio, is_audio);

                if (is_audio)
                {
                    selectedTrailStop.Audio = Utilities.ProcessAudioFile(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/audio"), audioFile);
                }


                trailStopsList.Add(selectedTrailStop);
                Debug.WriteLine("Writing trails to json file");

                Task.Run(() =>
                {
                // initial actions to take place
                Utilities.WriteStopsToJson(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json"), trailStopsList);
                Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"), trailStopsList);
                Utilities.DeleteUnreferencedAudio(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/audio"), trailStopsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail stop: \"{name}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditTrails_StartOver_Button_Click(sender, e);
                    }));
                });


            }
            else
            {
                Debug.WriteLine($"Saving trialstop with id {selectedTrailStop.Id}");
                // dont change the Id of the trailstop
                selectedTrailStop.Name = name;
                selectedTrailStop.Description = description;
                selectedTrailStop.Images = Utilities.ProcessImageElements(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"), imageArray);
                selectedTrailStop.Audio = audio;
                
                selectedTrailStop.Is_Audio = is_audio;


                if (is_audio)
                {
                    Utilities.ProcessAudioFile(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/audio"), audioFile);
                }

                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteStopsToJson(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json"), trailStopsList);

                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"), trailStopsList);


                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail stop: \"{name}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditTrails_StartOver_Button_Click(sender, e);
                    }));
                });


            }

        }

        private void SaveTrail_Button_Click(object sender, EventArgs e)
        {
            int index = trailsList.Count;
            string name = EditTrail_Name_TextBox.Text;
            string address = EditTrail_Address_TextBox.Text;
            string length = EditTrail_Length_TextBox.Text;
            bool is_loop = EditTrail_IsLoop_CheckBox.Checked;
            Debug.WriteLine($"is the trail a loop? {is_loop}");
            string difficulty = EditTrail_Difficulty_TextBox.Text;
            string description = EditTrail_Description_TextBox.Text;

            string imageFolderPath = Path.Combine(assetsDirectory, "trails/images");

            // do input validation here
            ResetVisually();


            //

            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

            if (selectedTrail == null)
            {

                // create the folder where we will add stuff to the trail this will run if this is a new trail
                Directory.CreateDirectory(Path.Combine(assetsDirectory, $"trails/trail{trailsList.Count}"));
                Directory.CreateDirectory(Path.Combine(assetsDirectory, $"trails/trail{trailsList.Count}/images"));
                Directory.CreateDirectory(Path.Combine(assetsDirectory, $"trails/trail{trailsList.Count}/audio"));

                



                // JSON content you want to write
                string jsonContent = @"{ ""trailStops"": []}";

                // File path where you want to save the JSON file


                // Check if the file already exists
                //bool fileExists = File.Exists();

                // Write the JSON string to a file
                File.WriteAllText(Path.Combine(assetsDirectory, $"trails/trail{trailsList.Count}/trail.json"), jsonContent);

                Utilities.RunPythonScript("update_drive.py", $"trails/trail{trailsList.Count}", "create");
                Utilities.RunPythonScript("update_drive.py", $"trails/trail{trailsList.Count}/images", "create");
                Utilities.RunPythonScript("update_drive.py", $"trails/trail{trailsList.Count}/audio", "create");
                Utilities.RunPythonScript("update_drive.py", $"trails/trail{trailsList.Count}/trail.json", "create");
                // create new selected trail from textboxes
                selectedTrail = new Trail(index, name, address, length, is_loop, difficulty, description, Utilities.ProcessImageElements(imageFolderPath, imageArray));
                Debug.WriteLine($"is the new trail a loop? {selectedTrail.Is_Loop}");

                trailsList.Add(selectedTrail);

                Task.Run(() =>
                {
                    // initial actions to take place
                    // go through all trails and make sure there are no unused images in the trails/images File since all trail images are located in the same folder
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "trails/images"), trailsList);

                    // since we can only edit general info on the page with this button, we only need to write the trailslist to the json file
                    Utilities.WriteTrailsToJson(Path.Combine(assetsDirectory, "trails/trails.json"), trailsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail: \"{name}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EditTrails_StartOver_Button_Click(sender, e);
                    }));
                });


            }
            else
            {
                // dont change trail id
                selectedTrail.Name = name;
                selectedTrail.Length = length;
                selectedTrail.Address = address;
                selectedTrail.Is_Loop = is_loop;
                selectedTrail.Difficulty = difficulty;
                selectedTrail.Description = description;
                Debug.WriteLine($"is the old trail a loop? {selectedTrail.Is_Loop}");

                selectedTrail.Images = Utilities.ProcessImageElements(imageFolderPath, imageArray);

                Task.Run(() =>
                {
                    // initial actions to take place
                    // go through all trails and make sure there are no unused images in the trails/images File since all trail images are located in the same folder
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "trails/images"), trailsList);

                    // since we can only edit general info on the page with this button, we only need to write the trailslist to the json file
                    Utilities.WriteTrailsToJson(Path.Combine(assetsDirectory, "trails/trails.json"), trailsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail: \"{name}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EditTrails_StartOver_Button_Click(sender, e);
                    }));
                });



            }

        }

        private void AddImage_Button_Click(object sender, EventArgs e)
        {
            List<ImageElement> newImages = Utilities.LoadInNewImages(imageArray.Count, imageArray);
            imageArray.Clear();
            imageArray.AddRange(newImages);

            for (int i = 0; i < imageArray.Count; i++)
            {
                Debug.WriteLine($"Image array index {i} = {imageArray[i].Name}");
            }

            if (imageArray.Count > 0)
            {
                trailImage_Label.Text = imageArray[0].Name;
                trails_PictureBox.Image = imageArray[0].Image;
            }

            //Utilities.AddItemsToDataGrid(imageArray, EditTrails_DataGridView, "imagePreview", "filename", "removeButton");
        }

        private void AddNewImageForStop_Click(object sender, EventArgs e)
        {
            List<ImageElement> newImages = Utilities.LoadInNewImages(imageArray.Count, imageArray);

            imageArray.Clear();
            imageArray.AddRange(newImages);


            for (int i = 0; i < imageArray.Count; i++)
            {
                Debug.WriteLine($"Image array index {i} = {imageArray[i].Name}");
            }

            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                trailStops_PictureBox.Image = imageArray[0].Image;
            }

            //Utilities.AddItemsToDataGrid(imageArray, EditStop_DataGridView, "imagePreview1", "fileName1", "removeButton1");
        }

        private void SaveOrderButton_Click(object sender, EventArgs e)
        {
            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";


            if (orderingStops)
            {
                // save the trailstops temp list to the json file
                // since were editing stops, and stops are still located in the same folder as the trail.json folder, we dont have to rename anything
                for (int i = 0; i < tempStopsList.Count; i++)
                {
                    Debug.WriteLine($"temp stops list {i} = {tempStopsList[i]}");
                }

                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteStopsToJson(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json"), tempStopsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        EditTrails_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Order of Trail Stops for {selectedTrail.Name} has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                });
            }
            else if (orderingTrails)
            {
                // save the trails temp to the json file
                for (int i = 0; i < tempTrailsList.Count; i++)
                {
                    Debug.WriteLine($"temp trails list {i} = {tempTrailsList[i].Name}");
                }

                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteTrailsToJson(Path.Combine(assetsDirectory, "trails/trails.json"), tempTrailsList);

                    // rename folders so that they reflect the changes
                    Utilities.RenameTrailFolders(Path.Combine(assetsDirectory, "trails"), tempTrailsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here

                        EditTrails_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"The new trail order has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                });



            }
        }

        private void TrailsReorder_DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = TrailsReorder_DataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // User is not clicking on the header or outside the rows
                Size dragSize = SystemInformation.DragSize;
                rowBeingDragged = TrailsReorder_DataGridView.Rows[rowIndexFromMouseDown];
            }
        }

        private void TrailsReorder_DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - rowBeingDragged.Cells[0].ContentBounds.Left) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - rowBeingDragged.Cells[0].ContentBounds.Top) > SystemInformation.DragSize.Height)
                {
                    // Proceed with the drag and drop operation if the user has dragged beyond the size of the drag rectangle.
                    TrailsReorder_DataGridView.DoDragDrop(rowBeingDragged, DragDropEffects.Move);
                }
            }
        }

        private void TrailsReorder_DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = TrailsReorder_DataGridView.PointToClient(new Point(e.X, e.Y));
            int targetIndex = TrailsReorder_DataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drop location is not valid or the same as the original, return.
            if (targetIndex < 0 || rowIndexFromMouseDown < 0 || targetIndex == rowIndexFromMouseDown || targetIndex >= TrailsReorder_DataGridView.Rows.Count - 1)
            {
                return;
            }


            if (orderingTrails)
            {
                // Perform the actual data swap in the list, reflecting the change in the DataGridView
                var itemToMove = tempTrailsList[rowIndexFromMouseDown];
                tempTrailsList.RemoveAt(rowIndexFromMouseDown);
                tempTrailsList.Insert(targetIndex, itemToMove);

                // Now update the DataGridView
                TrailsReorder_DataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
                TrailsReorder_DataGridView.Rows.Insert(targetIndex, rowBeingDragged);
                TrailsReorder_DataGridView.ClearSelection();
                Debug.WriteLine("");
                for (int i = 0; i < tempTrailsList.Count; i++)
                {
                    Debug.WriteLine(tempTrailsList[i].Name);
                }
            }
            else if (orderingStops)
            {
                // Perform the actual data swap in the list, reflecting the change in the DataGridView
                var itemToMove = tempStopsList[rowIndexFromMouseDown];
                tempStopsList.RemoveAt(rowIndexFromMouseDown);
                tempStopsList.Insert(targetIndex, itemToMove);

                // Now update the DataGridView
                TrailsReorder_DataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
                TrailsReorder_DataGridView.Rows.Insert(targetIndex, rowBeingDragged);
                TrailsReorder_DataGridView.ClearSelection();
                Debug.WriteLine("");
                for (int i = 0; i < tempStopsList.Count; i++)
                {
                    Debug.WriteLine(tempStopsList[i].Name);
                }
            }
        }

        private void TrailsReorder_DataGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void ReorderTrail_Button_Click(object sender, EventArgs e)
        {
            orderingTrails = true;
            DragLabel.Text = "Drag to Reorder Trails";
            redorderTrails_Panel.Show();
            ModifyTrail_Panel.Hide();
            EditTrails_StartOver_Button.Show();

            string pathToJson = Path.Combine(assetsDirectory, "trails/trails.json");
            Debug.WriteLine(pathToJson);
            AddTrailsFromFile(pathToJson);

            TrailsReorder_DataGridView.Rows.Clear();
            for (int i = 0; i < trailsList.Count; i++)
            {
                int rowIndex = TrailsReorder_DataGridView.Rows.Add();
                TrailsReorder_DataGridView.Rows[rowIndex].Height = 40;
                TrailsReorder_DataGridView.Rows[rowIndex].Cells[0].Value = trailsList[i].Name;
                tempTrailsList.Add(trailsList[i]);
            }

            TrailsReorder_DataGridView.ClearSelection();

        }

        private void ReorderStops_Button_Click(object sender, EventArgs e)
        {
            selectedTrail = SelectTrail_ComboBox.SelectedItem as Trail;

            orderingStops = true;
            DragLabel.Text = "Drag to Reorder Trail Stops";
            redorderTrails_Panel.Show();
            ModifyTrail_Panel.Hide();
            EditTrails_StartOver_Button.Show(); ;
            tempStopsList.Clear();
            trailStopsList.Clear();
            ModifyTrailOptions_Panel.Hide();


            //load trailstops from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json");
            Debug.WriteLine(pathToJson);
            AddTrailStopsFromFile(pathToJson);

            //debug and make sure all trails are listed
            for (int i = 0; i < trailStopsList.Count; i++)
            {
                Debug.WriteLine(trailStopsList[i].Id);
                Debug.WriteLine(trailStopsList[i].Name);
                Debug.WriteLine(trailStopsList[i].Description);
            };

            Debug.WriteLine($"Number of trailstops in {selectedTrail.Name} is {trailStopsList.Count}");
            TrailsReorder_DataGridView.Rows.Clear();
            for (int i = 0; i < trailStopsList.Count; i++)
            {
                int rowIndex = TrailsReorder_DataGridView.Rows.Add();
                TrailsReorder_DataGridView.Rows[rowIndex].Height = 40;
                TrailsReorder_DataGridView.Rows[rowIndex].Cells[0].Value = trailStopsList[i].Name;
                tempStopsList.Add(trailStopsList[i]);
            }

            TrailsReorder_DataGridView.ClearSelection();


        }

        private void deleteTrailStop_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Trail Stop? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ResetVisually();

                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

                string name = selectedTrailStop.Name;
                trailStopsList.RemoveAll(a => a.Id == selectedTrailStop.Id);


                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteStopsToJson(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/trail.json"), trailStopsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, $"trails/trail{selectedTrail.Id}/images"), trailStopsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Trail stop {name} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditTrails_StartOver_Button_Click(sender, e);
                    }));
                });
            }
        }

        private void TrailStop_IsAudio_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TrailStop_IsAudio_CheckBox.Checked)
            {
                audio_Panel.Show();
                TrailStopDescription_TextBox.Hide();
            }
            else
            {
                audio_Panel.Hide();
                TrailStopDescription_TextBox.Show();
            }
        }

        private void addAudio_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                Filter = "Audio Files (*.mp3;*.wav)|*.mp3;*.wav",
                Multiselect = false // Allow selection of multiple files
            };
            string tempFilename = "";

            DialogResult result = openFileDialog.ShowDialog();
            // Check if the user clicked "OK" (or "Open")
            if (result == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog.FileName;
                audioFile = new AudioFile(filePath);
                // Extract the filename with extension
                tempFilename = Path.GetFileName(filePath);
                audioName_Label.Text = tempFilename;

                // For demonstration, you can use the tempFilename variable here
                // For example, showing it in a message box or console (depending on your application type)
                Console.WriteLine($"Selected file: {tempFilename}");
            }

        }

        private void EditTrailMap_Button_Click(object sender, EventArgs e)
        {
            //display new panel with trial map image preview, and allow users to replace the trail map
            // trail map located in assets/trails/trail_map.pdf
            trailMap_Panel.Show();
            ModifyTrailOptions_Panel.Hide();
            ModifyTrail_Panel.Hide();

            trailMap_PictureBox.Image = Utilities.ResizeImage(Utilities.RenderPdfPageToImage(Path.Combine(assetsDirectory, "trails/trail_map.pdf")), 450, 450);
            trailMap_Label.Text = "trail_map.pdf";
            EditTrails_StartOver_Button.Show();
        }

        private void replaceMap_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                Filter = "PDF Files (*.pdf)|*.pdf",
                Multiselect = false // Allow selection of multiple files
            };


            // pass the file to the background worker so it can process the images quickly
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = openFileDialog.FileNames;
                // pass in the fileNames to the background worker
                Debug.WriteLine(openFileDialog.FileNames[0]);

                currentTrailMap = new ImageElement(Path.GetFileName(files[0]), Utilities.ResizeImage(Utilities.RenderPdfPageToImage(files[0]), 450, 450), 0, files[0], true);

                trailMap_PictureBox.Image = currentTrailMap.Image;
                trailMap_Label.Text = currentTrailMap.Name;
            }

            save_TrailMap_Button.Show();
        }

        private void save_TrailMap_Button_Click(object sender, EventArgs e)
        {
            ResetVisually();

            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

            Task.Run(() =>
            {
                // initial actions to take place
                // click the start over button while the google drive sync functions take place
                // delete the file named trail_map.pdf at location "assets/trails/trail_map.pdf"            
                // copy the new file to that location and name it trail_map.pdf

                Utilities.ReplaceFile(Path.Combine(assetsDirectory, "trails/trail_map.pdf"), currentTrailMap.Path);

                // When the actions above have been completed, do this
                this.Invoke(new Action(() =>
                {
                    progressDialog.Close();
                    progressDialog = null;
                    // show message box here
                    // show message box here
                    MessageBox.Show($"Trailmap has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // reset the tab
                    EditTrails_StartOver_Button_Click(sender, e);
                }));
            });



        }

        private void TrailStopName_Label_Click(object sender, EventArgs e)
        {

        }

        private void print_QR_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg";
            saveFileDialog.Title = "Save QR Code";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                // Ensure the user didn't cancel the save dialog
                string data = $"{selectedTrail.Id}-{selectedTrailStop.Id}";
                Bitmap bitmap = GenerateQRForPrinting(data);
                if (bitmap != null)
                {
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                }
            }

            MessageBox.Show($"QR code successfully saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}