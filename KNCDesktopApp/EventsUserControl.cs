using Newtonsoft.Json;
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

namespace KNCDesktopApp
{
    public partial class EventsUserControl : UserControl
    {
        public EventsUserControl()
        {
            InitializeComponent();
        }

        List<Event> eventsList = new List<Event>();
        // these will be used when displaying images and pdfs
        Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();
        List<ImageElement> imageArray = new List<ImageElement>();
        // current directory is the directory that overarches the AppFilesFolder. 
        String assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        String designDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design");
        Event selectedEvent = null;

        private void EditEvents_EditExistingEvent_Button_Click(object sender, EventArgs e)
        {
            //Hide and show panels accordingly
            EditEvents_StartOver_Button.Show();
            ModifyEvents_Panel.Hide();
            EditEvents_Options_Panel.Show();

            //first clear the list
            eventsList.Clear();
            EditEvents_ComboBox.DataSource = null;
            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "events/events.json");
            Debug.WriteLine(pathToJson);
            AddEventsFromFile(pathToJson);
            //debug and make sure all trails are listed
            for (int i = 0; i < eventsList.Count; i++)
            {
                Debug.WriteLine(eventsList[i].Id);
                Debug.WriteLine(eventsList[i].Title);
                Debug.WriteLine(eventsList[i].Day);
                Debug.WriteLine(eventsList[i].Month);
                Debug.WriteLine(eventsList[i].Year);
                Debug.WriteLine(eventsList[i].StartTime);
                Debug.WriteLine(eventsList[i].EndTime);
                Debug.WriteLine(eventsList[i].Location);
            };
            EditEvents_ComboBox.DataSource = eventsList;
            EditEvents_ComboBox.DisplayMember = "title";
            EditEvents_ComboBox.ValueMember = "id";
            EditEvents_ComboBox.SelectedIndex = -1;
        }

        public void AddEventsFromFile(string pathToJson)
        {
            string json = File.ReadAllText(pathToJson);
            var events = JsonConvert.DeserializeObject<EventsRoot>(json);
            if (events?.Events != null)
            {
                eventsList.AddRange(events.Events);
            }
        }

        public void EditEvents_StartOver_Button_Click(object sender, EventArgs e)
        {
            //Hide and show elements accordingly
            EditEvents_StartOver_Button.Hide();
            ModifyEvents_Panel.Show();
            EditEvents_Options_Panel.Hide();
            EditEvents_Main_Panel.Hide();
            EditEvents_ComboBox.Show();
            EditEvents_LoadEvent_Button.Hide();
            EditEvents_DeleteEvent_Button.Hide();

            eventsList.Clear();
            selectedEvent = null;
            imageArray.Clear();

        }


        public void ResetVisually()
        {
            //Hide and show elements accordingly
            EditEvents_StartOver_Button.Hide();
            ModifyEvents_Panel.Show();
            EditEvents_Options_Panel.Hide();
            EditEvents_Main_Panel.Hide();
            EditEvents_ComboBox.Show();
            EditEvents_LoadEvent_Button.Hide();
            EditEvents_DeleteEvent_Button.Hide();
        }


        private void EditEvents_ComboBox_SelectionChangedCommitted(object sender, EventArgs e)
        {
            // save the selected event for later use
            selectedEvent = EditEvents_ComboBox.SelectedItem as Event;
            Debug.WriteLine(selectedEvent.Title);

            EditEvents_LoadEvent_Button.Show();

        }

        private void EditEvents_EditEventInfo_Button_Click(object sender, EventArgs e)
        {
            // Hide and show panels accordingly
            EditEvents_Options_Panel.Hide();
            EditEvents_Main_Panel.Show();

            EditEvents_ComboBox.Hide(); // hide the combo box so they cant change which trail they are working with unless they save or exit.

            // load data into visual components
            EditEvent_ID_Label.Text = $"ID {selectedEvent.Id}";
            EditEvent_Title_TextBox.Text = selectedEvent.Title;
            EditEvent_Day_TextBox.Text = selectedEvent.Day;
            EditEvent_Month_TextBox.Text = selectedEvent.Month;
            EditEvent_Year_TextBox.Text = selectedEvent.Year;
            EditEvent_StartTime_TextBox.Text = selectedEvent.StartTime;
            EditEvent_EndTime_TextBox.Text = selectedEvent.EndTime;
            EditEvent_Location_TextBox.Text = selectedEvent.Location;

            imageArray = Utilities.AddImagesToArray(selectedEvent.Images, Path.Combine(assetsDirectory, "events/images"));

            // only display image information if an image is loaded
            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                events_PictureBox.Image = imageArray[0].Image;
            }
            else
            {
                ImageName_Label.Text = "No image for this event";
                events_PictureBox.Image = null;
            }

