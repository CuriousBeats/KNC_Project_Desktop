namespace KNCDesktopApp
{
    partial class ExhibitsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExhibitsUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            EditExhibits_StartOver_Button = new MyButton();
            EditExhibits_Panel = new Panel();
            pdf_Panel = new Panel();
            AddNewPDF = new MyButton();
            pdf_Name_Label = new MyLabel();
            EditExhibit_Name_TextBox = new MyTextBox();
            SaveExhibit_Button = new MyButton();
            loadingBar_Panel = new Panel();
            loadingBar_Label = new MyLabel();
            image_ProgressBar = new ProgressBar();
            EditExhibit_IsCurrent_Checkbox = new MyCheckBox();
            EditExhibit_Creator_TextBox = new MyTextBox();
            EditExhibit_Creator_Label = new MyLabel();
            EditExhibit_DateCreated_TextBox = new MyTextBox();
            EditExhibit_DateCreated_Label = new MyLabel();
            EditExhibit_Name_Label = new MyLabel();
            EditExhibit_GenInfo_Label = new MyLabel();
            EditExhibits_Title_Label = new MyLabel();
            EditExhibit_DataGridView = new DataGridView();
            imagePreview = new DataGridViewImageColumn();
            fileName = new DataGridViewTextBoxColumn();
            ModifyExhibits_Panel = new Panel();
            LoadExhibit_Button = new MyButton();
            ModifyExhibit_ComboBox = new MyComboBox();
            ExhibitOptions_ComboBox = new MyComboBox();
            Modify_Label = new MyLabel();
            ExhibitOptions_Label = new MyLabel();
            EditExhibits_Options_Panel = new Panel();
            ReorderExhibitsButton = new MyButton();
            EditExhibits_CreateNewExhibit_Button = new MyButton();
            EditExhibits_ModifyExhibits_Button = new MyButton();
            ImageLoader_BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            redorderExhibits_Panel = new Panel();
            pastExhibitReorder_DataGridView = new DataGridView();
            PasExhibits = new DataGridViewTextBoxColumn();
            myLabel1 = new MyLabel();
            SaveOrderButton = new MyButton();
            currentExhibitReorder_DataGridView = new DataGridView();
            CurExhibits = new DataGridViewTextBoxColumn();
            DeleteExhibit_Button = new MyButton();
            reloadImagesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            EditExhibits_Panel.SuspendLayout();
            pdf_Panel.SuspendLayout();
            loadingBar_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EditExhibit_DataGridView).BeginInit();
            ModifyExhibits_Panel.SuspendLayout();
            EditExhibits_Options_Panel.SuspendLayout();
            redorderExhibits_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pastExhibitReorder_DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentExhibitReorder_DataGridView).BeginInit();
            SuspendLayout();
            // 
            // EditExhibits_StartOver_Button
            // 
            EditExhibits_StartOver_Button.BackColor = Color.White;
            EditExhibits_StartOver_Button.BackgroundImage = (Image)resources.GetObject("EditExhibits_StartOver_Button.BackgroundImage");
            EditExhibits_StartOver_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditExhibits_StartOver_Button.FlatStyle = FlatStyle.Flat;
            EditExhibits_StartOver_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditExhibits_StartOver_Button.ForeColor = Color.White;
            EditExhibits_StartOver_Button.Location = new Point(0, 0);
            EditExhibits_StartOver_Button.Name = "EditExhibits_StartOver_Button";
            EditExhibits_StartOver_Button.Size = new Size(270, 55);
            EditExhibits_StartOver_Button.TabIndex = 6;
            EditExhibits_StartOver_Button.Text = "Start Over";
            EditExhibits_StartOver_Button.UseVisualStyleBackColor = true;
            EditExhibits_StartOver_Button.Visible = false;
            EditExhibits_StartOver_Button.Click += EditExhibits_StartOver_Button_Click;
            // 
            // EditExhibits_Panel
            // 
            EditExhibits_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditExhibits_Panel.Controls.Add(pdf_Panel);
            EditExhibits_Panel.Controls.Add(EditExhibit_Name_TextBox);
            EditExhibits_Panel.Controls.Add(SaveExhibit_Button);
            EditExhibits_Panel.Controls.Add(loadingBar_Panel);
            EditExhibits_Panel.Controls.Add(EditExhibit_IsCurrent_Checkbox);
            EditExhibits_Panel.Controls.Add(EditExhibit_Creator_TextBox);
            EditExhibits_Panel.Controls.Add(EditExhibit_Creator_Label);
            EditExhibits_Panel.Controls.Add(EditExhibit_DateCreated_TextBox);
            EditExhibits_Panel.Controls.Add(EditExhibit_DateCreated_Label);
            EditExhibits_Panel.Controls.Add(EditExhibit_Name_Label);
            EditExhibits_Panel.Controls.Add(EditExhibit_GenInfo_Label);
            EditExhibits_Panel.Controls.Add(EditExhibits_Title_Label);
            EditExhibits_Panel.Controls.Add(EditExhibit_DataGridView);
            EditExhibits_Panel.Location = new Point(272, -1);
            EditExhibits_Panel.Margin = new Padding(0);
            EditExhibits_Panel.Name = "EditExhibits_Panel";
            EditExhibits_Panel.Size = new Size(1098, 728);
            EditExhibits_Panel.TabIndex = 5;
            EditExhibits_Panel.Visible = false;
            // 
            // pdf_Panel
            // 
            pdf_Panel.BackColor = Color.White;
            pdf_Panel.BorderStyle = BorderStyle.FixedSingle;
            pdf_Panel.Controls.Add(AddNewPDF);
            pdf_Panel.Controls.Add(pdf_Name_Label);
            pdf_Panel.Location = new Point(591, 667);
            pdf_Panel.Name = "pdf_Panel";
            pdf_Panel.Size = new Size(473, 50);
            pdf_Panel.TabIndex = 31;
            // 
            // AddNewPDF
            // 
            AddNewPDF.BackColor = Color.White;
            AddNewPDF.BackgroundImage = (Image)resources.GetObject("AddNewPDF.BackgroundImage");
            AddNewPDF.BackgroundImageLayout = ImageLayout.Stretch;
            AddNewPDF.FlatAppearance.BorderSize = 0;
            AddNewPDF.FlatStyle = FlatStyle.Flat;
            AddNewPDF.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AddNewPDF.ForeColor = Color.White;
            AddNewPDF.Location = new Point(319, 4);
            AddNewPDF.Name = "AddNewPDF";
            AddNewPDF.Size = new Size(149, 39);
            AddNewPDF.TabIndex = 29;
            AddNewPDF.Text = "Add New PDF";
            AddNewPDF.UseVisualStyleBackColor = false;
            AddNewPDF.Click += AddNewPDF_Click;
            // 
            // pdf_Name_Label
            // 
            pdf_Name_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            pdf_Name_Label.ForeColor = Color.Black;
            pdf_Name_Label.Location = new Point(18, 13);
            pdf_Name_Label.Name = "pdf_Name_Label";
            pdf_Name_Label.Size = new Size(292, 22);
            pdf_Name_Label.TabIndex = 30;
            pdf_Name_Label.Text = "PDF Name";
            pdf_Name_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditExhibit_Name_TextBox
            // 
            EditExhibit_Name_TextBox.BackColor = Color.White;
            EditExhibit_Name_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_Name_TextBox.ForeColor = Color.Black;
            EditExhibit_Name_TextBox.Location = new Point(161, 179);
            EditExhibit_Name_TextBox.Multiline = true;
            EditExhibit_Name_TextBox.Name = "EditExhibit_Name_TextBox";
            EditExhibit_Name_TextBox.ScrollBars = ScrollBars.Vertical;
            EditExhibit_Name_TextBox.Size = new Size(307, 80);
            EditExhibit_Name_TextBox.TabIndex = 28;
            // 
            // SaveExhibit_Button
            // 
            SaveExhibit_Button.BackColor = Color.White;
            SaveExhibit_Button.BackgroundImage = (Image)resources.GetObject("SaveExhibit_Button.BackgroundImage");
            SaveExhibit_Button.BackgroundImageLayout = ImageLayout.Stretch;
            SaveExhibit_Button.FlatStyle = FlatStyle.Flat;
            SaveExhibit_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SaveExhibit_Button.ForeColor = Color.White;
            SaveExhibit_Button.Location = new Point(242, 629);
            SaveExhibit_Button.Name = "SaveExhibit_Button";
            SaveExhibit_Button.Size = new Size(132, 55);
            SaveExhibit_Button.TabIndex = 27;
            SaveExhibit_Button.Text = "Save Changes";
            SaveExhibit_Button.UseVisualStyleBackColor = true;
            SaveExhibit_Button.Click += SaveExhibit_Button_Click;
            // 
            // loadingBar_Panel
            // 
            loadingBar_Panel.Controls.Add(loadingBar_Label);
            loadingBar_Panel.Controls.Add(image_ProgressBar);
            loadingBar_Panel.Location = new Point(702, 284);
            loadingBar_Panel.Name = "loadingBar_Panel";
            loadingBar_Panel.Size = new Size(250, 125);
            loadingBar_Panel.TabIndex = 17;
            // 
            // loadingBar_Label
            // 
            loadingBar_Label.AutoSize = true;
            loadingBar_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            loadingBar_Label.ForeColor = Color.Black;
            loadingBar_Label.Location = new Point(57, 11);
            loadingBar_Label.Name = "loadingBar_Label";
            loadingBar_Label.Size = new Size(144, 19);
            loadingBar_Label.TabIndex = 17;
            loadingBar_Label.Text = "Loading PDF Files";
            loadingBar_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // image_ProgressBar
            // 
            image_ProgressBar.Location = new Point(3, 42);
            image_ProgressBar.Name = "image_ProgressBar";
            image_ProgressBar.Size = new Size(244, 72);
            image_ProgressBar.TabIndex = 16;
            // 
            // EditExhibit_IsCurrent_Checkbox
            // 
            EditExhibit_IsCurrent_Checkbox.AutoSize = true;
            EditExhibit_IsCurrent_Checkbox.BackColor = Color.Transparent;
            EditExhibit_IsCurrent_Checkbox.CheckAlign = ContentAlignment.MiddleRight;
            EditExhibit_IsCurrent_Checkbox.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            EditExhibit_IsCurrent_Checkbox.ForeColor = Color.Black;
            EditExhibit_IsCurrent_Checkbox.Location = new Point(27, 284);
            EditExhibit_IsCurrent_Checkbox.Name = "EditExhibit_IsCurrent_Checkbox";
            EditExhibit_IsCurrent_Checkbox.Size = new Size(163, 22);
            EditExhibit_IsCurrent_Checkbox.TabIndex = 12;
            EditExhibit_IsCurrent_Checkbox.Text = "Is Current Exhibit?";
            EditExhibit_IsCurrent_Checkbox.UseVisualStyleBackColor = false;
            // 
            // EditExhibit_Creator_TextBox
            // 
            EditExhibit_Creator_TextBox.BackColor = Color.White;
            EditExhibit_Creator_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_Creator_TextBox.ForeColor = Color.Black;
            EditExhibit_Creator_TextBox.Location = new Point(161, 397);
            EditExhibit_Creator_TextBox.Name = "EditExhibit_Creator_TextBox";
            EditExhibit_Creator_TextBox.Size = new Size(307, 27);
            EditExhibit_Creator_TextBox.TabIndex = 7;
            // 
            // EditExhibit_Creator_Label
            // 
            EditExhibit_Creator_Label.AutoSize = true;
            EditExhibit_Creator_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_Creator_Label.ForeColor = Color.Black;
            EditExhibit_Creator_Label.Location = new Point(86, 400);
            EditExhibit_Creator_Label.Name = "EditExhibit_Creator_Label";
            EditExhibit_Creator_Label.Size = new Size(69, 19);
            EditExhibit_Creator_Label.TabIndex = 6;
            EditExhibit_Creator_Label.Text = "Creator:";
            EditExhibit_Creator_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibit_DateCreated_TextBox
            // 
            EditExhibit_DateCreated_TextBox.BackColor = Color.White;
            EditExhibit_DateCreated_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_DateCreated_TextBox.ForeColor = Color.Black;
            EditExhibit_DateCreated_TextBox.Location = new Point(161, 333);
            EditExhibit_DateCreated_TextBox.Name = "EditExhibit_DateCreated_TextBox";
            EditExhibit_DateCreated_TextBox.Size = new Size(307, 27);
            EditExhibit_DateCreated_TextBox.TabIndex = 5;
            // 
            // EditExhibit_DateCreated_Label
            // 
            EditExhibit_DateCreated_Label.AutoSize = true;
            EditExhibit_DateCreated_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_DateCreated_Label.ForeColor = Color.Black;
            EditExhibit_DateCreated_Label.Location = new Point(50, 340);
            EditExhibit_DateCreated_Label.Name = "EditExhibit_DateCreated_Label";
            EditExhibit_DateCreated_Label.Size = new Size(106, 19);
            EditExhibit_DateCreated_Label.TabIndex = 4;
            EditExhibit_DateCreated_Label.Text = "Date Created";
            EditExhibit_DateCreated_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibit_Name_Label
            // 
            EditExhibit_Name_Label.AutoSize = true;
            EditExhibit_Name_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_Name_Label.ForeColor = Color.Black;
            EditExhibit_Name_Label.Location = new Point(95, 179);
            EditExhibit_Name_Label.Name = "EditExhibit_Name_Label";
            EditExhibit_Name_Label.Size = new Size(56, 19);
            EditExhibit_Name_Label.TabIndex = 2;
            EditExhibit_Name_Label.Text = "Name:";
            EditExhibit_Name_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibit_GenInfo_Label
            // 
            EditExhibit_GenInfo_Label.AutoSize = true;
            EditExhibit_GenInfo_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibit_GenInfo_Label.ForeColor = Color.Black;
            EditExhibit_GenInfo_Label.Location = new Point(228, 146);
            EditExhibit_GenInfo_Label.Name = "EditExhibit_GenInfo_Label";
            EditExhibit_GenInfo_Label.Size = new Size(99, 19);
            EditExhibit_GenInfo_Label.TabIndex = 1;
            EditExhibit_GenInfo_Label.Text = "General Info";
            EditExhibit_GenInfo_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibits_Title_Label
            // 
            EditExhibits_Title_Label.AutoSize = true;
            EditExhibits_Title_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EditExhibits_Title_Label.ForeColor = Color.Black;
            EditExhibits_Title_Label.Location = new Point(184, 36);
            EditExhibits_Title_Label.Name = "EditExhibits_Title_Label";
            EditExhibits_Title_Label.Size = new Size(224, 19);
            EditExhibits_Title_Label.TabIndex = 0;
            EditExhibits_Title_Label.Text = "Editing \"Exhibit Name\" Exhibit";
            EditExhibits_Title_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibit_DataGridView
            // 
            EditExhibit_DataGridView.AllowUserToAddRows = false;
            EditExhibit_DataGridView.AllowUserToDeleteRows = false;
            EditExhibit_DataGridView.AllowUserToResizeColumns = false;
            EditExhibit_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            EditExhibit_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            EditExhibit_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditExhibit_DataGridView.Columns.AddRange(new DataGridViewColumn[] { imagePreview, fileName });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            EditExhibit_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            EditExhibit_DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            EditExhibit_DataGridView.Location = new Point(591, 3);
            EditExhibit_DataGridView.MultiSelect = false;
            EditExhibit_DataGridView.Name = "EditExhibit_DataGridView";
            EditExhibit_DataGridView.RowHeadersVisible = false;
            EditExhibit_DataGridView.RowHeadersWidth = 51;
            EditExhibit_DataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            EditExhibit_DataGridView.ScrollBars = ScrollBars.Vertical;
            EditExhibit_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EditExhibit_DataGridView.ShowCellErrors = false;
            EditExhibit_DataGridView.ShowEditingIcon = false;
            EditExhibit_DataGridView.Size = new Size(473, 664);
            EditExhibit_DataGridView.TabIndex = 26;
            // 
            // imagePreview
            // 
            imagePreview.HeaderText = "PDF Preview";
            imagePreview.MinimumWidth = 6;
            imagePreview.Name = "imagePreview";
            imagePreview.Width = 200;
            // 
            // fileName
            // 
            fileName.FillWeight = 200F;
            fileName.HeaderText = "Page";
            fileName.MinimumWidth = 6;
            fileName.Name = "fileName";
            fileName.SortMode = DataGridViewColumnSortMode.NotSortable;
            fileName.Width = 270;
            // 
            // ModifyExhibits_Panel
            // 
            ModifyExhibits_Panel.BackColor = Color.FromArgb(244, 235, 225);
            ModifyExhibits_Panel.Controls.Add(LoadExhibit_Button);
            ModifyExhibits_Panel.Controls.Add(ModifyExhibit_ComboBox);
            ModifyExhibits_Panel.Controls.Add(ExhibitOptions_ComboBox);
            ModifyExhibits_Panel.Controls.Add(Modify_Label);
            ModifyExhibits_Panel.Controls.Add(ExhibitOptions_Label);
            ModifyExhibits_Panel.Location = new Point(0, 57);
            ModifyExhibits_Panel.Name = "ModifyExhibits_Panel";
            ModifyExhibits_Panel.Size = new Size(1370, 587);
            ModifyExhibits_Panel.TabIndex = 4;
            ModifyExhibits_Panel.Visible = false;
            // 
            // LoadExhibit_Button
            // 
            LoadExhibit_Button.BackColor = Color.White;
            LoadExhibit_Button.BackgroundImage = (Image)resources.GetObject("LoadExhibit_Button.BackgroundImage");
            LoadExhibit_Button.BackgroundImageLayout = ImageLayout.Stretch;
            LoadExhibit_Button.FlatStyle = FlatStyle.Flat;
            LoadExhibit_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LoadExhibit_Button.ForeColor = Color.White;
            LoadExhibit_Button.Location = new Point(585, 381);
            LoadExhibit_Button.Name = "LoadExhibit_Button";
            LoadExhibit_Button.Size = new Size(195, 71);
            LoadExhibit_Button.TabIndex = 2;
            LoadExhibit_Button.Text = "Load Exhibit Info";
            LoadExhibit_Button.UseVisualStyleBackColor = true;
            LoadExhibit_Button.Click += LoadExhibit_Button_Click;
            // 
            // ModifyExhibit_ComboBox
            // 
            ModifyExhibit_ComboBox.BackColor = Color.White;
            ModifyExhibit_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ModifyExhibit_ComboBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ModifyExhibit_ComboBox.ForeColor = Color.Black;
            ModifyExhibit_ComboBox.FormattingEnabled = true;
            ModifyExhibit_ComboBox.IntegralHeight = false;
            ModifyExhibit_ComboBox.Items.AddRange(new object[] { "Current", "Past" });
            ModifyExhibit_ComboBox.Location = new Point(554, 159);
            ModifyExhibit_ComboBox.Name = "ModifyExhibit_ComboBox";
            ModifyExhibit_ComboBox.Size = new Size(266, 27);
            ModifyExhibit_ComboBox.TabIndex = 1;
            ModifyExhibit_ComboBox.SelectionChangeCommitted += ModifyExhibit_ComboBox_SelectionChangeCommitted;
            // 
            // ExhibitOptions_ComboBox
            // 
            ExhibitOptions_ComboBox.BackColor = Color.White;
            ExhibitOptions_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ExhibitOptions_ComboBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ExhibitOptions_ComboBox.ForeColor = Color.Black;
            ExhibitOptions_ComboBox.FormattingEnabled = true;
            ExhibitOptions_ComboBox.IntegralHeight = false;
            ExhibitOptions_ComboBox.Items.AddRange(new object[] { "#1", "#2", "#3" });
            ExhibitOptions_ComboBox.Location = new Point(529, 313);
            ExhibitOptions_ComboBox.Name = "ExhibitOptions_ComboBox";
            ExhibitOptions_ComboBox.Size = new Size(317, 27);
            ExhibitOptions_ComboBox.TabIndex = 1;
            ExhibitOptions_ComboBox.SelectionChangeCommitted += ExhibitOptions_ComboBox_SelectionChangeCommitted;
            // 
            // Modify_Label
            // 
            Modify_Label.AutoSize = true;
            Modify_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Modify_Label.ForeColor = Color.Black;
            Modify_Label.Location = new Point(572, 121);
            Modify_Label.Name = "Modify_Label";
            Modify_Label.Size = new Size(228, 19);
            Modify_Label.TabIndex = 0;
            Modify_Label.Text = "Modify Current or Past Exhibit";
            Modify_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ExhibitOptions_Label
            // 
            ExhibitOptions_Label.AutoSize = true;
            ExhibitOptions_Label.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ExhibitOptions_Label.ForeColor = Color.Black;
            ExhibitOptions_Label.Location = new Point(556, 268);
            ExhibitOptions_Label.Name = "ExhibitOptions_Label";
            ExhibitOptions_Label.Size = new Size(266, 19);
            ExhibitOptions_Label.TabIndex = 0;
            ExhibitOptions_Label.Text = "Which Exhibit would you like to edit";
            ExhibitOptions_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditExhibits_Options_Panel
            // 
            EditExhibits_Options_Panel.BackColor = Color.FromArgb(244, 235, 225);
            EditExhibits_Options_Panel.Controls.Add(ReorderExhibitsButton);
            EditExhibits_Options_Panel.Controls.Add(EditExhibits_CreateNewExhibit_Button);
            EditExhibits_Options_Panel.Controls.Add(EditExhibits_ModifyExhibits_Button);
            EditExhibits_Options_Panel.Location = new Point(0, 57);
            EditExhibits_Options_Panel.Name = "EditExhibits_Options_Panel";
            EditExhibits_Options_Panel.Size = new Size(1367, 587);
            EditExhibits_Options_Panel.TabIndex = 7;
            // 
            // ReorderExhibitsButton
            // 
            ReorderExhibitsButton.BackColor = Color.White;
            ReorderExhibitsButton.BackgroundImage = (Image)resources.GetObject("ReorderExhibitsButton.BackgroundImage");
            ReorderExhibitsButton.BackgroundImageLayout = ImageLayout.Stretch;
            ReorderExhibitsButton.FlatAppearance.BorderSize = 0;
            ReorderExhibitsButton.FlatStyle = FlatStyle.Flat;
            ReorderExhibitsButton.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            ReorderExhibitsButton.ForeColor = Color.White;
            ReorderExhibitsButton.Location = new Point(567, 287);
            ReorderExhibitsButton.Name = "ReorderExhibitsButton";
            ReorderExhibitsButton.Size = new Size(231, 60);
            ReorderExhibitsButton.TabIndex = 2;
            ReorderExhibitsButton.Text = "Reorder Exhibits";
            ReorderExhibitsButton.UseVisualStyleBackColor = false;
            ReorderExhibitsButton.Click += ReorderExhibitsButton_Click;
            // 
            // EditExhibits_CreateNewExhibit_Button
            // 
            EditExhibits_CreateNewExhibit_Button.BackColor = Color.White;
            EditExhibits_CreateNewExhibit_Button.BackgroundImage = (Image)resources.GetObject("EditExhibits_CreateNewExhibit_Button.BackgroundImage");
            EditExhibits_CreateNewExhibit_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditExhibits_CreateNewExhibit_Button.FlatStyle = FlatStyle.Flat;
            EditExhibits_CreateNewExhibit_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditExhibits_CreateNewExhibit_Button.ForeColor = Color.White;
            EditExhibits_CreateNewExhibit_Button.Location = new Point(567, 391);
            EditExhibits_CreateNewExhibit_Button.Name = "EditExhibits_CreateNewExhibit_Button";
            EditExhibits_CreateNewExhibit_Button.Size = new Size(231, 60);
            EditExhibits_CreateNewExhibit_Button.TabIndex = 1;
            EditExhibits_CreateNewExhibit_Button.Text = "Create New Exhibit";
            EditExhibits_CreateNewExhibit_Button.UseVisualStyleBackColor = true;
            EditExhibits_CreateNewExhibit_Button.Click += EditExhibits_CreateNewExhibit_Button_Click;
            // 
            // EditExhibits_ModifyExhibits_Button
            // 
            EditExhibits_ModifyExhibits_Button.BackColor = Color.White;
            EditExhibits_ModifyExhibits_Button.BackgroundImage = (Image)resources.GetObject("EditExhibits_ModifyExhibits_Button.BackgroundImage");
            EditExhibits_ModifyExhibits_Button.BackgroundImageLayout = ImageLayout.Stretch;
            EditExhibits_ModifyExhibits_Button.FlatStyle = FlatStyle.Flat;
            EditExhibits_ModifyExhibits_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditExhibits_ModifyExhibits_Button.ForeColor = Color.White;
            EditExhibits_ModifyExhibits_Button.Location = new Point(567, 185);
            EditExhibits_ModifyExhibits_Button.Name = "EditExhibits_ModifyExhibits_Button";
            EditExhibits_ModifyExhibits_Button.Size = new Size(231, 60);
            EditExhibits_ModifyExhibits_Button.TabIndex = 0;
            EditExhibits_ModifyExhibits_Button.Text = "Modify Existing Exhibit";
            EditExhibits_ModifyExhibits_Button.UseVisualStyleBackColor = true;
            EditExhibits_ModifyExhibits_Button.Click += EditExhibits_ModifyExhibits_Button_Click;
            // 
            // ImageLoader_BackgroundWorker
            // 
            ImageLoader_BackgroundWorker.WorkerReportsProgress = true;
            ImageLoader_BackgroundWorker.DoWork += ImageLoader_BackgroundWorker_DoWork;
            ImageLoader_BackgroundWorker.ProgressChanged += ImageLoader_BackgroundWorker_ProgressChanged;
            ImageLoader_BackgroundWorker.RunWorkerCompleted += ImageLoader_BackgroundWorker_RunWorkerCompleted;
            // 
            // redorderExhibits_Panel
            // 
            redorderExhibits_Panel.BackColor = Color.FromArgb(244, 235, 225);
            redorderExhibits_Panel.Controls.Add(pastExhibitReorder_DataGridView);
            redorderExhibits_Panel.Controls.Add(myLabel1);
            redorderExhibits_Panel.Controls.Add(SaveOrderButton);
            redorderExhibits_Panel.Controls.Add(currentExhibitReorder_DataGridView);
            redorderExhibits_Panel.Location = new Point(263, 49);
            redorderExhibits_Panel.Name = "redorderExhibits_Panel";
            redorderExhibits_Panel.Size = new Size(1082, 675);
            redorderExhibits_Panel.TabIndex = 14;
            redorderExhibits_Panel.Visible = false;
            // 
            // pastExhibitReorder_DataGridView
            // 
            pastExhibitReorder_DataGridView.AllowDrop = true;
            pastExhibitReorder_DataGridView.AllowUserToAddRows = false;
            pastExhibitReorder_DataGridView.AllowUserToDeleteRows = false;
            pastExhibitReorder_DataGridView.AllowUserToResizeColumns = false;
            pastExhibitReorder_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            pastExhibitReorder_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            pastExhibitReorder_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pastExhibitReorder_DataGridView.Columns.AddRange(new DataGridViewColumn[] { PasExhibits });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            pastExhibitReorder_DataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            pastExhibitReorder_DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            pastExhibitReorder_DataGridView.Location = new Point(483, 64);
            pastExhibitReorder_DataGridView.MultiSelect = false;
            pastExhibitReorder_DataGridView.Name = "pastExhibitReorder_DataGridView";
            pastExhibitReorder_DataGridView.RowHeadersVisible = false;
            pastExhibitReorder_DataGridView.RowHeadersWidth = 51;
            pastExhibitReorder_DataGridView.ScrollBars = ScrollBars.Vertical;
            pastExhibitReorder_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pastExhibitReorder_DataGridView.Size = new Size(400, 541);
            pastExhibitReorder_DataGridView.TabIndex = 28;
            pastExhibitReorder_DataGridView.DragDrop += pastExhibits_DataGridView_DragDrop;
            pastExhibitReorder_DataGridView.DragOver += pastExhibits_DataGridView_DragOver;
            pastExhibitReorder_DataGridView.MouseDown += pastExhibits_DataGridView_MouseDown;
            pastExhibitReorder_DataGridView.MouseMove += pastExhibits_DataGridView_MouseMove;
            // 
            // PasExhibits
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            PasExhibits.DefaultCellStyle = dataGridViewCellStyle4;
            PasExhibits.HeaderText = "Past Exhibits";
            PasExhibits.MinimumWidth = 6;
            PasExhibits.Name = "PasExhibits";
            PasExhibits.Width = 400;
            // 
            // myLabel1
            // 
            myLabel1.AutoSize = true;
            myLabel1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            myLabel1.ForeColor = Color.Black;
            myLabel1.Location = new Point(317, 24);
            myLabel1.Name = "myLabel1";
            myLabel1.Size = new Size(266, 19);
            myLabel1.TabIndex = 27;
            myLabel1.Text = "Drag and Drop the Announcements";
            myLabel1.TextAlign = ContentAlignment.MiddleLeft;
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
            SaveOrderButton.Location = new Point(897, 597);
            SaveOrderButton.Name = "SaveOrderButton";
            SaveOrderButton.Size = new Size(176, 65);
            SaveOrderButton.TabIndex = 3;
            SaveOrderButton.Text = "Save";
            SaveOrderButton.UseVisualStyleBackColor = false;
            SaveOrderButton.Click += SaveOrderButton_Click;
            // 
            // currentExhibitReorder_DataGridView
            // 
            currentExhibitReorder_DataGridView.AllowDrop = true;
            currentExhibitReorder_DataGridView.AllowUserToAddRows = false;
            currentExhibitReorder_DataGridView.AllowUserToDeleteRows = false;
            currentExhibitReorder_DataGridView.AllowUserToResizeColumns = false;
            currentExhibitReorder_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            currentExhibitReorder_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            currentExhibitReorder_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currentExhibitReorder_DataGridView.Columns.AddRange(new DataGridViewColumn[] { CurExhibits });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            currentExhibitReorder_DataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            currentExhibitReorder_DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            currentExhibitReorder_DataGridView.Location = new Point(36, 64);
            currentExhibitReorder_DataGridView.MultiSelect = false;
            currentExhibitReorder_DataGridView.Name = "currentExhibitReorder_DataGridView";
            currentExhibitReorder_DataGridView.RowHeadersVisible = false;
            currentExhibitReorder_DataGridView.RowHeadersWidth = 51;
            currentExhibitReorder_DataGridView.ScrollBars = ScrollBars.Vertical;
            currentExhibitReorder_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            currentExhibitReorder_DataGridView.Size = new Size(400, 541);
            currentExhibitReorder_DataGridView.TabIndex = 26;
            currentExhibitReorder_DataGridView.DragDrop += currentExhibitReorder_DataGridView_DragDrop;
            currentExhibitReorder_DataGridView.DragOver += currentExhibitReorder_DataGridView_DragOver;
            currentExhibitReorder_DataGridView.MouseDown += currentExhibitReorder_DataGridView_MouseDown;
            currentExhibitReorder_DataGridView.MouseMove += currentExhibitReorder_DataGridView_MouseMove;
            // 
            // CurExhibits
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            CurExhibits.DefaultCellStyle = dataGridViewCellStyle7;
            CurExhibits.HeaderText = "Current Exhibits";
            CurExhibits.MinimumWidth = 6;
            CurExhibits.Name = "CurExhibits";
            CurExhibits.Width = 400;
            // 
            // DeleteExhibit_Button
            // 
            DeleteExhibit_Button.BackColor = Color.White;
            DeleteExhibit_Button.BackgroundImage = (Image)resources.GetObject("DeleteExhibit_Button.BackgroundImage");
            DeleteExhibit_Button.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteExhibit_Button.FlatStyle = FlatStyle.Flat;
            DeleteExhibit_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteExhibit_Button.ForeColor = Color.White;
            DeleteExhibit_Button.Location = new Point(29, 650);
            DeleteExhibit_Button.Name = "DeleteExhibit_Button";
            DeleteExhibit_Button.Size = new Size(190, 55);
            DeleteExhibit_Button.TabIndex = 28;
            DeleteExhibit_Button.Text = "Delete Exhibit";
            DeleteExhibit_Button.UseVisualStyleBackColor = true;
            DeleteExhibit_Button.Visible = false;
            DeleteExhibit_Button.Click += DeleteExhibit_Button_Click;
            // 
            // reloadImagesBackgroundWorker
            // 
            reloadImagesBackgroundWorker.WorkerReportsProgress = true;
            reloadImagesBackgroundWorker.DoWork += reloadImagesBackgroundWorker_DoWork;
            reloadImagesBackgroundWorker.ProgressChanged += reloadImagesBackgroundWorker_ProgressChanged;
            reloadImagesBackgroundWorker.RunWorkerCompleted += reloadImagesBackgroundWorker_RunWorkerCompleted;
            // 
            // ExhibitsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 235, 225);
            Controls.Add(DeleteExhibit_Button);
            Controls.Add(EditExhibits_StartOver_Button);
            Controls.Add(ModifyExhibits_Panel);
            Controls.Add(EditExhibits_Options_Panel);
            Controls.Add(EditExhibits_Panel);
            Controls.Add(redorderExhibits_Panel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ExhibitsUserControl";
            Size = new Size(1367, 728);
            EditExhibits_Panel.ResumeLayout(false);
            EditExhibits_Panel.PerformLayout();
            pdf_Panel.ResumeLayout(false);
            loadingBar_Panel.ResumeLayout(false);
            loadingBar_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EditExhibit_DataGridView).EndInit();
            ModifyExhibits_Panel.ResumeLayout(false);
            ModifyExhibits_Panel.PerformLayout();
            EditExhibits_Options_Panel.ResumeLayout(false);
            redorderExhibits_Panel.ResumeLayout(false);
            redorderExhibits_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pastExhibitReorder_DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentExhibitReorder_DataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MyButton EditExhibits_StartOver_Button;
        private Panel EditExhibits_Panel;
        private MyCheckBox EditExhibit_IsCurrent_Checkbox;
        private MyTextBox EditExhibit_Creator_TextBox;
        private MyLabel EditExhibit_Creator_Label;
        private MyTextBox EditExhibit_DateCreated_TextBox;
        private MyLabel EditExhibit_DateCreated_Label;
        private MyLabel EditExhibit_Name_Label;
        private MyLabel EditExhibit_GenInfo_Label;
        private MyLabel EditExhibits_Title_Label;
        private Panel ModifyExhibits_Panel;
        private MyButton LoadExhibit_Button;
        private MyComboBox ModifyExhibit_ComboBox;
        private MyComboBox ExhibitOptions_ComboBox;
        private MyLabel Modify_Label;
        private MyLabel ExhibitOptions_Label;
        private Panel EditExhibits_Options_Panel;
        private MyButton EditExhibits_CreateNewExhibit_Button;
        private MyButton EditExhibits_ModifyExhibits_Button;
        private System.ComponentModel.BackgroundWorker ImageLoader_BackgroundWorker;
        private ProgressBar image_ProgressBar;
        private Panel loadingBar_Panel;
        private MyLabel loadingBar_Label;
        private DataGridView EditExhibit_DataGridView;
        private MyButton SaveExhibit_Button;
        private MyTextBox EditExhibit_Name_TextBox;
        private MyButton AddNewPDF;
        private MyButton ReorderExhibitsButton;
        private Panel redorderExhibits_Panel;
        private MyLabel myLabel1;
        private DataGridView currentExhibitReorder_DataGridView;
        private MyButton SaveOrderButton;
        private DataGridView pastExhibitReorder_DataGridView;
        private DataGridViewTextBoxColumn PasExhibits;
        private DataGridViewTextBoxColumn CurExhibits;
        private MyButton DeleteExhibit_Button;
        private MyLabel pdf_Name_Label;
        private Panel pdf_Panel;
        private System.ComponentModel.BackgroundWorker reloadImagesBackgroundWorker;
        private DataGridViewImageColumn imagePreview;
        private DataGridViewTextBoxColumn fileName;
    }
}
