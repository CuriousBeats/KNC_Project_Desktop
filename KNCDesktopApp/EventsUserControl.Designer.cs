namespace KNCDesktopApp
{
    partial class EventsUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsUserControl));
            EditEvents_StartOver_Button = new MyButton();
            EditEvents_Main_Panel = new Panel();
            imagePreviewPanel = new Panel();
            events_PictureBox = new PictureBox();
            AddImage_Button = new MyButton();
            ImageName_Label = new Label();
            SaveEvent_Button = new MyButton();
            EditEvent_Location_TextBox = new MyTextBox();
            EditEvent_Location_Label = new MyLabel();
            EditEvent_EndTime_TextBox = new MyTextBox();
            EditEvent_EndTime_Label = new MyLabel();
            EditEvent_StartTime_TextBox = new MyTextBox();
            EditEvent_StartTime_Label = new MyLabel();
            EditEvent_Year_TextBox = new MyTextBox();
            EditEvent_Year_Label = new MyLabel();
            EditEvent_Month_TextBox = new MyTextBox();
            EditEvent_Month_Label = new MyLabel();
            EditEvent_Day_TextBox = new MyTextBox();
            EditEvent_Day_Label = new MyLabel();
            EditEvent_Title_Label = new MyLabel();
            EditEvent_Title_TextBox = new MyTextBox();
            EditEvent_ID_Label = new MyLabel();
            ModifyEvents_Panel = new Panel();
            EditEvents_EditExistingEvent_Button = new MyButton();
            EditEvents_CreateNewEvent_Button = new MyButton();
            EditEvents_Options_Panel = new Panel();
            selectEvent_Label = new MyLabel();
            EditEvents_LoadEvent_Button = new MyButton();
            EditEvents_ComboBox = new MyComboBox();
            EditEvents_DeleteEvent_Button = new MyButton();
            EditEvents_Main_Panel.SuspendLayout();
            imagePreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)events_PictureBox).BeginInit();
            ModifyEvents_Panel.SuspendLayout();
            EditEvents_Options_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // EditEvents_StartOver_Button
            // 
            EditEvents_StartOver_Button.BackColor = Color.White;
            EditEvents_StartOver_Button.BackgroundImage = (Image)resources.GetObject("EditEvents_StartOver_Button.BackgroundImage");
            EditEvents_StartOver_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditEvents_StartOver_Button.FlatStyle = FlatStyle.Flat;
            EditEvents_StartOver_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditEvents_StartOver_Button.ForeColor = Color.White;
            EditEvents_StartOver_Button.Location = new Point(0, 0);
            EditEvents_StartOver_Button.Name = "EditEvents_StartOver_Button";
            EditEvents_StartOver_Button.Size = new Size(273, 55);
            EditEvents_StartOver_Button.TabIndex = 5;
            EditEvents_StartOver_Button.Text = "Start Over";
            EditEvents_StartOver_Button.UseVisualStyleBackColor = true;
            EditEvents_StartOver_Button.Visible = false;
            EditEvents_StartOver_Button.Click += EditEvents_StartOver_Button_Click;
            // 
            // EditEvents_Main_Panel
            // 
            EditEvents_Main_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditEvents_Main_Panel.Controls.Add(imagePreviewPanel);
            EditEvents_Main_Panel.Controls.Add(SaveEvent_Button);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Location_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Location_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_EndTime_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_EndTime_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_StartTime_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_StartTime_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Year_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Year_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Month_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Month_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Day_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Day_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Title_Label);
            EditEvents_Main_Panel.Controls.Add(EditEvent_Title_TextBox);
            EditEvents_Main_Panel.Controls.Add(EditEvent_ID_Label);
            EditEvents_Main_Panel.Location = new Point(272, 0);
            EditEvents_Main_Panel.Name = "EditEvents_Main_Panel";
            EditEvents_Main_Panel.Size = new Size(1098, 728);
            EditEvents_Main_Panel.TabIndex = 7;
            EditEvents_Main_Panel.Visible = false;
            // 
            // imagePreviewPanel
            // 
            imagePreviewPanel.BackColor = Color.White;
            imagePreviewPanel.Controls.Add(events_PictureBox);
            imagePreviewPanel.Controls.Add(AddImage_Button);
            imagePreviewPanel.Controls.Add(ImageName_Label);
            imagePreviewPanel.Location = new Point(531, 112);
            imagePreviewPanel.Name = "imagePreviewPanel";
            imagePreviewPanel.Size = new Size(457, 503);
            imagePreviewPanel.TabIndex = 32;
            // 
            // events_PictureBox
            // 
            events_PictureBox.BackColor = Color.White;
            events_PictureBox.BorderStyle = BorderStyle.FixedSingle;
            events_PictureBox.Location = new Point(3, 3);
            events_PictureBox.Name = "events_PictureBox";
            events_PictureBox.Size = new Size(450, 450);
            events_PictureBox.TabIndex = 28;
            events_PictureBox.TabStop = false;
            // 
            // AddImage_Button
            // 
            AddImage_Button.BackColor = Color.White;
            AddImage_Button.BackgroundImage = (Image)resources.GetObject("AddImage_Button.BackgroundImage");
            AddImage_Button.BackgroundImageLayout = ImageLayout.Stretch;
            AddImage_Button.FlatAppearance.BorderSize = 0;
            AddImage_Button.FlatStyle = FlatStyle.Flat;
            AddImage_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AddImage_Button.ForeColor = Color.White;
            AddImage_Button.Location = new Point(282, 456);
            AddImage_Button.Name = "AddImage_Button";
            AddImage_Button.Size = new Size(171, 42);
            AddImage_Button.TabIndex = 28;
            AddImage_Button.Text = "Add New Image";
            AddImage_Button.UseVisualStyleBackColor = false;
            AddImage_Button.Click += AddImage_Button_Click;
            // 
            // ImageName_Label
            // 
            ImageName_Label.BackColor = Color.White;
            ImageName_Label.BorderStyle = BorderStyle.FixedSingle;
            ImageName_Label.Location = new Point(3, 456);
            ImageName_Label.Name = "ImageName_Label";
            ImageName_Label.Size = new Size(273, 41);
            ImageName_Label.TabIndex = 29;
            ImageName_Label.Text = "label1";
            ImageName_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SaveEvent_Button
            // 
            SaveEvent_Button.BackColor = Color.White;
            SaveEvent_Button.BackgroundImage = (Image)resources.GetObject("SaveEvent_Button.BackgroundImage");
            SaveEvent_Button.BackgroundImageLayout = ImageLayout.Stretch;
            SaveEvent_Button.FlatStyle = FlatStyle.Flat;
            SaveEvent_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SaveEvent_Button.ForeColor = Color.White;
            SaveEvent_Button.Location = new Point(204, 633);
            SaveEvent_Button.Name = "SaveEvent_Button";
            SaveEvent_Button.Size = new Size(132, 55);
            SaveEvent_Button.TabIndex = 27;
            SaveEvent_Button.Text = "Save Changes";
            SaveEvent_Button.UseVisualStyleBackColor = true;
            SaveEvent_Button.Click += SaveEvent_Button_Click;
            // 
            // EditEvent_Location_TextBox
            // 
            EditEvent_Location_TextBox.BackColor = Color.White;
            EditEvent_Location_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Location_TextBox.ForeColor = Color.Black;
            EditEvent_Location_TextBox.Location = new Point(99, 485);
            EditEvent_Location_TextBox.Multiline = true;
            EditEvent_Location_TextBox.Name = "EditEvent_Location_TextBox";
            EditEvent_Location_TextBox.ScrollBars = ScrollBars.Vertical;
            EditEvent_Location_TextBox.Size = new Size(356, 89);
            EditEvent_Location_TextBox.TabIndex = 14;
            // 
            // EditEvent_Location_Label
            // 
            EditEvent_Location_Label.AutoSize = true;
            EditEvent_Location_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Location_Label.ForeColor = Color.Black;
            EditEvent_Location_Label.Location = new Point(23, 485);
            EditEvent_Location_Label.Name = "EditEvent_Location_Label";
            EditEvent_Location_Label.Size = new Size(76, 19);
            EditEvent_Location_Label.TabIndex = 13;
            EditEvent_Location_Label.Text = "Location:";
            EditEvent_Location_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_EndTime_TextBox
            // 
            EditEvent_EndTime_TextBox.BackColor = Color.White;
            EditEvent_EndTime_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_EndTime_TextBox.ForeColor = Color.Black;
            EditEvent_EndTime_TextBox.Location = new Point(99, 434);
            EditEvent_EndTime_TextBox.Name = "EditEvent_EndTime_TextBox";
            EditEvent_EndTime_TextBox.Size = new Size(132, 27);
            EditEvent_EndTime_TextBox.TabIndex = 12;
            // 
            // EditEvent_EndTime_Label
            // 
            EditEvent_EndTime_Label.AutoSize = true;
            EditEvent_EndTime_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_EndTime_Label.ForeColor = Color.Black;
            EditEvent_EndTime_Label.Location = new Point(17, 438);
            EditEvent_EndTime_Label.Name = "EditEvent_EndTime_Label";
            EditEvent_EndTime_Label.Size = new Size(82, 19);
            EditEvent_EndTime_Label.TabIndex = 11;
            EditEvent_EndTime_Label.Text = "End Time:";
            EditEvent_EndTime_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_StartTime_TextBox
            // 
            EditEvent_StartTime_TextBox.BackColor = Color.White;
            EditEvent_StartTime_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_StartTime_TextBox.ForeColor = Color.Black;
            EditEvent_StartTime_TextBox.Location = new Point(99, 381);
            EditEvent_StartTime_TextBox.Name = "EditEvent_StartTime_TextBox";
            EditEvent_StartTime_TextBox.Size = new Size(132, 27);
            EditEvent_StartTime_TextBox.TabIndex = 10;
            // 
            // EditEvent_StartTime_Label
            // 
            EditEvent_StartTime_Label.AutoSize = true;
            EditEvent_StartTime_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_StartTime_Label.ForeColor = Color.Black;
            EditEvent_StartTime_Label.Location = new Point(11, 384);
            EditEvent_StartTime_Label.Name = "EditEvent_StartTime_Label";
            EditEvent_StartTime_Label.Size = new Size(87, 19);
            EditEvent_StartTime_Label.TabIndex = 9;
            EditEvent_StartTime_Label.Text = "Start Time:";
            EditEvent_StartTime_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_Year_TextBox
            // 
            EditEvent_Year_TextBox.BackColor = Color.White;
            EditEvent_Year_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Year_TextBox.ForeColor = Color.Black;
            EditEvent_Year_TextBox.Location = new Point(99, 327);
            EditEvent_Year_TextBox.Name = "EditEvent_Year_TextBox";
            EditEvent_Year_TextBox.Size = new Size(132, 27);
            EditEvent_Year_TextBox.TabIndex = 8;
            // 
            // EditEvent_Year_Label
            // 
            EditEvent_Year_Label.AutoSize = true;
            EditEvent_Year_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Year_Label.ForeColor = Color.Black;
            EditEvent_Year_Label.Location = new Point(52, 330);
            EditEvent_Year_Label.Name = "EditEvent_Year_Label";
            EditEvent_Year_Label.Size = new Size(47, 19);
            EditEvent_Year_Label.TabIndex = 7;
            EditEvent_Year_Label.Text = "Year:";
            EditEvent_Year_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_Month_TextBox
            // 
            EditEvent_Month_TextBox.BackColor = Color.White;
            EditEvent_Month_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Month_TextBox.ForeColor = Color.Black;
            EditEvent_Month_TextBox.Location = new Point(99, 274);
            EditEvent_Month_TextBox.Name = "EditEvent_Month_TextBox";
            EditEvent_Month_TextBox.Size = new Size(132, 27);
            EditEvent_Month_TextBox.TabIndex = 6;
            // 
            // EditEvent_Month_Label
            // 
            EditEvent_Month_Label.AutoSize = true;
            EditEvent_Month_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Month_Label.ForeColor = Color.Black;
            EditEvent_Month_Label.Location = new Point(41, 276);
            EditEvent_Month_Label.Name = "EditEvent_Month_Label";
            EditEvent_Month_Label.Size = new Size(58, 19);
            EditEvent_Month_Label.TabIndex = 5;
            EditEvent_Month_Label.Text = "Month:";
            EditEvent_Month_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_Day_TextBox
            // 
            EditEvent_Day_TextBox.BackColor = Color.White;
            EditEvent_Day_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Day_TextBox.ForeColor = Color.Black;
            EditEvent_Day_TextBox.Location = new Point(99, 223);
            EditEvent_Day_TextBox.Name = "EditEvent_Day_TextBox";
            EditEvent_Day_TextBox.Size = new Size(356, 27);
            EditEvent_Day_TextBox.TabIndex = 4;
            // 
            // EditEvent_Day_Label
            // 
            EditEvent_Day_Label.AutoSize = true;
            EditEvent_Day_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Day_Label.ForeColor = Color.Black;
            EditEvent_Day_Label.Location = new Point(55, 226);
            EditEvent_Day_Label.Name = "EditEvent_Day_Label";
            EditEvent_Day_Label.Size = new Size(44, 19);
            EditEvent_Day_Label.TabIndex = 3;
            EditEvent_Day_Label.Text = "Day:";
            EditEvent_Day_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_Title_Label
            // 
            EditEvent_Title_Label.AutoSize = true;
            EditEvent_Title_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Title_Label.ForeColor = Color.Black;
            EditEvent_Title_Label.Location = new Point(40, 147);
            EditEvent_Title_Label.Name = "EditEvent_Title_Label";
            EditEvent_Title_Label.Size = new Size(56, 19);
            EditEvent_Title_Label.TabIndex = 2;
            EditEvent_Title_Label.Text = "Name:";
            EditEvent_Title_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvent_Title_TextBox
            // 
            EditEvent_Title_TextBox.BackColor = Color.White;
            EditEvent_Title_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_Title_TextBox.ForeColor = Color.Black;
            EditEvent_Title_TextBox.Location = new Point(99, 147);
            EditEvent_Title_TextBox.Multiline = true;
            EditEvent_Title_TextBox.Name = "EditEvent_Title_TextBox";
            EditEvent_Title_TextBox.ScrollBars = ScrollBars.Vertical;
            EditEvent_Title_TextBox.Size = new Size(356, 58);
            EditEvent_Title_TextBox.TabIndex = 1;
            // 
            // EditEvent_ID_Label
            // 
            EditEvent_ID_Label.AutoSize = true;
            EditEvent_ID_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvent_ID_Label.ForeColor = Color.Black;
            EditEvent_ID_Label.Location = new Point(68, 103);
            EditEvent_ID_Label.Name = "EditEvent_ID_Label";
            EditEvent_ID_Label.Size = new Size(46, 19);
            EditEvent_ID_Label.TabIndex = 0;
            EditEvent_ID_Label.Text = "ID = ";
            EditEvent_ID_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ModifyEvents_Panel
            // 
            ModifyEvents_Panel.BackColor = Color.FromArgb(244, 235, 225);
            ModifyEvents_Panel.Controls.Add(EditEvents_EditExistingEvent_Button);
            ModifyEvents_Panel.Controls.Add(EditEvents_CreateNewEvent_Button);
            ModifyEvents_Panel.Location = new Point(-7, 66);
            ModifyEvents_Panel.Name = "ModifyEvents_Panel";
            ModifyEvents_Panel.Size = new Size(1419, 549);
            ModifyEvents_Panel.TabIndex = 6;
            // 
            // EditEvents_EditExistingEvent_Button
            // 
            EditEvents_EditExistingEvent_Button.BackColor = Color.White;
            EditEvents_EditExistingEvent_Button.BackgroundImage = (Image)resources.GetObject("EditEvents_EditExistingEvent_Button.BackgroundImage");
            EditEvents_EditExistingEvent_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditEvents_EditExistingEvent_Button.FlatStyle = FlatStyle.Flat;
            EditEvents_EditExistingEvent_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditEvents_EditExistingEvent_Button.ForeColor = Color.White;
            EditEvents_EditExistingEvent_Button.Location = new Point(587, 183);
            EditEvents_EditExistingEvent_Button.Name = "EditEvents_EditExistingEvent_Button";
            EditEvents_EditExistingEvent_Button.Size = new Size(211, 73);
            EditEvents_EditExistingEvent_Button.TabIndex = 0;
            EditEvents_EditExistingEvent_Button.Text = "Edit Existing Events";
            EditEvents_EditExistingEvent_Button.UseVisualStyleBackColor = true;
            EditEvents_EditExistingEvent_Button.Click += EditEvents_EditExistingEvent_Button_Click;
            // 
            // EditEvents_CreateNewEvent_Button
            // 
            EditEvents_CreateNewEvent_Button.BackColor = Color.White;
            EditEvents_CreateNewEvent_Button.BackgroundImage = (Image)resources.GetObject("EditEvents_CreateNewEvent_Button.BackgroundImage");
            EditEvents_CreateNewEvent_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditEvents_CreateNewEvent_Button.FlatStyle = FlatStyle.Flat;
            EditEvents_CreateNewEvent_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditEvents_CreateNewEvent_Button.ForeColor = Color.White;
            EditEvents_CreateNewEvent_Button.Location = new Point(587, 322);
            EditEvents_CreateNewEvent_Button.Name = "EditEvents_CreateNewEvent_Button";
            EditEvents_CreateNewEvent_Button.Size = new Size(211, 73);
            EditEvents_CreateNewEvent_Button.TabIndex = 1;
            EditEvents_CreateNewEvent_Button.Text = "Create New Event";
            EditEvents_CreateNewEvent_Button.UseVisualStyleBackColor = true;
            EditEvents_CreateNewEvent_Button.Click += EditEvents_CreateNewEvent_Button_Click;
            // 
            // EditEvents_Options_Panel
            // 
            EditEvents_Options_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditEvents_Options_Panel.Controls.Add(selectEvent_Label);
            EditEvents_Options_Panel.Controls.Add(EditEvents_LoadEvent_Button);
            EditEvents_Options_Panel.Controls.Add(EditEvents_ComboBox);
            EditEvents_Options_Panel.Location = new Point(3, 61);
            EditEvents_Options_Panel.Name = "EditEvents_Options_Panel";
            EditEvents_Options_Panel.Size = new Size(1361, 549);
            EditEvents_Options_Panel.TabIndex = 8;
            EditEvents_Options_Panel.Visible = false;
            // 
            // selectEvent_Label
            // 
            selectEvent_Label.AutoSize = true;
            selectEvent_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            selectEvent_Label.ForeColor = Color.Black;
            selectEvent_Label.Location = new Point(579, 132);
            selectEvent_Label.Name = "selectEvent_Label";
            selectEvent_Label.Size = new Size(215, 18);
            selectEvent_Label.TabIndex = 3;
            selectEvent_Label.Text = "Please select an event below";
            selectEvent_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditEvents_LoadEvent_Button
            // 
            EditEvents_LoadEvent_Button.BackColor = Color.White;
            EditEvents_LoadEvent_Button.BackgroundImage = (Image)resources.GetObject("EditEvents_LoadEvent_Button.BackgroundImage");
            EditEvents_LoadEvent_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditEvents_LoadEvent_Button.FlatStyle = FlatStyle.Flat;
            EditEvents_LoadEvent_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditEvents_LoadEvent_Button.ForeColor = Color.White;
            EditEvents_LoadEvent_Button.Location = new Point(577, 314);
            EditEvents_LoadEvent_Button.Name = "EditEvents_LoadEvent_Button";
            EditEvents_LoadEvent_Button.Size = new Size(211, 56);
            EditEvents_LoadEvent_Button.TabIndex = 2;
            EditEvents_LoadEvent_Button.Text = "Load Event";
            EditEvents_LoadEvent_Button.UseVisualStyleBackColor = true;
            EditEvents_LoadEvent_Button.Click += EditEvents_EditEventInfo_Button_Click;
            // 
            // EditEvents_ComboBox
            // 
            EditEvents_ComboBox.BackColor = Color.White;
            EditEvents_ComboBox.DropDownHeight = 150;
            EditEvents_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EditEvents_ComboBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditEvents_ComboBox.ForeColor = Color.Black;
            EditEvents_ComboBox.FormattingEnabled = true;
            EditEvents_ComboBox.IntegralHeight = false;
            EditEvents_ComboBox.ItemHeight = 19;
            EditEvents_ComboBox.Location = new Point(476, 196);
            EditEvents_ComboBox.MaxDropDownItems = 100;
            EditEvents_ComboBox.Name = "EditEvents_ComboBox";
            EditEvents_ComboBox.Size = new Size(394, 27);
            EditEvents_ComboBox.TabIndex = 0;
            EditEvents_ComboBox.SelectionChangeCommitted += EditEvents_ComboBox_SelectionChangedCommitted;
            // 
            // EditEvents_DeleteEvent_Button
            // 
            EditEvents_DeleteEvent_Button.BackColor = Color.White;
            EditEvents_DeleteEvent_Button.BackgroundImage = (Image)resources.GetObject("EditEvents_DeleteEvent_Button.BackgroundImage");
            EditEvents_DeleteEvent_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditEvents_DeleteEvent_Button.FlatStyle = FlatStyle.Flat;
            EditEvents_DeleteEvent_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditEvents_DeleteEvent_Button.ForeColor = Color.White;
            EditEvents_DeleteEvent_Button.Location = new Point(32, 651);
            EditEvents_DeleteEvent_Button.Name = "EditEvents_DeleteEvent_Button";
            EditEvents_DeleteEvent_Button.Size = new Size(211, 53);
            EditEvents_DeleteEvent_Button.TabIndex = 3;
            EditEvents_DeleteEvent_Button.Text = "Delete Event";
            EditEvents_DeleteEvent_Button.UseVisualStyleBackColor = true;
            EditEvents_DeleteEvent_Button.Click += EditEvents_DeleteEvent_Button_Click;
            // 
            // EventsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 235, 225);
            Controls.Add(EditEvents_StartOver_Button);
            Controls.Add(EditEvents_DeleteEvent_Button);
            Controls.Add(EditEvents_Options_Panel);
            Controls.Add(ModifyEvents_Panel);
            Controls.Add(EditEvents_Main_Panel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "EventsUserControl";
            Size = new Size(1367, 728);
            EditEvents_Main_Panel.ResumeLayout(false);
            EditEvents_Main_Panel.PerformLayout();
            imagePreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)events_PictureBox).EndInit();
            ModifyEvents_Panel.ResumeLayout(false);
            EditEvents_Options_Panel.ResumeLayout(false);
            EditEvents_Options_Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MyButton EditEvents_StartOver_Button;
        private Panel EditEvents_Main_Panel;
        private MyTextBox EditEvent_Location_TextBox;
        private MyLabel EditEvent_Location_Label;
        private MyTextBox EditEvent_EndTime_TextBox;
        private MyLabel EditEvent_EndTime_Label;
        private MyTextBox EditEvent_StartTime_TextBox;
        private MyLabel EditEvent_StartTime_Label;
        private MyTextBox EditEvent_Year_TextBox;
        private MyLabel EditEvent_Year_Label;
        private MyTextBox EditEvent_Month_TextBox;
        private MyLabel EditEvent_Month_Label;
        private MyTextBox EditEvent_Day_TextBox;
        private MyLabel EditEvent_Day_Label;
        private MyLabel EditEvent_Title_Label;
        private MyTextBox EditEvent_Title_TextBox;
        private MyLabel EditEvent_ID_Label;
        private Panel ModifyEvents_Panel;
        private MyButton EditEvents_EditExistingEvent_Button;
        private MyButton EditEvents_CreateNewEvent_Button;
        private Panel EditEvents_Options_Panel;
        private MyButton EditEvents_LoadEvent_Button;
        private MyButton EditEvents_DeleteEvent_Button;
        private MyComboBox EditEvents_ComboBox;
        private MyButton SaveEvent_Button;
        private MyButton AddImage_Button;
        private MyLabel selectEvent_Label;
        private Panel imagePreviewPanel;
        private PictureBox events_PictureBox;
        private Label ImageName_Label;
    }
}
