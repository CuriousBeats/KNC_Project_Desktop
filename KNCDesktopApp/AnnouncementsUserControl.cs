using Newtonsoft.Json;
using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KNCDesktopApp
{
    public partial class AnnouncementsUserControl : UserControl
    {
        Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();
        List<ImageElement> imageArray = new List<ImageElement>();
        List<Announcement> announcementsList = new List<Announcement>();
        List<Announcement> reorderedAnnouncementsList = new List<Announcement>();
        // declare the selected object as null so that none of the data is loaded yet
        Announcement selectedAnnouncement = null;

        // current directory is the directory that overarches the AppFilesFolder. 
        String assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        String designDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design");


        public AnnouncementsUserControl()
        {
            InitializeComponent();
        }

        private void LoadAnnouncement_Button_Click(object sender, EventArgs e)
        {
            // Hide and show panels accordingly
            EditAnnouncements_Main_Panel.Show();

            // hide other controls to avoid user clicking invalid options
            SelectAnnouncement_ComboBox.Hide(); 
            EditAnnouncement_DeleteAnnouncement_Button.Show();
            EditAnnouncements_Options_Panel.Hide();


            // set textboxes and labels
            AnnouncementID_Label.Text = $"ID = {selectedAnnouncement.Id}";
            AnnouncementTitle_TextBox.Text = selectedAnnouncement.Title;

            if (string.IsNullOrWhiteSpace(selectedAnnouncement.Subtitle1))
            {
                AnnouncementSub1_TextBox.Text = "";
            }
            else
            {
                AnnouncementSub1_TextBox.Text = selectedAnnouncement.Subtitle1;
            }

            if (string.IsNullOrWhiteSpace(selectedAnnouncement.Subtitle2))
            {
                AnnouncementSub2_TextBox.Text = "";
            }
            else
            {
                AnnouncementSub2_TextBox.Text = selectedAnnouncement.Subtitle2;
            }

            if (string.IsNullOrWhiteSpace(selectedAnnouncement.Description))
            {
                AnnouncementDesc_TextBox.Text = "";
            }
            else
            {
                AnnouncementDesc_TextBox.Text = selectedAnnouncement.Description;
            }

            // load image from folder and save to image array
            imageArray = Utilities.AddImagesToArray(selectedAnnouncement.Images, Path.Combine(assetsDirectory, "announcements/images"));

            // if an image exists, display the image and its name
            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                announcements_PictureBox.Image = imageArray[0].Image;
            }
            else
            {
                ImageName_Label.Text = "No Image for this Anouncement";
                announcements_PictureBox.Image = null;
            }




        }

        public void EditAnnouncements_StartOver_Button_Click(object sender, EventArgs e)
        {
            // reset tab to its default state

            // Hide and show panels accordingly
            EditAnnouncements_StartOver_Button.Hide();
            EditAnnouncements_Options_Panel.Hide();
            ModifyAnnouncements_Panel.Show();
            EditAnnouncements_Main_Panel.Hide();
            SelectAnnouncement_ComboBox.Show();
            LoadAnnouncement_Button.Hide();

            redorderAnnouncements_Panel.Hide();

            selectAnnouncement_Label.Show();
            EditAnnouncement_DeleteAnnouncement_Button.Hide();
            selectedAnnouncement = null;
            imageArray.Clear();
            reorderedAnnouncementsList.Clear();
            announcementsList.Clear();

        }



        public void ResetVisually()
        {
            // reset tab to default state VISUALLY

            // Hide and show panels accordingly
            EditAnnouncements_StartOver_Button.Hide();
            EditAnnouncements_Options_Panel.Hide();
            ModifyAnnouncements_Panel.Show();
            EditAnnouncements_Main_Panel.Hide();
            SelectAnnouncement_ComboBox.Show();
            LoadAnnouncement_Button.Hide();
            redorderAnnouncements_Panel.Hide();
            selectAnnouncement_Label.Show();
            EditAnnouncement_DeleteAnnouncement_Button.Hide();
        }

        private void SelectAnnouncement_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Check if the selected index is valid
            if (SelectAnnouncement_ComboBox.SelectedIndex >= 0)
            {
                // Safe to proceed - an item is selected
                selectedAnnouncement = SelectAnnouncement_ComboBox.SelectedItem as Announcement;
                Debug.WriteLine(selectedAnnouncement.Title);
                Debug.WriteLine($"selected index is {SelectAnnouncement_ComboBox.SelectedIndex}");
                LoadAnnouncement_Button.Show();
            }
            else
            {
                // No item is selected, handle accordingly or simply return
                return;
            }
        }

        private void EditAnnouncements_EditExisting_Button_Click(object sender, EventArgs e)
        {
            // Hide and show panels accordingly
            EditAnnouncements_Options_Panel.Show();
            ModifyAnnouncements_Panel.Hide();
            EditAnnouncements_StartOver_Button.Show();
            imageArray.Clear();
            //first clear the list
            announcementsList.Clear();
            SelectAnnouncement_ComboBox.DataSource = null;
            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "announcements/announcements.json");
            Debug.WriteLine(pathToJson);
            AddAnnouncementsFromFile(pathToJson);
            //debug and make sure all announcements are listed
            for (int i = 0; i < announcementsList.Count; i++)
            {
                Debug.WriteLine(announcementsList[i].Id);
                Debug.WriteLine(announcementsList[i].Title);
                Debug.WriteLine(announcementsList[i].Subtitle1);
                Debug.WriteLine(announcementsList[i].Subtitle2);
                Debug.WriteLine(announcementsList[i].Description);
                foreach (string filename in announcementsList[i].Images)
                {
                    Debug.WriteLine($"{filename}");
                }
            };
            // fill fisual components with data
            SelectAnnouncement_ComboBox.DataSource = announcementsList;
            SelectAnnouncement_ComboBox.DisplayMember = "title";
            SelectAnnouncement_ComboBox.ValueMember = "id";
            SelectAnnouncement_ComboBox.SelectedIndex = -1;


        }

        public void AddAnnouncementsFromFile(string pathToJson)
        {
            string json = File.ReadAllText(pathToJson);
            var announcements = JsonConvert.DeserializeObject<AnnouncementRoot>(json);
            if (announcements?.Announcements != null)
            {
                announcementsList.AddRange(announcements.Announcements);
            }
        }

        // test code for the new datagridview
        int rowIndexFromMouseDown;
        DataGridViewRow rowBeingDragged;

        private void SaveAnnouncement_Button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Save Announcement button clicked");
            int index = announcementsList.Count;
            string title = AnnouncementTitle_TextBox.Text;
            string sub1 = AnnouncementSub1_TextBox.Text;
            string sub2 = AnnouncementSub2_TextBox.Text;
            string desc = AnnouncementDesc_TextBox.Text;

            ResetVisually();
            // start a progress dialog that will take up the screen and display that the google drive sync is being done
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";
            // if this is a new annoucement
            if (selectedAnnouncement == null)
            {

                Debug.WriteLine("stuff should be getting written to drive soon");

                selectedAnnouncement = new Announcement(index, title, sub1, sub2, desc, Utilities.ProcessImageElements(Path.Combine(assetsDirectory, "announcements/images"), imageArray));
                announcementsList.Add(selectedAnnouncement);

                Task.Run(() =>
                {
                    // initial actions to take place
                    // click the start over button while the google drive sync functions take place
                    Utilities.WriteAnnouncementsToJson(Path.Combine(assetsDirectory, "announcements/announcements.json"), announcementsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "announcements/images"), announcementsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        // show message box here
                        MessageBox.Show($"Announcement: \"{title}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditAnnouncements_StartOver_Button_Click(sender, e);
                    }));
                });
            }
            // if this is an announcement that was already made
            else
            {
                selectedAnnouncement.Title = title;
                selectedAnnouncement.Subtitle1 = sub1;
                selectedAnnouncement.Subtitle2 = sub2;
                selectedAnnouncement.Description = desc;
                // add new images to the folder if any exist
                Debug.WriteLine("stuff should be getting written to drive soon");
                selectedAnnouncement.Images = Utilities.ProcessImageElements(Path.Combine(assetsDirectory, "announcements/images"), imageArray);
                //write to the json file


                Task.Run(() =>
                {
                    // initial actions to take place

                    Utilities.WriteAnnouncementsToJson(Path.Combine(assetsDirectory, "announcements/announcements.json"), announcementsList);
                    // delete any unused images from the folder
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "announcements/images"), announcementsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Announcement: \"{title}\" has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditAnnouncements_StartOver_Button_Click(sender, e);
                    }));
                });
            }
            
        }

        private void AddImage_Button_Click(object sender, EventArgs e)
        {
            // this function returns a list of imageElements selected from the file the user selectes in the file explorer, or the original image list if they cancel
            if (imageArray.Count > 0)
            {
                Debug.WriteLine($"Writing imageArray[0] name {imageArray[0].Name}");

            }
            else
            {
                Debug.WriteLine("nmo image selected");
            }

            List<ImageElement> newImages = Utilities.LoadInNewImages(imageArray.Count, imageArray);
            imageArray.Clear();
            imageArray.AddRange(newImages);
            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                announcements_PictureBox.Image = imageArray[0].Image;
            }

        }

        private void ReorderAnnouncementsButton_Click(object sender, EventArgs e)
        {
            // hide and show components
            redorderAnnouncements_Panel.Show();
            EditAnnouncements_Options_Panel.Hide();
            reorderedAnnouncementsList.Clear();
            ModifyAnnouncements_Panel.Hide();
            EditAnnouncements_StartOver_Button.Show();

            //first clear the list
            announcementsList.Clear();

            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "announcements/announcements.json");
            Debug.WriteLine(pathToJson);
            AddAnnouncementsFromFile(pathToJson);
            //debug and make sure all announcements are listed
            for (int i = 0; i < announcementsList.Count; i++)
            {
                Debug.WriteLine(announcementsList[i].Id);
                Debug.WriteLine(announcementsList[i].Title);
                Debug.WriteLine(announcementsList[i].Subtitle1);
                Debug.WriteLine(announcementsList[i].Subtitle2);
                Debug.WriteLine(announcementsList[i].Description);
            };

            AnnouncementReorder_DataGridView.Rows.Clear();
            for (int i = 0; i < announcementsList.Count; i++)
            {
                int rowIndex = AnnouncementReorder_DataGridView.Rows.Add();
                AnnouncementReorder_DataGridView.Rows[rowIndex].Height = 40;
                AnnouncementReorder_DataGridView.Rows[rowIndex].Cells[0].Value = announcementsList[i].Title;
                reorderedAnnouncementsList.Add(announcementsList[i]);
            }

            AnnouncementReorder_DataGridView.ClearSelection();

        }


        private void AnnouncementReorder_DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            // function to grab the row that needs to be dragged
            rowIndexFromMouseDown = AnnouncementReorder_DataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // User is not clicking on the header or outside the rows
                Size dragSize = SystemInformation.DragSize;
                rowBeingDragged = AnnouncementReorder_DataGridView.Rows[rowIndexFromMouseDown];
            }
        }

        private void AnnouncementReorder_DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            // function that takes the row being dragged, and drops it in the correct spot
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - rowBeingDragged.Cells[0].ContentBounds.Left) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - rowBeingDragged.Cells[0].ContentBounds.Top) > SystemInformation.DragSize.Height)
                {
                    // Proceed with the drag and drop operation if the user has dragged beyond the size of the drag rectangle.
                    AnnouncementReorder_DataGridView.DoDragDrop(rowBeingDragged, DragDropEffects.Move);
                }
            }
        }

        private void AnnouncementReorder_DataGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void AnnouncementReorder_DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = AnnouncementReorder_DataGridView.PointToClient(new Point(e.X, e.Y));
            int targetIndex = AnnouncementReorder_DataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drop location is not valid or the same as the original, return.
            if (targetIndex < 0 || rowIndexFromMouseDown < 0 || targetIndex == rowIndexFromMouseDown || targetIndex >= AnnouncementReorder_DataGridView.Rows.Count - 1)
            {
                return;
            }

            // Perform the actual data swap in the list, reflecting the change in the DataGridView
            var itemToMove = reorderedAnnouncementsList[rowIndexFromMouseDown];
            reorderedAnnouncementsList.RemoveAt(rowIndexFromMouseDown);
            reorderedAnnouncementsList.Insert(targetIndex, itemToMove);

            // Now update the DataGridView
            AnnouncementReorder_DataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
            AnnouncementReorder_DataGridView.Rows.Insert(targetIndex, rowBeingDragged);
            AnnouncementReorder_DataGridView.ClearSelection();
            Debug.WriteLine("");
            for (int i = 0; i < reorderedAnnouncementsList.Count; i++)
            {
                Debug.WriteLine(reorderedAnnouncementsList[i].Title);
            }
        }


        private void SaveOrderButton_Click(object sender, EventArgs e)
        {
            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";
            Task.Run(() =>
            {
                Utilities.WriteAnnouncementsToJson(Path.Combine(assetsDirectory, "announcements/announcements.json"), reorderedAnnouncementsList);
                // When the actions above have been completed, do this
                this.Invoke(new Action(() =>
                {
                    progressDialog.Close();
                    progressDialog = null;
                    // show message box here
                    EditAnnouncements_StartOver_Button_Click(sender, e);

                    MessageBox.Show($"Order of announcements has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }));
            });

        }

        private void EditAnnouncements_CreateNew_Button_Click(object sender, EventArgs e)
        {
            // Hide and show panels accordingly
            EditAnnouncements_Options_Panel.Show();
            ModifyAnnouncements_Panel.Hide();
            EditAnnouncements_StartOver_Button.Show();

            //first clear the list
            announcementsList.Clear();

            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "announcements/announcements.json");
            Debug.WriteLine(pathToJson);
            AddAnnouncementsFromFile(pathToJson);
            //debug and make sure all announcements are listed
            for (int i = 0; i < announcementsList.Count; i++)
            {
                Debug.WriteLine(announcementsList[i].Id);
                Debug.WriteLine(announcementsList[i].Title);
                Debug.WriteLine(announcementsList[i].Subtitle1);
                Debug.WriteLine(announcementsList[i].Subtitle2);
                Debug.WriteLine(announcementsList[i].Description);
            };


            // make sure all text boxes are blank
            // Hide and show panels accordingly
            EditAnnouncements_Main_Panel.Show();
            EditAnnouncements_Options_Panel.Hide();
            EditAnnouncement_DeleteAnnouncement_Button.Show();

            imageArray.Clear();

            //make sure all text boxes are cleared
            AnnouncementSub1_TextBox.Text = "";
            AnnouncementID_Label.Text = $"ID = {announcementsList.Count}";
            AnnouncementDesc_TextBox.Text = "";
            AnnouncementSub2_TextBox.Text = "";
            AnnouncementTitle_TextBox.Text = "";

            ImageName_Label.Text = "No Image selected";
            announcements_PictureBox.Image = null;

        }

        private void EditAnnouncement_DeleteAnnouncement_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this announcement? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {

                ResetVisually();

                // initial actions to take place
                string title = selectedAnnouncement.Title;
                announcementsList.RemoveAll(a => a.Title == selectedAnnouncement.Title);

                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";


                Task.Run(() =>
                {
                    // initial actions to take place
                    // Assume RemoveAnnouncement is a method that removes the announcement
                    // and announcementsList is your list of announcements
                    Utilities.WriteAnnouncementsToJson(Path.Combine(assetsDirectory, "announcements/announcements.json"), announcementsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "announcements/images"), announcementsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        EditAnnouncements_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Announcement {title} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }));
                });
            }
        }
    }
}
