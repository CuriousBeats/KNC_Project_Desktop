using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KNCDesktopApp
{
    public partial class ExhibitsUserControl : UserControl
    {
        public ExhibitsUserControl()
        {
            InitializeComponent();
        }
        // current directory is the directory that overarches the AppFilesFolder. 
        String assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        String designDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design");
        List<Exhibit> pastExhibits = new List<Exhibit>();
        List<Exhibit> currentExhibits = new List<Exhibit>();
        Exhibit selectedExhibit = null;
        List<Exhibit> allExhibitsList = new List<Exhibit>();
        List<Exhibit> reorderedCurrentExhibitsList = new List<Exhibit>();
        List<Exhibit> reorderedPastExhibitsList = new List<Exhibit>();
        bool changedPastCurrent = false;



        Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();
        List<ImageElement> imageArray = new List<ImageElement>();

        private void EditExhibits_ModifyExhibits_Button_Click(object sender, EventArgs e)
        {
            //hide and show panels accordingly
            EditExhibits_Options_Panel.Hide();
            ModifyExhibits_Panel.Show();
            EditExhibits_StartOver_Button.Show();
            // load exhibits into corresponding lists
            allExhibitsList.Clear();
            currentExhibits.Clear();
            pastExhibits.Clear();
            AddExhibitsFromFile(Path.Combine(assetsDirectory, "exhibits/exhibits.json"));
        }

        public void AddExhibitsFromFile(string pathToJson)
        {
            currentExhibits.Clear();
            pastExhibits.Clear();
            allExhibitsList.Clear();
            reorderedCurrentExhibitsList.Clear();
            reorderedPastExhibitsList.Clear();

            string json = File.ReadAllText(pathToJson);
            // translate exhibits.json file into list of exhibits
            var exhibitRoot = JsonConvert.DeserializeObject<ExhibitRoot>(json);
            if (exhibitRoot?.Exhibits != null)
            {
                foreach (var exhibit in exhibitRoot.Exhibits)
                {
                    if (exhibit.IsCurrent)
                    {
                        currentExhibits.Add(exhibit);
                        Debug.WriteLine($"Added exhibit {exhibit.Title} to current exhibits");
                    }
                    else
                    {
                        pastExhibits.Add(exhibit);
                        Debug.WriteLine($"Added exhibit {exhibit.Title} to past exhibits");

                    }
                    allExhibitsList.Add(exhibit);
                    Debug.WriteLine($"Added exhibit {exhibit.Title} to ALL exhibits");

                }
            }
        }

        private void ModifyExhibit_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // first combo box changed either from past to present or vice versa
            if (Equals(ModifyExhibit_ComboBox.SelectedItem, "Current"))
            {
                // NEED TO MODIFY
                ExhibitOptions_ComboBox.DataSource = currentExhibits;
                ExhibitOptions_ComboBox.DisplayMember = "Title";
                ExhibitOptions_ComboBox.ValueMember = "Id";
                ExhibitOptions_ComboBox.SelectedIndex = -1;
            }
            else
            {
                ExhibitOptions_ComboBox.DataSource = pastExhibits;
                ExhibitOptions_ComboBox.DisplayMember = "Title";
                ExhibitOptions_ComboBox.ValueMember = "Id";
                ExhibitOptions_ComboBox.SelectedIndex = -1;

            }
        }

        private void LoadExhibit_Button_Click(object sender, EventArgs e)
        {

            // place new google drive API request here
            EditExhibits_Panel.Show();
            selectedExhibit = ExhibitOptions_ComboBox.SelectedItem as Exhibit;
            EditExhibit_Name_TextBox.Text = selectedExhibit.Title;
            EditExhibit_Creator_TextBox.Text = selectedExhibit.Designer;
            EditExhibit_IsCurrent_Checkbox.Checked = selectedExhibit.IsCurrent;
            EditExhibit_DateCreated_TextBox.Text = selectedExhibit.DateCreated;
            ModifyExhibits_Panel.Hide();
            DeleteExhibit_Button.Show();
            if (selectedExhibit.Pdfs.Count > 0)
            {
                pdf_Name_Label.Text = selectedExhibit.Pdfs[0];
                pdf_Name_Label.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                pdf_Name_Label.Text = "NO PDF FOR THIS EXHIBIT";
                pdf_Name_Label.TextAlign = ContentAlignment.MiddleCenter;
            }

            imageArray.Clear();
            image_ProgressBar.Minimum = 0;
            image_ProgressBar.Maximum = 100;
            if (!ImageLoader_BackgroundWorker.IsBusy)
            {
                ImageLoader_BackgroundWorker.RunWorkerAsync();
            }


        }

        private void ImageLoader_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // take all pages of the pdf and add them to the image array.
            imageArray = Utilities.AddPdfsToArray(selectedExhibit.Pdfs, Path.Combine(assetsDirectory, $"exhibits/pdfs"), worker);
            Thread.Sleep(500);
        }

        private void ImageLoader_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine($"Progress is being reported by the progress bar, {e.ProgressPercentage}");
            image_ProgressBar.Value = e.ProgressPercentage;
            image_ProgressBar.Refresh();
        }

        private void ImageLoader_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}");
            }
            else if (!e.Cancelled)
            {
                // Now it's safe to update the ListView on the UI thread
                //Utilities.UpdateListView(EditExhibit_ListView, Tall_ImageList, imageArray);
                Utilities.AddItemsToDataGrid(imageArray, EditExhibit_DataGridView, "imagePreview", "filename", "removeButton");
                //MessageBox.Show("ListView updated successfully.");
            }
            else
            {
                MessageBox.Show("Operation was cancelled.");
            }

            image_ProgressBar.Value = 0;
            loadingBar_Panel.Hide();
            //image_ProgressBar.Hide(); 

        }

        public void EditExhibits_StartOver_Button_Click(object sender, EventArgs e)
        {
            ModifyExhibits_Panel.Hide();
            loadingBar_Panel.Show();
            EditExhibits_Panel.Hide();
            EditExhibits_Options_Panel.Show();
            EditExhibits_StartOver_Button.Hide();
            EditExhibit_DataGridView.Rows.Clear();
            redorderExhibits_Panel.Hide();
            LoadExhibit_Button.Hide();
            ModifyExhibit_ComboBox.SelectedIndex = -1;
            ExhibitOptions_ComboBox.DataSource = null;
            ExhibitOptions_ComboBox.SelectedIndex = -1;
            DeleteExhibit_Button.Hide();
            EditExhibit_DataGridView.Size = new Size(473, 664);
            ExhibitOptions_ComboBox.DataSource = null;
            ModifyExhibit_ComboBox.DataSource = null;

        }

        public void ResetVisually()
        {
            ModifyExhibits_Panel.Hide();
            loadingBar_Panel.Show();
            EditExhibits_Panel.Hide();
            EditExhibits_Options_Panel.Show();
            EditExhibits_StartOver_Button.Hide();
            EditExhibit_DataGridView.Rows.Clear();
            redorderExhibits_Panel.Hide();
            LoadExhibit_Button.Hide();
            DeleteExhibit_Button.Hide();

        }


        int rowIndexFromMouseDown;
        DataGridViewRow rowBeingDragged;


        private void SaveExhibit_Button_Click(object sender, EventArgs e)
        {
            int index = allExhibitsList.Count;
            bool is_current = EditExhibit_IsCurrent_Checkbox.Checked;
            string name = EditExhibit_Name_TextBox.Text;
            string dateCreated = EditExhibit_DateCreated_TextBox.Text;
            string creator = EditExhibit_Creator_TextBox.Text;

            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

            if (selectedExhibit == null)
            {
                // create the folder where we will save the pdfs for the new exhibit
                //Directory.CreateDirectory(Path.Combine(assetsDirectory, $"exhibits/exhibits{allExhibitsList.Count}"));

                // save the pdfs to the new exhibit, and move the pdfs to the exhibit foler
                selectedExhibit = new Exhibit(index, is_current, name, dateCreated, creator, Utilities.ProcessImageElementsForPdf(Path.Combine(assetsDirectory, $"exhibits/pdfs"), imageArray));

                if (is_current)
                {
                    currentExhibits.Add(selectedExhibit);
                }
                else
                {
                    pastExhibits.Add(selectedExhibit);
                }
            }
            else
            {
                bool prev = selectedExhibit.IsCurrent;
                selectedExhibit.IsCurrent = is_current;
                selectedExhibit.Title = name;
                selectedExhibit.DateCreated = dateCreated;
                selectedExhibit.Designer = creator;

                // save the pdfs to the pdfs array, as well as save new pdfs to the exhibits folder
                selectedExhibit.Pdfs = Utilities.ProcessImageElementsForPdf(Path.Combine(assetsDirectory, $"exhibits/pdfs"), imageArray);
                // after weve saved the exhibit to the files we must not make sure the user has not changed from past to current

                // if the user did not switch the state of the exhibit
                if (prev != is_current && is_current == false)
                {
                    Debug.WriteLine("User switched exhibit from current to past");

                    // this section will run when the user changed the state of the exhibit from current to past

                    // remove the exhibit from the list of current exhibts, and move it to the list of past exhibits
                    currentExhibits.RemoveAll(a => a.Id == selectedExhibit.Id);
                    pastExhibits.Insert(0, selectedExhibit);
                }
                else if (prev != is_current && is_current == true)
                {
                    Debug.WriteLine("User switched exhibit from past to current");

                    // this section will execute when the user changed the exhibit from past to current adding to the beginning of the current exhibits list
                    pastExhibits.RemoveAll(a => a.Id == selectedExhibit.Id);
                    currentExhibits.Insert(0, selectedExhibit);

                }
            }


            allExhibitsList.Clear();

            // this section will execute when the user did not change the state of the exhibit
            allExhibitsList.AddRange(currentExhibits);
            allExhibitsList.AddRange(pastExhibits);






            for (int i = 0; i < allExhibitsList.Count; i++)
            {
                Debug.WriteLine($"allExhibits index {i} = {allExhibitsList[i].Title}");
            }

            Task.Run(() =>
            {
                // initial actions to take place
                // write all exhibits to the json file
                Utilities.WriteExhibitsToJson(Path.Combine(assetsDirectory, "exhibits/exhibits.json"), allExhibitsList);

                // sstill need to call reorder because adding a new exhibit can mess with current exhibit ids
                //Utilities.RenameExhibitFolders(Path.Combine(assetsDirectory, "exhibits"), allExhibitsList);
                Utilities.DeleteUnreferencedPdfs(Path.Combine(assetsDirectory, $"exhibits/pdfs"), allExhibitsList);


                // When the actions above have been completed, do this
                this.Invoke(new Action(() =>
                {
                    progressDialog.Close();
                    progressDialog = null;
                    // show message box here
                    MessageBox.Show($"Exhibit {name} has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EditExhibits_StartOver_Button_Click(sender, e);


                }));
            });
        }

        private void AddNewPDF_Click(object sender, EventArgs e)
        {

            // prompt user for new pdf file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                Filter = "PDF Files (*.pdf)|*.pdf",
                Multiselect = false // Allow selection of multiple files
            };


            // pass the file to the background worker so it can process the images quickly
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadingBar_Panel.Show();

                imageArray.Clear();
                EditExhibit_DataGridView.Rows.Clear();
                string[] files  = openFileDialog.FileNames;
                // pass in the fileNames to the background worker
                Debug.WriteLine(openFileDialog.FileNames[0]);
                reloadImagesBackgroundWorker.RunWorkerAsync(files);
                pdf_Name_Label.Text = Path.GetFileName(openFileDialog.FileNames[0]);

            }
        }

        private void reloadImagesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] fileNames = e.Argument as string[];
            Debug.WriteLine(fileNames[0]);
            BackgroundWorker worker = sender as BackgroundWorker;
            int resizePdf = 200;
            int count = 0;
            foreach (string fileName in fileNames)
            {
                try
                {
                    List<Bitmap> images = Utilities.RenderPdfToImages(fileName); // Make sure this function doesn't lock the file
                    for (int i = 0; i < images.Count; i++)
                    {
                        Bitmap resizedBitmap = Utilities.ResizeImage(images[i], resizePdf, resizePdf);
                        string name = Path.GetFileName(fileName);
                        string path = fileName;
                        bool isNew = true; // Since these are being loaded anew

                        ImageElement newElement = new ImageElement(name, resizedBitmap, (0 + count), path, isNew);
                        imageArray.Add(newElement);
                        int progressPercentage = (int)((double)i / images.Count * 100);
                        Debug.WriteLine($"Reporting {progressPercentage}%");
                        worker.ReportProgress(progressPercentage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading PDF: {ex.Message}");
                }
                count++;
            }

        }

        private void reloadImagesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine($"Progress is being reported by the progress bar, {e.ProgressPercentage}");
            image_ProgressBar.Value = e.ProgressPercentage;
            image_ProgressBar.Refresh();
        }

        private void reloadImagesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}");
            }
            else if (!e.Cancelled)
            {
                // Now it's safe to update the ListView on the UI thread
                Utilities.AddItemsToDataGrid(imageArray, EditExhibit_DataGridView, "imagePreview", "filename", "removeButton");
            }
            else
            {
                MessageBox.Show("Operation was cancelled.");
            }

            image_ProgressBar.Value = 0;
            loadingBar_Panel.Hide();
            //image_ProgressBar.Hide(); 
        }

        private void ReorderExhibitsButton_Click(object sender, EventArgs e)
        {
            pastExhibits.Clear();
            currentExhibits.Clear();
            reorderedPastExhibitsList.Clear();
            reorderedCurrentExhibitsList.Clear();
            allExhibitsList.Clear();


            AddExhibitsFromFile(Path.Combine(assetsDirectory, "exhibits/exhibits.json"));

            for (int i = 0; i < pastExhibits.Count; i++)
            {
                Debug.WriteLine($"past exhibit {pastExhibits[i].Title}");
            }

            for (int i = 0; i < currentExhibits.Count; i++)
            {
                Debug.WriteLine($"current exhibit {currentExhibits[i].Title}");
            }

            for (int i = 0; i < allExhibitsList.Count; i++)
            {
                Debug.WriteLine($"All exhibits {allExhibitsList[i].Title}");
            }


            ModifyExhibits_Panel.Hide();
            EditExhibits_Options_Panel.Hide();
            EditExhibits_StartOver_Button.Show();
            redorderExhibits_Panel.Show();

            reorderedCurrentExhibitsList.Clear();
            reorderedPastExhibitsList.Clear();
            currentExhibitReorder_DataGridView.Rows.Clear();
            pastExhibitReorder_DataGridView.Rows.Clear();

            Debug.WriteLine($"The length of ALL EXHIBITS LIST IS {allExhibitsList.Count}");

            for (int i = 0; i < currentExhibits.Count; i++)
            {
                Debug.WriteLine($"Exhibit {currentExhibits[i].Title}");
                int rowIndex = currentExhibitReorder_DataGridView.Rows.Add();
                Debug.WriteLine($"row index = {rowIndex}");
                currentExhibitReorder_DataGridView.Rows[rowIndex].Height = 40;
                currentExhibitReorder_DataGridView.Rows[rowIndex].Cells[0].Value = currentExhibits[i].Title;
                reorderedCurrentExhibitsList.Add(currentExhibits[i]);
            }

            for (int i = 0; i < pastExhibits.Count; i++)
            {
                Debug.WriteLine($"Exhibit {pastExhibits[i].Title}");
                int rowIndex = pastExhibitReorder_DataGridView.Rows.Add();
                Debug.WriteLine($"row index = {rowIndex}");

                pastExhibitReorder_DataGridView.Rows[i].Height = 40;
                pastExhibitReorder_DataGridView.Rows[i].Cells[0].Value = pastExhibits[i].Title;
                reorderedPastExhibitsList.Add(pastExhibits[i]);
            }

            pastExhibitReorder_DataGridView.ClearSelection();
            currentExhibitReorder_DataGridView.ClearSelection();

        }

        private void currentExhibitReorder_DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = currentExhibitReorder_DataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // User is not clicking on the header or outside the rows
                Size dragSize = SystemInformation.DragSize;
                rowBeingDragged = currentExhibitReorder_DataGridView.Rows[rowIndexFromMouseDown];
            }
        }

        private void currentExhibitReorder_DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - rowBeingDragged.Cells[0].ContentBounds.Left) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - rowBeingDragged.Cells[0].ContentBounds.Top) > SystemInformation.DragSize.Height)
                {
                    // Proceed with the drag and drop operation if the user has dragged beyond the size of the drag rectangle.
                    currentExhibitReorder_DataGridView.DoDragDrop(rowBeingDragged, DragDropEffects.Move);
                }
            }
        }

        private void currentExhibitReorder_DataGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void currentExhibitReorder_DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = currentExhibitReorder_DataGridView.PointToClient(new Point(e.X, e.Y));
            int targetIndex = currentExhibitReorder_DataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drop location is not valid or the same as the original, return.
            if (targetIndex < 0 || rowIndexFromMouseDown < 0 || targetIndex == rowIndexFromMouseDown || targetIndex >= currentExhibitReorder_DataGridView.Rows.Count - 1)
            {
                return;
            }

            // Perform the actual data swap in the list, reflecting the change in the DataGridView
            var itemToMove = reorderedCurrentExhibitsList[rowIndexFromMouseDown];
            reorderedCurrentExhibitsList.RemoveAt(rowIndexFromMouseDown);
            reorderedCurrentExhibitsList.Insert(targetIndex, itemToMove);

            // Now update the DataGridView
            currentExhibitReorder_DataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
            currentExhibitReorder_DataGridView.Rows.Insert(targetIndex, rowBeingDragged);

            currentExhibitReorder_DataGridView.ClearSelection();
            Debug.WriteLine("");
            for (int i = 0; i < reorderedCurrentExhibitsList.Count; i++)
            {
                Debug.WriteLine(reorderedCurrentExhibitsList[i].Title);
            }
        }

        private void EditExhibits_CreateNewExhibit_Button_Click(object sender, EventArgs e)
        {
            //hide and show panels accordingly
            EditExhibits_Options_Panel.Hide();
            ModifyExhibits_Panel.Show();
            EditExhibits_StartOver_Button.Show();
            loadingBar_Panel.Hide();            
            imageArray.Clear();


            allExhibitsList.Clear();
            currentExhibits.Clear();
            pastExhibits.Clear();
            AddExhibitsFromFile(Path.Combine(assetsDirectory, "exhibits/exhibits.json"));
            // place new google drive API request here
            EditExhibits_Panel.Show();
            //selectedExhibit = ExhibitOptions_ComboBox.SelectedItem as Exhibit;
            EditExhibit_Name_TextBox.Text = "";
            EditExhibit_Creator_TextBox.Text = "";
            EditExhibit_IsCurrent_Checkbox.Checked = false;
            EditExhibit_DateCreated_TextBox.Text = "";
            ModifyExhibits_Panel.Hide();

        }

        private void ExhibitOptions_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadExhibit_Button.Show();
        }

        private void pastExhibits_DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = pastExhibitReorder_DataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // User is not clicking on the header or outside the rows
                Size dragSize = SystemInformation.DragSize;
                rowBeingDragged = pastExhibitReorder_DataGridView.Rows[rowIndexFromMouseDown];
            }
        }

        private void pastExhibits_DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - rowBeingDragged.Cells[0].ContentBounds.Left) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - rowBeingDragged.Cells[0].ContentBounds.Top) > SystemInformation.DragSize.Height)
                {
                    // Proceed with the drag and drop operation if the user has dragged beyond the size of the drag rectangle.
                    pastExhibitReorder_DataGridView.DoDragDrop(rowBeingDragged, DragDropEffects.Move);
                }
            }
        }

        private void pastExhibits_DataGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void pastExhibits_DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = pastExhibitReorder_DataGridView.PointToClient(new Point(e.X, e.Y));
            int targetIndex = pastExhibitReorder_DataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drop location is not valid or the same as the original, return.
            if (targetIndex < 0 || rowIndexFromMouseDown < 0 || targetIndex == rowIndexFromMouseDown || targetIndex >= pastExhibitReorder_DataGridView.Rows.Count - 1)
            {
                return;
            }

            // Perform the actual data swap in the list, reflecting the change in the DataGridView
            var itemToMove = reorderedPastExhibitsList[rowIndexFromMouseDown];
            reorderedPastExhibitsList.RemoveAt(rowIndexFromMouseDown);
            reorderedPastExhibitsList.Insert(targetIndex, itemToMove);

            // Now update the DataGridView
            pastExhibitReorder_DataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
            pastExhibitReorder_DataGridView.Rows.Insert(targetIndex, rowBeingDragged);

            pastExhibitReorder_DataGridView.ClearSelection();
            Debug.WriteLine("");
            for (int i = 0; i < reorderedPastExhibitsList.Count; i++)
            {
                Debug.WriteLine(reorderedPastExhibitsList[i].Title);
            }
        }

        private void SaveOrderButton_Click(object sender, EventArgs e)
        {
            allExhibitsList.Clear();

            allExhibitsList.AddRange(reorderedCurrentExhibitsList);
            allExhibitsList.AddRange(reorderedPastExhibitsList);


            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";
            // newest exhibits should be in the list first. followed by past exhibits

            for (int i = 0; i < allExhibitsList.Count; i++)
            {
                Debug.WriteLine($"allExhibits index {i} = {allExhibitsList[i].Title}, is this exhibit a current exhibit? {allExhibitsList[i].IsCurrent}");
            }



            Task.Run(() =>
            {
                // initial actions to take place

                Utilities.WriteExhibitsToJson(Path.Combine(assetsDirectory, "exhibits/exhibits.json"), allExhibitsList);

                // When the actions above have been completed, do this
                this.Invoke(new Action(() =>
                {
                    progressDialog.Close();
                    progressDialog = null;
                    // show message box here
                    // write all exhibits to the json file
                    MessageBox.Show($"Order of exhibits has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                    EditExhibits_StartOver_Button_Click(sender, e);

                }));
            });
        }

        private void DeleteExhibit_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Exhibit? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ResetVisually();

                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";


                int index = selectedExhibit.Id;
                string name = selectedExhibit.Title;
                if (selectedExhibit.IsCurrent)
                {
                    currentExhibits.RemoveAll(a => a.Id == selectedExhibit.Id);
                }
                else
                {
                    pastExhibits.RemoveAll(a => a.Id == selectedExhibit.Id);

                }
                allExhibitsList.RemoveAll(a => a.Id == selectedExhibit.Id);


                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteExhibitsToJson(Path.Combine(assetsDirectory, $"exhibits/exhibits.json"), allExhibitsList);
                    Utilities.DeleteUnreferencedPdfs(Path.Combine(assetsDirectory, "exhibits/pdfs"), allExhibitsList);


                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        Debug.WriteLine("old pdf should be removed, exhibit is deleted and should be reflected in json file");
                        MessageBox.Show($"Trail: \"{name}\" deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditExhibits_StartOver_Button_Click(sender, e);


                    }));
                });
            }
        }
    }
}