            EditEvents_DeleteEvent_Button.Show();

        }

        private void SaveEvent_Button_Click(object sender, EventArgs e)
        {
            // extrapolate values from the textboxes
            int index = eventsList.Count;
            string title = EditEvent_Title_TextBox.Text;
            string day = EditEvent_Day_TextBox.Text;
            string month = EditEvent_Month_TextBox.Text;
            string year = EditEvent_Year_TextBox.Text;
            string startTime = EditEvent_StartTime_TextBox.Text;
            string endTime = EditEvent_EndTime_TextBox.Text;
            string location = EditEvent_Location_TextBox.Text;

            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";
            // if this is a new annoucement
            if (selectedEvent == null)
            {
                // create a new event with the inputted values
                selectedEvent = new Event(index, title, day, month, year, startTime, endTime, location, Utilities.ProcessImageElements(Path.Combine(assetsDirectory, "events/images"), imageArray));
                eventsList.Add(selectedEvent);
                
                
                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteEventsToJson(Path.Combine(assetsDirectory, "events/events.json"), eventsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "events/images"), eventsList);


                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        MessageBox.Show($"Event {title} has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditEvents_StartOver_Button_Click(sender, e);

                    }));
                });
            }
            // if this is an announcement that was already made
            else
            {
                // save the values in teh textboxes to the current event
                selectedEvent.Id = selectedEvent.Id;
                selectedEvent.Title = title;
                selectedEvent.Day = day;
                selectedEvent.Month = month;
                selectedEvent.Year = year;
                selectedEvent.StartTime = startTime;
                selectedEvent.EndTime = endTime;
                selectedEvent.Location = location;

                // add new images to the folder if any exist, this will call the updateDriveAsync method
                selectedEvent.Images = Utilities.ProcessImageElements(Path.Combine(assetsDirectory, "events/images"), imageArray);
                
                Task.Run(() =>
                {
                    // delete unreferenced will call the async function, because the order that it finishes does not matter
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "events/images"), eventsList);
                    // this will call the synchronous method, as it is what actually matters.
                    Utilities.WriteEventsToJson(Path.Combine(assetsDirectory, "events/events.json"), eventsList);

                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        MessageBox.Show($"Event {title} has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditEvents_StartOver_Button_Click(sender, e);

                    }));
                });

            }
        }

        private void AddImage_Button_Click(object sender, EventArgs e)
        {
            // when the user adds an image we need to add it to the imageArray and update the visual representation of it
            List<ImageElement> newImages = Utilities.LoadInNewImages(imageArray.Count, imageArray);
            imageArray.Clear();
            imageArray.AddRange(newImages);

            if (imageArray.Count > 0)
            {
                ImageName_Label.Text = imageArray[0].Name;
                events_PictureBox.Image = imageArray[0].Image;
            }

        }

        private void EditEvents_CreateNewEvent_Button_Click(object sender, EventArgs e)
        {
            //Hide and show panels accordingly
            EditEvents_StartOver_Button.Show();
            ModifyEvents_Panel.Hide();
            //EditEvents_Options_Panel.Show();
            selectedEvent = null;
            //first clear the list
            eventsList.Clear();

            //load trails from json file and save to global array.
            //get the correct path to the json file
            string pathToJson = Path.Combine(assetsDirectory, "events/events.json");
            Debug.WriteLine(pathToJson);
            AddEventsFromFile(pathToJson);
            //debug and make sure all trails are listed
            for (int i = 0; i < eventsList.Count; i++)
            {
                Debug.WriteLine(eventsList[i].Id);
                Debug.WriteLine(eventsList[i].Title);
                Debug.WriteLine(eventsList[i].Day);
                Debug.WriteLine(eventsList[i].Month);
                Debug.WriteLine(eventsList[i].Year);
                Debug.WriteLine(eventsList[i].StartTime);
                Debug.WriteLine(eventsList[i].EndTime);
                Debug.WriteLine(eventsList[i].Location);
            };

            imageArray.Clear();
            // Hide and show panels accordingly
            EditEvents_Main_Panel.Show();

            EditEvents_ComboBox.Hide(); // hide the combo box so they cant change which trail they are working with unless they save or exit.

            EditEvent_ID_Label.Text = $"ID {eventsList.Count}";
            EditEvent_Title_TextBox.Text = "";
            EditEvent_Day_TextBox.Text = "";
            EditEvent_Month_TextBox.Text = "";
            EditEvent_Year_TextBox.Text = "";
            EditEvent_StartTime_TextBox.Text = "";
            EditEvent_EndTime_TextBox.Text = "";
            EditEvent_Location_TextBox.Text = "";

            ImageName_Label.Text = "No Image selected";
            events_PictureBox.Image = null;
        }

        private void EditEvents_DeleteEvent_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Event? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                ResetVisually();
                string title = selectedEvent.Title;

                eventsList.RemoveAll(a => a.Title == selectedEvent.Title);


                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";
                Task.Run(() =>
                {
                    // initial actions to take place

                    Utilities.WriteEventsToJson(Path.Combine(assetsDirectory, "events/events.json"), eventsList);
                    Utilities.DeleteUnreferencedImages(Path.Combine(assetsDirectory, "events/images"), eventsList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        EditEvents_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Event {title} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                });

            }
            // No need to explicitly handle the 'No' case unless you want to do something specific
        }
    }
}
