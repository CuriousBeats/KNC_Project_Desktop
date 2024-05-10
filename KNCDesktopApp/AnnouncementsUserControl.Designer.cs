namespace KNCDesktopApp
{
    partial class AnnouncementsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementsUserControl));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            EditAnnouncements_StartOver_Button = new MyButton();
            EditAnnouncements_Options_Panel = new Panel();
            selectAnnouncement_Label = new MyLabel();
            LoadAnnouncement_Button = new MyButton();
            SelectAnnouncement_ComboBox = new MyComboBox();
            ModifyAnnouncements_Panel = new Panel();
            ReorderAnnouncementsButton = new MyButton();
            EditAnnouncements_CreateNew_Button = new MyButton();
            EditAnnouncements_EditExisting_Button = new MyButton();
            AnnouncementID_Label = new MyLabel();
            AnnouncementTitle_Label = new MyLabel();
            AnnouncementTitle_TextBox = new MyTextBox();
            AnnouncementSub1_Label = new MyLabel();
            AnnouncementSub2_Label = new MyLabel();
            AnnouncementSub1_TextBox = new MyTextBox();
            AnnouncementSub2_TextBox = new MyTextBox();
            AnnouncementDesc_Label = new MyLabel();
            AnnouncementDesc_TextBox = new MyTextBox();
            EditAnnouncements_Main_Panel = new Panel();
            imagePreviewPanel = new Panel();
            announcements_PictureBox = new PictureBox();
            ImageName_Label = new Label();
            AddImage_Button = new MyButton();
            SaveAnnouncement_Button = new MyButton();
            redorderAnnouncements_Panel = new Panel();
            myLabel1 = new MyLabel();
            AnnouncementReorder_DataGridView = new DataGridView();
            AnnouncementName = new DataGridViewTextBoxColumn();
            SaveOrderButton = new MyButton();
            EditAnnouncement_DeleteAnnouncement_Button = new MyButton();
            EditAnnouncements_Options_Panel.SuspendLayout();
            ModifyAnnouncements_Panel.SuspendLayout();
            EditAnnouncements_Main_Panel.SuspendLayout();
            imagePreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)announcements_PictureBox).BeginInit();
            redorderAnnouncements_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AnnouncementReorder_DataGridView).BeginInit();
            SuspendLayout();
            // 
            // EditAnnouncements_StartOver_Button
            // 
            EditAnnouncements_StartOver_Button.BackColor = Color.AliceBlue;
            EditAnnouncements_StartOver_Button.BackgroundImage = (Image)resources.GetObject("EditAnnouncements_StartOver_Button.BackgroundImage");
            EditAnnouncements_StartOver_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditAnnouncements_StartOver_Button.FlatStyle = FlatStyle.Flat;
            EditAnnouncements_StartOver_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditAnnouncements_StartOver_Button.ForeColor = Color.White;
            EditAnnouncements_StartOver_Button.Location = new Point(0, 0);
            EditAnnouncements_StartOver_Button.Name = "EditAnnouncements_StartOver_Button";
            EditAnnouncements_StartOver_Button.Size = new Size(273, 55);
            EditAnnouncements_StartOver_Button.TabIndex = 11;
            EditAnnouncements_StartOver_Button.Text = "Start Over";
            EditAnnouncements_StartOver_Button.UseVisualStyleBackColor = true;
            EditAnnouncements_StartOver_Button.Visible = false;
            EditAnnouncements_StartOver_Button.Click += EditAnnouncements_StartOver_Button_Click;
            // 
            // EditAnnouncements_Options_Panel
            // 
            EditAnnouncements_Options_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditAnnouncements_Options_Panel.Controls.Add(selectAnnouncement_Label);
            EditAnnouncements_Options_Panel.Controls.Add(LoadAnnouncement_Button);
            EditAnnouncements_Options_Panel.Controls.Add(SelectAnnouncement_ComboBox);
            EditAnnouncements_Options_Panel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            EditAnnouncements_Options_Panel.Location = new Point(0, 57);
            EditAnnouncements_Options_Panel.Name = "EditAnnouncements_Options_Panel";
            EditAnnouncements_Options_Panel.Size = new Size(1367, 571);
            EditAnnouncements_Options_Panel.TabIndex = 9;
            EditAnnouncements_Options_Panel.Visible = false;
            // 
            // selectAnnouncement_Label
            // 
            selectAnnouncement_Label.AutoSize = true;
            selectAnnouncement_Label.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            selectAnnouncement_Label.ForeColor = Color.Black;
            selectAnnouncement_Label.Location = new Point(601, 122);
            selectAnnouncement_Label.Name = "selectAnnouncement_Label";
            selectAnnouncement_Label.Size = new Size(148, 34);
            selectAnnouncement_Label.TabIndex = 7;
            selectAnnouncement_Label.Text = "Please select an \r\nannouncement to edit";
            selectAnnouncement_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LoadAnnouncement_Button
            // 
            LoadAnnouncement_Button.BackColor = Color.AliceBlue;
            LoadAnnouncement_Button.BackgroundImage = (Image)resources.GetObject("LoadAnnouncement_Button.BackgroundImage");
            LoadAnnouncement_Button.BackgroundImageLayout = ImageLayout.Stretch;
            LoadAnnouncement_Button.FlatStyle = FlatStyle.Flat;
            LoadAnnouncement_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LoadAnnouncement_Button.ForeColor = Color.White;
            LoadAnnouncement_Button.Location = new Point(559, 333);
            LoadAnnouncement_Button.Name = "LoadAnnouncement_Button";
            LoadAnnouncement_Button.Size = new Size(245, 52);
            LoadAnnouncement_Button.TabIndex = 1;
            LoadAnnouncement_Button.Text = "Load Announcement";
            LoadAnnouncement_Button.UseVisualStyleBackColor = true;
            LoadAnnouncement_Button.Visible = false;
            LoadAnnouncement_Button.Click += LoadAnnouncement_Button_Click;
            // 
            // SelectAnnouncement_ComboBox
            // 
            SelectAnnouncement_ComboBox.BackColor = Color.White;
            SelectAnnouncement_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectAnnouncement_ComboBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            SelectAnnouncement_ComboBox.ForeColor = Color.Black;
            SelectAnnouncement_ComboBox.FormattingEnabled = true;
            SelectAnnouncement_ComboBox.IntegralHeight = false;
            SelectAnnouncement_ComboBox.ItemHeight = 19;
            SelectAnnouncement_ComboBox.Location = new Point(482, 209);
            SelectAnnouncement_ComboBox.Name = "SelectAnnouncement_ComboBox";
            SelectAnnouncement_ComboBox.Size = new Size(397, 27);
            SelectAnnouncement_ComboBox.TabIndex = 0;
            SelectAnnouncement_ComboBox.SelectionChangeCommitted += SelectAnnouncement_ComboBox_SelectionChangeCommitted;
            // 
            // ModifyAnnouncements_Panel
            // 
            ModifyAnnouncements_Panel.BackColor = Color.FromArgb(244, 235, 225);
            ModifyAnnouncements_Panel.Controls.Add(ReorderAnnouncementsButton);
            ModifyAnnouncements_Panel.Controls.Add(EditAnnouncements_CreateNew_Button);
            ModifyAnnouncements_Panel.Controls.Add(EditAnnouncements_EditExisting_Button);
            ModifyAnnouncements_Panel.Location = new Point(0, 57);
            ModifyAnnouncements_Panel.Name = "ModifyAnnouncements_Panel";
            ModifyAnnouncements_Panel.Size = new Size(1367, 593);
            ModifyAnnouncements_Panel.TabIndex = 12;
            // 
            // ReorderAnnouncementsButton
            // 
            ReorderAnnouncementsButton.BackColor = Color.White;
            ReorderAnnouncementsButton.BackgroundImage = (Image)resources.GetObject("ReorderAnnouncementsButton.BackgroundImage");
            ReorderAnnouncementsButton.BackgroundImageLayout = ImageLayout.Stretch;
            ReorderAnnouncementsButton.FlatAppearance.BorderSize = 0;
            ReorderAnnouncementsButton.FlatStyle = FlatStyle.Flat;
            ReorderAnnouncementsButton.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            ReorderAnnouncementsButton.ForeColor = Color.White;
            ReorderAnnouncementsButton.Location = new Point(560, 300);
            ReorderAnnouncementsButton.Name = "ReorderAnnouncementsButton";
            ReorderAnnouncementsButton.Size = new Size(244, 69);
            ReorderAnnouncementsButton.TabIndex = 7;
            ReorderAnnouncementsButton.Text = "Reorder Announcements";
            ReorderAnnouncementsButton.UseVisualStyleBackColor = false;
            ReorderAnnouncementsButton.Click += ReorderAnnouncementsButton_Click;
            // 
            // EditAnnouncements_CreateNew_Button
            // 
            EditAnnouncements_CreateNew_Button.BackColor = Color.AliceBlue;
            EditAnnouncements_CreateNew_Button.BackgroundImage = (Image)resources.GetObject("EditAnnouncements_CreateNew_Button.BackgroundImage");
            EditAnnouncements_CreateNew_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditAnnouncements_CreateNew_Button.FlatStyle = FlatStyle.Flat;
            EditAnnouncements_CreateNew_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditAnnouncements_CreateNew_Button.ForeColor = Color.White;
            EditAnnouncements_CreateNew_Button.Location = new Point(560, 430);
            EditAnnouncements_CreateNew_Button.Name = "EditAnnouncements_CreateNew_Button";
            EditAnnouncements_CreateNew_Button.Size = new Size(244, 70);
            EditAnnouncements_CreateNew_Button.TabIndex = 1;
            EditAnnouncements_CreateNew_Button.Text = "Create New Announcement";
            EditAnnouncements_CreateNew_Button.UseVisualStyleBackColor = true;
            EditAnnouncements_CreateNew_Button.Click += EditAnnouncements_CreateNew_Button_Click;
            // 
            // EditAnnouncements_EditExisting_Button
            // 
            EditAnnouncements_EditExisting_Button.BackColor = Color.AliceBlue;
            EditAnnouncements_EditExisting_Button.BackgroundImage = (Image)resources.GetObject("EditAnnouncements_EditExisting_Button.BackgroundImage");
            EditAnnouncements_EditExisting_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditAnnouncements_EditExisting_Button.FlatStyle = FlatStyle.Flat;
            EditAnnouncements_EditExisting_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditAnnouncements_EditExisting_Button.ForeColor = Color.White;
            EditAnnouncements_EditExisting_Button.Location = new Point(560, 165);
            EditAnnouncements_EditExisting_Button.Name = "EditAnnouncements_EditExisting_Button";
            EditAnnouncements_EditExisting_Button.Size = new Size(244, 71);
            EditAnnouncements_EditExisting_Button.TabIndex = 0;
            EditAnnouncements_EditExisting_Button.Text = "Edit Existing Announcement";
            EditAnnouncements_EditExisting_Button.UseVisualStyleBackColor = true;
            EditAnnouncements_EditExisting_Button.Click += EditAnnouncements_EditExisting_Button_Click;
            // 
            // AnnouncementID_Label
            // 
            AnnouncementID_Label.AutoSize = true;
            AnnouncementID_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementID_Label.ForeColor = Color.Black;
            AnnouncementID_Label.Location = new Point(86, 119);
            AnnouncementID_Label.Name = "AnnouncementID_Label";
            AnnouncementID_Label.Size = new Size(31, 19);
            AnnouncementID_Label.TabIndex = 1;
            AnnouncementID_Label.Text = "ID:";
            AnnouncementID_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementTitle_Label
            // 
            AnnouncementTitle_Label.AutoSize = true;
            AnnouncementTitle_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementTitle_Label.ForeColor = Color.Black;
            AnnouncementTitle_Label.Location = new Point(72, 167);
            AnnouncementTitle_Label.Name = "AnnouncementTitle_Label";
            AnnouncementTitle_Label.Size = new Size(56, 19);
            AnnouncementTitle_Label.TabIndex = 2;
            AnnouncementTitle_Label.Text = "Name:";
            AnnouncementTitle_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementTitle_TextBox
            // 
            AnnouncementTitle_TextBox.BackColor = Color.White;
            AnnouncementTitle_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementTitle_TextBox.ForeColor = Color.Black;
            AnnouncementTitle_TextBox.Location = new Point(119, 167);
            AnnouncementTitle_TextBox.Multiline = true;
            AnnouncementTitle_TextBox.Name = "AnnouncementTitle_TextBox";
            AnnouncementTitle_TextBox.ScrollBars = ScrollBars.Vertical;
            AnnouncementTitle_TextBox.Size = new Size(342, 49);
            AnnouncementTitle_TextBox.TabIndex = 3;
            // 
            // AnnouncementSub1_Label
            // 
            AnnouncementSub1_Label.AutoSize = true;
            AnnouncementSub1_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementSub1_Label.ForeColor = Color.Black;
            AnnouncementSub1_Label.Location = new Point(38, 236);
            AnnouncementSub1_Label.Name = "AnnouncementSub1_Label";
            AnnouncementSub1_Label.Size = new Size(81, 19);
            AnnouncementSub1_Label.TabIndex = 4;
            AnnouncementSub1_Label.Text = "Subtitle 1:";
            AnnouncementSub1_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementSub2_Label
            // 
            AnnouncementSub2_Label.AutoSize = true;
            AnnouncementSub2_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementSub2_Label.ForeColor = Color.Black;
            AnnouncementSub2_Label.Location = new Point(38, 319);
            AnnouncementSub2_Label.Name = "AnnouncementSub2_Label";
            AnnouncementSub2_Label.Size = new Size(81, 19);
            AnnouncementSub2_Label.TabIndex = 5;
            AnnouncementSub2_Label.Text = "Subtitle 2:";
            AnnouncementSub2_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementSub1_TextBox
            // 
            AnnouncementSub1_TextBox.BackColor = Color.White;
            AnnouncementSub1_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementSub1_TextBox.ForeColor = Color.Black;
            AnnouncementSub1_TextBox.Location = new Point(119, 232);
            AnnouncementSub1_TextBox.Multiline = true;
            AnnouncementSub1_TextBox.Name = "AnnouncementSub1_TextBox";
            AnnouncementSub1_TextBox.ScrollBars = ScrollBars.Vertical;
            AnnouncementSub1_TextBox.Size = new Size(342, 81);
            AnnouncementSub1_TextBox.TabIndex = 6;
            // 
            // AnnouncementSub2_TextBox
            // 
            AnnouncementSub2_TextBox.BackColor = Color.White;
            AnnouncementSub2_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementSub2_TextBox.ForeColor = Color.Black;
            AnnouncementSub2_TextBox.Location = new Point(119, 319);
            AnnouncementSub2_TextBox.Multiline = true;
            AnnouncementSub2_TextBox.Name = "AnnouncementSub2_TextBox";
            AnnouncementSub2_TextBox.ScrollBars = ScrollBars.Vertical;
            AnnouncementSub2_TextBox.Size = new Size(342, 82);
            AnnouncementSub2_TextBox.TabIndex = 7;
            // 
            // AnnouncementDesc_Label
            // 
            AnnouncementDesc_Label.AutoSize = true;
            AnnouncementDesc_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementDesc_Label.ForeColor = Color.Black;
            AnnouncementDesc_Label.Location = new Point(25, 407);
            AnnouncementDesc_Label.Name = "AnnouncementDesc_Label";
            AnnouncementDesc_Label.Size = new Size(97, 19);
            AnnouncementDesc_Label.TabIndex = 8;
            AnnouncementDesc_Label.Text = "Description:";
            AnnouncementDesc_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementDesc_TextBox
            // 
            AnnouncementDesc_TextBox.BackColor = Color.White;
            AnnouncementDesc_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnnouncementDesc_TextBox.ForeColor = Color.Black;
            AnnouncementDesc_TextBox.Location = new Point(119, 407);
            AnnouncementDesc_TextBox.Multiline = true;
            AnnouncementDesc_TextBox.Name = "AnnouncementDesc_TextBox";
            AnnouncementDesc_TextBox.ScrollBars = ScrollBars.Vertical;
            AnnouncementDesc_TextBox.Size = new Size(342, 90);
            AnnouncementDesc_TextBox.TabIndex = 9;
            // 
            // EditAnnouncements_Main_Panel
            // 
            EditAnnouncements_Main_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditAnnouncements_Main_Panel.Controls.Add(imagePreviewPanel);
            EditAnnouncements_Main_Panel.Controls.Add(SaveAnnouncement_Button);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementDesc_TextBox);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementDesc_Label);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementSub2_TextBox);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementSub1_TextBox);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementSub2_Label);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementSub1_Label);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementTitle_TextBox);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementTitle_Label);
            EditAnnouncements_Main_Panel.Controls.Add(AnnouncementID_Label);
            EditAnnouncements_Main_Panel.Location = new Point(272, 0);
            EditAnnouncements_Main_Panel.Name = "EditAnnouncements_Main_Panel";
            EditAnnouncements_Main_Panel.Size = new Size(1095, 728);
            EditAnnouncements_Main_Panel.TabIndex = 10;
            EditAnnouncements_Main_Panel.Visible = false;
            // 
            // imagePreviewPanel
            // 
            imagePreviewPanel.BackColor = Color.White;
            imagePreviewPanel.Controls.Add(announcements_PictureBox);
            imagePreviewPanel.Controls.Add(ImageName_Label);
            imagePreviewPanel.Controls.Add(AddImage_Button);
            imagePreviewPanel.Location = new Point(538, 119);
            imagePreviewPanel.Name = "imagePreviewPanel";
            imagePreviewPanel.Size = new Size(457, 503);
            imagePreviewPanel.TabIndex = 31;
            // 
            // announcements_PictureBox
            // 
            announcements_PictureBox.BackColor = Color.White;
            announcements_PictureBox.BorderStyle = BorderStyle.FixedSingle;
            announcements_PictureBox.Location = new Point(3, 3);
            announcements_PictureBox.Name = "announcements_PictureBox";
            announcements_PictureBox.Size = new Size(450, 450);
            announcements_PictureBox.TabIndex = 28;
            announcements_PictureBox.TabStop = false;
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
            // AddImage_Button
            // 
            AddImage_Button.BackColor = Color.White;
            AddImage_Button.BackgroundImage = (Image)resources.GetObject("AddImage_Button.BackgroundImage");
            AddImage_Button.BackgroundImageLayout = ImageLayout.Stretch;
            AddImage_Button.FlatAppearance.BorderSize = 0;
            AddImage_Button.FlatStyle = FlatStyle.Flat;
            AddImage_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AddImage_Button.ForeColor = Color.White;
            AddImage_Button.Location = new Point(279, 456);
            AddImage_Button.Name = "AddImage_Button";
            AddImage_Button.Size = new Size(172, 41);
            AddImage_Button.TabIndex = 27;
            AddImage_Button.Text = "Add New Image";
            AddImage_Button.UseVisualStyleBackColor = false;
            AddImage_Button.Click += AddImage_Button_Click;
            // 
            // SaveAnnouncement_Button
            // 
            SaveAnnouncement_Button.BackColor = Color.AliceBlue;
            SaveAnnouncement_Button.BackgroundImage = (Image)resources.GetObject("SaveAnnouncement_Button.BackgroundImage");
            SaveAnnouncement_Button.BackgroundImageLayout = ImageLayout.Stretch;
            SaveAnnouncement_Button.FlatStyle = FlatStyle.Flat;
            SaveAnnouncement_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SaveAnnouncement_Button.ForeColor = Color.White;
            SaveAnnouncement_Button.Location = new Point(210, 634);
            SaveAnnouncement_Button.Name = "SaveAnnouncement_Button";
            SaveAnnouncement_Button.Size = new Size(132, 55);
            SaveAnnouncement_Button.TabIndex = 26;
            SaveAnnouncement_Button.Text = "Save Changes";
            SaveAnnouncement_Button.UseVisualStyleBackColor = true;
            SaveAnnouncement_Button.Click += SaveAnnouncement_Button_Click;
            // 
            // redorderAnnouncements_Panel
            // 
            redorderAnnouncements_Panel.Controls.Add(myLabel1);
            redorderAnnouncements_Panel.Controls.Add(AnnouncementReorder_DataGridView);
            redorderAnnouncements_Panel.Controls.Add(SaveOrderButton);
            redorderAnnouncements_Panel.Location = new Point(0, 45);
            redorderAnnouncements_Panel.Name = "redorderAnnouncements_Panel";
            redorderAnnouncements_Panel.Size = new Size(1367, 605);
            redorderAnnouncements_Panel.TabIndex = 13;
            redorderAnnouncements_Panel.Visible = false;
            // 
            // myLabel1
            // 
            myLabel1.AutoSize = true;
            myLabel1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            myLabel1.ForeColor = Color.Black;
            myLabel1.Location = new Point(529, 19);
            myLabel1.Name = "myLabel1";
            myLabel1.Size = new Size(266, 19);
            myLabel1.TabIndex = 27;
            myLabel1.Text = "Drag and Drop the Announcements";
            myLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AnnouncementReorder_DataGridView
            // 
            AnnouncementReorder_DataGridView.AllowDrop = true;
            AnnouncementReorder_DataGridView.AllowUserToAddRows = false;
            AnnouncementReorder_DataGridView.AllowUserToDeleteRows = false;
            AnnouncementReorder_DataGridView.AllowUserToResizeColumns = false;
            AnnouncementReorder_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            AnnouncementReorder_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            AnnouncementReorder_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AnnouncementReorder_DataGridView.Columns.AddRange(new DataGridViewColumn[] { AnnouncementName });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            AnnouncementReorder_DataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            AnnouncementReorder_DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            AnnouncementReorder_DataGridView.Location = new Point(470, 53);
            AnnouncementReorder_DataGridView.MultiSelect = false;
            AnnouncementReorder_DataGridView.Name = "AnnouncementReorder_DataGridView";
            AnnouncementReorder_DataGridView.RowHeadersVisible = false;
            AnnouncementReorder_DataGridView.RowHeadersWidth = 51;
            AnnouncementReorder_DataGridView.ScrollBars = ScrollBars.Vertical;
            AnnouncementReorder_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AnnouncementReorder_DataGridView.Size = new Size(400, 541);
            AnnouncementReorder_DataGridView.TabIndex = 26;
            AnnouncementReorder_DataGridView.DragDrop += AnnouncementReorder_DataGridView_DragDrop;
            AnnouncementReorder_DataGridView.DragOver += AnnouncementReorder_DataGridView_DragOver;
            AnnouncementReorder_DataGridView.MouseDown += AnnouncementReorder_DataGridView_MouseDown;
            AnnouncementReorder_DataGridView.MouseMove += AnnouncementReorder_DataGridView_MouseMove;
            // 
            // AnnouncementName
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            AnnouncementName.DefaultCellStyle = dataGridViewCellStyle5;
            AnnouncementName.HeaderText = "Announcements";
            AnnouncementName.MinimumWidth = 6;
            AnnouncementName.Name = "AnnouncementName";
            AnnouncementName.Width = 400;
            // 
            // SaveOrderButton
            // 
            SaveOrderButton.BackColor = Color.White;
            SaveOrderButton.BackgroundImage = (Image)resources.GetObject("SaveOrderButton.BackgroundImage");
            SaveOrderButton.BackgroundImageLayout = ImageLayout.Stretch;
            SaveOrderButton.FlatAppearance.BorderSize = 0;
            SaveOrderButton.FlatStyle = FlatStyle.Flat;
            SaveOrderButton.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SaveOrderButton.ForeColor = Color.White;
            SaveOrderButton.Location = new Point(956, 529);
            SaveOrderButton.Name = "SaveOrderButton";
            SaveOrderButton.Size = new Size(176, 65);
            SaveOrderButton.TabIndex = 3;
            SaveOrderButton.Text = "Save";
            SaveOrderButton.UseVisualStyleBackColor = false;
            SaveOrderButton.Click += SaveOrderButton_Click;
            // 
            // EditAnnouncement_DeleteAnnouncement_Button
            // 
            EditAnnouncement_DeleteAnnouncement_Button.BackColor = Color.AliceBlue;
            EditAnnouncement_DeleteAnnouncement_Button.BackgroundImage = (Image)resources.GetObject("EditAnnouncement_DeleteAnnouncement_Button.BackgroundImage");
            EditAnnouncement_DeleteAnnouncement_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditAnnouncement_DeleteAnnouncement_Button.FlatStyle = FlatStyle.Flat;
            EditAnnouncement_DeleteAnnouncement_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditAnnouncement_DeleteAnnouncement_Button.ForeColor = Color.White;
            EditAnnouncement_DeleteAnnouncement_Button.Location = new Point(25, 656);
            EditAnnouncement_DeleteAnnouncement_Button.Name = "EditAnnouncement_DeleteAnnouncement_Button";
            EditAnnouncement_DeleteAnnouncement_Button.Size = new Size(215, 52);
            EditAnnouncement_DeleteAnnouncement_Button.TabIndex = 8;
            EditAnnouncement_DeleteAnnouncement_Button.Text = "Delete Announcement";
            EditAnnouncement_DeleteAnnouncement_Button.UseVisualStyleBackColor = true;
            EditAnnouncement_DeleteAnnouncement_Button.Visible = false;
            EditAnnouncement_DeleteAnnouncement_Button.Click += EditAnnouncement_DeleteAnnouncement_Button_Click;
            // 
            // AnnouncementsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 235, 225);
            Controls.Add(EditAnnouncement_DeleteAnnouncement_Button);
            Controls.Add(EditAnnouncements_StartOver_Button);
            Controls.Add(redorderAnnouncements_Panel);
            Controls.Add(EditAnnouncements_Main_Panel);
            Controls.Add(ModifyAnnouncements_Panel);
            Controls.Add(EditAnnouncements_Options_Panel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AnnouncementsUserControl";
            Size = new Size(1367, 728);
            EditAnnouncements_Options_Panel.ResumeLayout(false);
            EditAnnouncements_Options_Panel.PerformLayout();
            ModifyAnnouncements_Panel.ResumeLayout(false);
            EditAnnouncements_Main_Panel.ResumeLayout(false);
            EditAnnouncements_Main_Panel.PerformLayout();
            imagePreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)announcements_PictureBox).EndInit();
            redorderAnnouncements_Panel.ResumeLayout(false);
            redorderAnnouncements_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AnnouncementReorder_DataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MyButton EditAnnouncements_StartOver_Button;
        private Panel EditAnnouncements_Options_Panel;
        private MyButton LoadAnnouncement_Button;
        private MyComboBox SelectAnnouncement_ComboBox;
        private Panel ModifyAnnouncements_Panel;
        private MyButton EditAnnouncements_CreateNew_Button;
        private MyButton EditAnnouncements_EditExisting_Button;
        private MyLabel AnnouncementID_Label;
        private MyLabel AnnouncementTitle_Label;
        private MyTextBox AnnouncementTitle_TextBox;
        private MyLabel AnnouncementSub1_Label;
        private MyLabel AnnouncementSub2_Label;
        private MyTextBox AnnouncementSub1_TextBox;
        private MyTextBox AnnouncementSub2_TextBox;
        private MyLabel AnnouncementDesc_Label;
        private MyTextBox AnnouncementDesc_TextBox;
        private Panel EditAnnouncements_Main_Panel;
        private MyButton SaveAnnouncement_Button;
        private MyButton AddImage_Button;
        private MyLabel selectAnnouncement_Label;
        private Panel redorderAnnouncements_Panel;
        private MyButton SaveOrderButton;
        private DataGridView AnnouncementReorder_DataGridView;
        private DataGridViewTextBoxColumn AnnouncementName;
        private MyLabel myLabel1;
        private MyButton ReorderAnnouncementsButton;
        private MyButton EditAnnouncement_DeleteAnnouncement_Button;
        private Label ImageName_Label;
        private PictureBox announcements_PictureBox;
        private Panel imagePreviewPanel;
    }
}
