using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Drawing;
using PDFtoImage;
using SkiaSharp;
using System.Linq;
using SkiaSharp.Views.Desktop;
using System.Drawing.Drawing2D;
using System.Diagnostics.Eventing.Reader;
using KNCDesktopApp.Properties;

namespace KNCDesktopApp
{
    public partial class KNCDesktopApp : Form
    {
        WelcomeUserControl Wuc = new WelcomeUserControl();
        TrailsUserControl Tuc = new TrailsUserControl();
        ExhibitsUserControl Euc = new ExhibitsUserControl();
        EventsUserControl Evuc = new EventsUserControl();
        AnnouncementsUserControl Auc = new AnnouncementsUserControl();
        HelpUserControl Huc = new HelpUserControl();

        public KNCDesktopApp()
        {
            InitializeComponent();


            //RoundButtonEdges(this);
            RefreshAllElements(this);
            WelcomeTab.Controls.Add(Wuc);
            Wuc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RefreshAllElements(Wuc);
            //RoundButtonEdges(Wuc);
            RefreshAllElements(Tuc);
            EditTrailsTab.Controls.Add(Tuc);
            //RoundButtonEdges(Tuc);
            EditExhibitsTab.Controls.Add(Euc);
            RefreshAllElements(Euc);
            //RoundButtonEdges(Euc);
            EditEventsTab.Controls.Add(Evuc);
            RefreshAllElements(Evuc);
            //RoundButtonEdges(Evuc);
            EditAnnouncementsTab.Controls.Add(Auc);
            RefreshAllElements(Auc);
            //RoundButtonEdges(Auc);
            EditHelpTab.Controls.Add(Huc);
            RefreshAllElements(Huc);

            Utilities.RunPythonScript("update_from_drive.py");


        }

        // these will be used when displaying images and pdfs
        Dictionary<string, ImageElement> pictureDictionary = new Dictionary<string, ImageElement>();
        List<ImageElement> imageArray = new List<ImageElement>();
        // add list of announcements, events, exhibits here


        // current directory is the directory that overarches the AppFilesFolder. 
        String assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        String designDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design");


        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check which tab is selected
            TabControl tabControl = (TabControl)sender;
            int selectedIndex = tabControl.SelectedIndex;

            // Reset data or perform actions based on the selected tab
            switch (selectedIndex)
            {
                case 0: // welcome tab
                    //Clear data for tab here//
                    Debug.WriteLine("welcome tab clicked");
                    break;
                case 1: // edit announcements tab
                    Debug.WriteLine("edit announcements tab clicked");
                    Auc.EditAnnouncements_StartOver_Button_Click(sender, e);
                    //EditAnnouncements_StartOver_Button_Click(EditAnnouncements_StartOver_Button, e); // click the start over button anytime the tab is reloaded
                    break;
                case 2:
                    Debug.WriteLine("Edit events tab clicked");
                    Evuc.EditEvents_StartOver_Button_Click(sender, e);
                    //EditEvents_StartOver_Button_Click(EditEvents_StartOver_Button, e);
                    break;
                case 3: // Edit trail tab
                    //Clear data for tab here//
                    Debug.WriteLine("Edit Trails Tab clicked");
                    Tuc.EditTrails_StartOver_Button_Click(sender, e);
                    //EditTrails_StartOver_Button_Click(EditTrails_StartOver_Button, e);
                    break;
                case 4: // edit exhibits tab
                    //Clear data for tab here//
                    Debug.WriteLine("Edit Exhibits clicked");
                    Euc.EditExhibits_StartOver_Button_Click(sender, e);
                    //EditExhibits_StartOver_Button_Click(EditExhibits_StartOver_Button, e);
                    break;
                case 5:
                    // Edit Help tab clicked
                    //Clear data for tab here//
                    Debug.WriteLine("Help Tab clicked");
                    Huc.help_StartOver_Button_Click(sender, e);
                    break;

            }
        }


        public void RefreshAllElements(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is MyButton myButton)
                {
                    myButton.InitializeAppearance();
                }
                else if (child is MyCheckBox myCheckBox)
                {
                    myCheckBox.InitializeAppearance();
                }
                else if (child is MyComboBox myCombo)
                {
                    myCombo.InitializeAppearance();
                }
                else if (child is MyDataGridView myDataGrid)
                {
                    myDataGrid.InitializeAppearance();
                }
                else if (child is MyLabel myLabel)
                {
                    myLabel.InitializeAppearance();
                }
                else if (child is MyTextBox myTextBox)
                {
                    myTextBox.InitializeAppearance();
                }
                else if (child.HasChildren)
                {
                    // Recursively search this child for MyButton instances
                    RefreshAllElements(child);
                }
            }
        }

        // Define padding and font for the tab text
        private Padding textPadding = new Padding(4); // Example padding
        private Font tabFont = new Font("Segui UI", 9, FontStyle.Bold); // Example font
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            Image backgroundImg = Resources.blu_green; // Load your background image here
            Rectangle tabBounds = tabControl.GetTabRect(e.Index);

            // Adjust bounds for padding
            Rectangle paddedBounds = new Rectangle(
                tabBounds.X + textPadding.Left,
                tabBounds.Y + textPadding.Top,
                tabBounds.Width - textPadding.Horizontal,
                tabBounds.Height - textPadding.Vertical
            );

            // Draw the background image within original bounds
            e.Graphics.DrawImage(backgroundImg, tabBounds);

            // Set text formatting
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            // Determine if the current tab is the selected tab
            bool isSelected = tabControl.SelectedIndex == e.Index;

            // If the tab is selected, overlay a semi-transparent white rectangle to "brighten" the background
            if (isSelected)
            {
                using (Brush overlayBrush = new SolidBrush(Color.FromArgb(120, Color.White)))
                {
                    e.Graphics.FillRectangle(overlayBrush, tabBounds);
                }
            }


            // Draw the tab text using the custom font and considering padding
            if (!isSelected)
            {
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(page.Text, tabFont, textBrush, paddedBounds, strFormat);
                }
            }
            else
            {
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(page.Text, tabFont, textBrush, paddedBounds, strFormat);
                }
            }
        }
    }



}