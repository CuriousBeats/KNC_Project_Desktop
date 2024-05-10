namespace KNCDesktopApp
{
    partial class HelpUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpUserControl));
            help_Start_Panel = new Panel();
            help_AddContact_Button = new MyButton();
            help_EditContacts_Button = new MyButton();
            help_EditAddress_Button = new MyButton();
            help_StartOver_Button = new MyButton();
            help_Address_Panel = new Panel();
            address_State_TextBox = new MyTextBox();
            address_State_Label = new MyLabel();
            address_Save_Button = new MyButton();
            myLabel6 = new MyLabel();
            address_Zip_TextBox = new MyTextBox();
            address_City_TextBox = new MyTextBox();
            address_Street_TextBox = new MyTextBox();
            address_Name_TextBox = new MyTextBox();
            address_Zip_Label = new MyLabel();
            Address_City_Label = new MyLabel();
            address_Street_Label = new MyLabel();
            address_Name_Label = new MyLabel();
            address_ID_Label = new MyLabel();
            help_ContactsOptions_Panel = new Panel();
            load_Contact_Button = new MyButton();
            contact_Select_Label = new MyLabel();
            select_Contact_ComboBox = new MyComboBox();
            edit_Contact_Panel = new Panel();
            deleteContact_Button = new MyButton();
            contact_Position_TextBox = new MyTextBox();
            contact_Position_Label = new MyLabel();
            save_Contact_Button = new MyButton();
            editContact_Label = new MyLabel();
            contact_Email_TextBox = new MyTextBox();
            contact_Phone_TextBox = new MyTextBox();
            contact_Name_TextBox = new MyTextBox();
            contact_Email_Label = new MyLabel();
            contact_Phone_Label = new MyLabel();
            contact_Name_Label = new MyLabel();
            contact_Id_Label = new MyLabel();
            help_Start_Panel.SuspendLayout();
            help_Address_Panel.SuspendLayout();
            help_ContactsOptions_Panel.SuspendLayout();
            edit_Contact_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // help_Start_Panel
            // 
            help_Start_Panel.BackColor = Color.FromArgb(244, 235, 225);
            help_Start_Panel.Controls.Add(help_AddContact_Button);
            help_Start_Panel.Controls.Add(help_EditContacts_Button);
            help_Start_Panel.Controls.Add(help_EditAddress_Button);
            help_Start_Panel.Location = new Point(3, 92);
            help_Start_Panel.Name = "help_Start_Panel";
            help_Start_Panel.Size = new Size(1361, 516);
            help_Start_Panel.TabIndex = 0;
            // 
            // help_AddContact_Button
            // 
            help_AddContact_Button.BackColor = Color.White;
            help_AddContact_Button.BackgroundImage = (Image)resources.GetObject("help_AddContact_Button.BackgroundImage");
            help_AddContact_Button.BackgroundImageLayout = ImageLayout.Stretch;
            help_AddContact_Button.FlatAppearance.BorderSize = 0;
            help_AddContact_Button.FlatStyle = FlatStyle.Flat;
            help_AddContact_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            help_AddContact_Button.ForeColor = Color.White;
            help_AddContact_Button.Location = new Point(546, 363);
            help_AddContact_Button.Name = "help_AddContact_Button";
            help_AddContact_Button.Size = new Size(258, 55);
            help_AddContact_Button.TabIndex = 4;
            help_AddContact_Button.Text = "Add Contact";
            help_AddContact_Button.UseVisualStyleBackColor = false;
            help_AddContact_Button.Click += help_AddContact_Button_Click;
            // 
            // help_EditContacts_Button
            // 
            help_EditContacts_Button.BackColor = Color.White;
            help_EditContacts_Button.BackgroundImage = (Image)resources.GetObject("help_EditContacts_Button.BackgroundImage");
            help_EditContacts_Button.BackgroundImageLayout = ImageLayout.Stretch;
            help_EditContacts_Button.FlatAppearance.BorderSize = 0;
            help_EditContacts_Button.FlatStyle = FlatStyle.Flat;
            help_EditContacts_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            help_EditContacts_Button.ForeColor = Color.White;
            help_EditContacts_Button.Location = new Point(546, 264);
            help_EditContacts_Button.Name = "help_EditContacts_Button";
            help_EditContacts_Button.Size = new Size(258, 53);
            help_EditContacts_Button.TabIndex = 3;
            help_EditContacts_Button.Text = "Edit Contacts";
            help_EditContacts_Button.UseVisualStyleBackColor = false;
            help_EditContacts_Button.Click += help_EditContacts_Button_Click;
            // 
            // help_EditAddress_Button
            // 
            help_EditAddress_Button.BackColor = Color.White;
            help_EditAddress_Button.BackgroundImage = (Image)resources.GetObject("help_EditAddress_Button.BackgroundImage");
            help_EditAddress_Button.BackgroundImageLayout = ImageLayout.Stretch;
            help_EditAddress_Button.FlatAppearance.BorderSize = 0;
            help_EditAddress_Button.FlatStyle = FlatStyle.Flat;
            help_EditAddress_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            help_EditAddress_Button.ForeColor = Color.White;
            help_EditAddress_Button.Location = new Point(546, 159);
            help_EditAddress_Button.Name = "help_EditAddress_Button";
            help_EditAddress_Button.Size = new Size(258, 59);
            help_EditAddress_Button.TabIndex = 1;
            help_EditAddress_Button.Text = "Edit Address";
            help_EditAddress_Button.UseVisualStyleBackColor = false;
            help_EditAddress_Button.Click += help_EditAddress_Button_Click;
            // 
            // help_StartOver_Button
            // 
            help_StartOver_Button.BackColor = Color.White;
            help_StartOver_Button.BackgroundImage = (Image)resources.GetObject("help_StartOver_Button.BackgroundImage");
            help_StartOver_Button.BackgroundImageLayout = ImageLayout.Stretch;
            help_StartOver_Button.FlatAppearance.BorderSize = 0;
            help_StartOver_Button.FlatStyle = FlatStyle.Flat;
            help_StartOver_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            help_StartOver_Button.ForeColor = Color.White;
            help_StartOver_Button.Location = new Point(0, 0);
            help_StartOver_Button.Name = "help_StartOver_Button";
            help_StartOver_Button.Size = new Size(270, 55);
            help_StartOver_Button.TabIndex = 1;
            help_StartOver_Button.Text = "Start Over";
            help_StartOver_Button.UseVisualStyleBackColor = false;
            help_StartOver_Button.Visible = false;
            help_StartOver_Button.Click += help_StartOver_Button_Click;
            // 
            // help_Address_Panel
            // 
            help_Address_Panel.BackColor = Color.FromArgb(244, 235, 225);
            help_Address_Panel.Controls.Add(address_State_TextBox);
            help_Address_Panel.Controls.Add(address_State_Label);
            help_Address_Panel.Controls.Add(address_Save_Button);
            help_Address_Panel.Controls.Add(myLabel6);
            help_Address_Panel.Controls.Add(address_Zip_TextBox);
            help_Address_Panel.Controls.Add(address_City_TextBox);
            help_Address_Panel.Controls.Add(address_Street_TextBox);
            help_Address_Panel.Controls.Add(address_Name_TextBox);
            help_Address_Panel.Controls.Add(address_Zip_Label);
            help_Address_Panel.Controls.Add(Address_City_Label);
            help_Address_Panel.Controls.Add(address_Street_Label);
            help_Address_Panel.Controls.Add(address_Name_Label);
            help_Address_Panel.Controls.Add(address_ID_Label);
            help_Address_Panel.Location = new Point(0, 61);
            help_Address_Panel.Name = "help_Address_Panel";
            help_Address_Panel.Size = new Size(1367, 649);
            help_Address_Panel.TabIndex = 2;
            help_Address_Panel.Visible = false;
            // 
            // address_State_TextBox
            // 
            address_State_TextBox.BackColor = Color.White;
            address_State_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address_State_TextBox.ForeColor = Color.Black;
            address_State_TextBox.Location = new Point(473, 379);
            address_State_TextBox.Name = "address_State_TextBox";
            address_State_TextBox.Size = new Size(411, 27);
            address_State_TextBox.TabIndex = 8;
            // 
            // address_State_Label
            // 
            address_State_Label.AutoSize = true;
            address_State_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            address_State_Label.ForeColor = Color.Black;
            address_State_Label.Location = new Point(419, 383);
            address_State_Label.Name = "address_State_Label";
            address_State_Label.Size = new Size(49, 18);
            address_State_Label.TabIndex = 11;
            address_State_Label.Text = "State:";
            address_State_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address_Save_Button
            // 
            address_Save_Button.BackColor = Color.White;
            address_Save_Button.BackgroundImage = (Image)resources.GetObject("address_Save_Button.BackgroundImage");
            address_Save_Button.BackgroundImageLayout = ImageLayout.Stretch;
            address_Save_Button.FlatAppearance.BorderSize = 0;
            address_Save_Button.FlatStyle = FlatStyle.Flat;
            address_Save_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            address_Save_Button.ForeColor = Color.White;
            address_Save_Button.Location = new Point(592, 529);
            address_Save_Button.Name = "address_Save_Button";
            address_Save_Button.Size = new Size(150, 71);
            address_Save_Button.TabIndex = 10;
            address_Save_Button.Text = "Save Changes";
            address_Save_Button.UseVisualStyleBackColor = false;
            address_Save_Button.Click += address_Save_Button_Click;
            // 
            // myLabel6
            // 
            myLabel6.AutoSize = true;
            myLabel6.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            myLabel6.ForeColor = Color.Black;
            myLabel6.Location = new Point(586, 31);
            myLabel6.Name = "myLabel6";
            myLabel6.Size = new Size(156, 18);
            myLabel6.TabIndex = 9;
            myLabel6.Text = "Editing KNC Address";
            myLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address_Zip_TextBox
            // 
            address_Zip_TextBox.BackColor = Color.White;
            address_Zip_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address_Zip_TextBox.ForeColor = Color.Black;
            address_Zip_TextBox.Location = new Point(474, 420);
            address_Zip_TextBox.Name = "address_Zip_TextBox";
            address_Zip_TextBox.Size = new Size(410, 27);
            address_Zip_TextBox.TabIndex = 9;
            // 
            // address_City_TextBox
            // 
            address_City_TextBox.BackColor = Color.White;
            address_City_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address_City_TextBox.ForeColor = Color.Black;
            address_City_TextBox.Location = new Point(474, 333);
            address_City_TextBox.Name = "address_City_TextBox";
            address_City_TextBox.Size = new Size(410, 27);
            address_City_TextBox.TabIndex = 7;
            // 
            // address_Street_TextBox
            // 
            address_Street_TextBox.BackColor = Color.White;
            address_Street_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address_Street_TextBox.ForeColor = Color.Black;
            address_Street_TextBox.Location = new Point(474, 282);
            address_Street_TextBox.Name = "address_Street_TextBox";
            address_Street_TextBox.Size = new Size(410, 27);
            address_Street_TextBox.TabIndex = 6;
            // 
            // address_Name_TextBox
            // 
            address_Name_TextBox.BackColor = Color.White;
            address_Name_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address_Name_TextBox.ForeColor = Color.Black;
            address_Name_TextBox.Location = new Point(474, 232);
            address_Name_TextBox.Name = "address_Name_TextBox";
            address_Name_TextBox.Size = new Size(410, 27);
            address_Name_TextBox.TabIndex = 5;
            // 
            // address_Zip_Label
            // 
            address_Zip_Label.AutoSize = true;
            address_Zip_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            address_Zip_Label.ForeColor = Color.Black;
            address_Zip_Label.Location = new Point(434, 424);
            address_Zip_Label.Name = "address_Zip_Label";
            address_Zip_Label.Size = new Size(33, 18);
            address_Zip_Label.TabIndex = 4;
            address_Zip_Label.Text = "Zip:";
            address_Zip_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Address_City_Label
            // 
            Address_City_Label.AutoSize = true;
            Address_City_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Address_City_Label.ForeColor = Color.Black;
            Address_City_Label.Location = new Point(428, 337);
            Address_City_Label.Name = "Address_City_Label";
            Address_City_Label.Size = new Size(39, 18);
            Address_City_Label.TabIndex = 3;
            Address_City_Label.Text = "City:";
            Address_City_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address_Street_Label
            // 
            address_Street_Label.AutoSize = true;
            address_Street_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            address_Street_Label.ForeColor = Color.Black;
            address_Street_Label.Location = new Point(411, 286);
            address_Street_Label.Name = "address_Street_Label";
            address_Street_Label.Size = new Size(56, 18);
            address_Street_Label.TabIndex = 2;
            address_Street_Label.Text = "Street:";
            address_Street_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address_Name_Label
            // 
            address_Name_Label.AutoSize = true;
            address_Name_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            address_Name_Label.ForeColor = Color.Black;
            address_Name_Label.Location = new Point(416, 236);
            address_Name_Label.Name = "address_Name_Label";
            address_Name_Label.Size = new Size(52, 18);
            address_Name_Label.TabIndex = 1;
            address_Name_Label.Text = "Name:";
            address_Name_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address_ID_Label
            // 
            address_ID_Label.AutoSize = true;
            address_ID_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            address_ID_Label.ForeColor = Color.Black;
            address_ID_Label.Location = new Point(434, 179);
            address_ID_Label.Name = "address_ID_Label";
            address_ID_Label.Size = new Size(52, 18);
            address_ID_Label.TabIndex = 0;
            address_ID_Label.Text = "Id = \"\"";
            address_ID_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // help_ContactsOptions_Panel
            // 
            help_ContactsOptions_Panel.BackColor = Color.FromArgb(244, 235, 225);
            help_ContactsOptions_Panel.Controls.Add(load_Contact_Button);
            help_ContactsOptions_Panel.Controls.Add(contact_Select_Label);
            help_ContactsOptions_Panel.Controls.Add(select_Contact_ComboBox);
            help_ContactsOptions_Panel.Location = new Point(6, 64);
            help_ContactsOptions_Panel.Name = "help_ContactsOptions_Panel";
            help_ContactsOptions_Panel.Size = new Size(1361, 520);
            help_ContactsOptions_Panel.TabIndex = 3;
            help_ContactsOptions_Panel.Visible = false;
            // 
            // load_Contact_Button
            // 
            load_Contact_Button.BackColor = Color.White;
            load_Contact_Button.BackgroundImage = (Image)resources.GetObject("load_Contact_Button.BackgroundImage");
            load_Contact_Button.BackgroundImageLayout = ImageLayout.Stretch;
            load_Contact_Button.FlatAppearance.BorderSize = 0;
            load_Contact_Button.FlatStyle = FlatStyle.Flat;
            load_Contact_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            load_Contact_Button.ForeColor = Color.White;
            load_Contact_Button.Location = new Point(588, 362);
            load_Contact_Button.Name = "load_Contact_Button";
            load_Contact_Button.Size = new Size(182, 70);
            load_Contact_Button.TabIndex = 2;
            load_Contact_Button.Text = "Load Contact Info";
            load_Contact_Button.UseVisualStyleBackColor = false;
            load_Contact_Button.Visible = false;
            load_Contact_Button.Click += load_Contact_Button_Click;
            // 
            // contact_Select_Label
            // 
            contact_Select_Label.AutoSize = true;
            contact_Select_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Select_Label.ForeColor = Color.Black;
            contact_Select_Label.Location = new Point(600, 196);
            contact_Select_Label.Name = "contact_Select_Label";
            contact_Select_Label.Size = new Size(170, 18);
            contact_Select_Label.TabIndex = 1;
            contact_Select_Label.Text = "Select a contact to edit";
            contact_Select_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // select_Contact_ComboBox
            // 
            select_Contact_ComboBox.BackColor = Color.White;
            select_Contact_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            select_Contact_ComboBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            select_Contact_ComboBox.ForeColor = Color.Black;
            select_Contact_ComboBox.FormattingEnabled = true;
            select_Contact_ComboBox.IntegralHeight = false;
            select_Contact_ComboBox.Location = new Point(489, 228);
            select_Contact_ComboBox.Name = "select_Contact_ComboBox";
            select_Contact_ComboBox.Size = new Size(389, 27);
            select_Contact_ComboBox.TabIndex = 0;
            select_Contact_ComboBox.SelectionChangeCommitted += select_Contact_ComboBox_SelectionChangeCommitted;
            // 
            // edit_Contact_Panel
            // 
            edit_Contact_Panel.BackColor = Color.FromArgb(244, 235, 225);
            edit_Contact_Panel.Controls.Add(deleteContact_Button);
            edit_Contact_Panel.Controls.Add(contact_Position_TextBox);
            edit_Contact_Panel.Controls.Add(contact_Position_Label);
            edit_Contact_Panel.Controls.Add(save_Contact_Button);
            edit_Contact_Panel.Controls.Add(editContact_Label);
            edit_Contact_Panel.Controls.Add(contact_Email_TextBox);
            edit_Contact_Panel.Controls.Add(contact_Phone_TextBox);
            edit_Contact_Panel.Controls.Add(contact_Name_TextBox);
            edit_Contact_Panel.Controls.Add(contact_Email_Label);
            edit_Contact_Panel.Controls.Add(contact_Phone_Label);
            edit_Contact_Panel.Controls.Add(contact_Name_Label);
            edit_Contact_Panel.Controls.Add(contact_Id_Label);
            edit_Contact_Panel.Location = new Point(3, 56);
            edit_Contact_Panel.Name = "edit_Contact_Panel";
            edit_Contact_Panel.Size = new Size(1364, 654);
            edit_Contact_Panel.TabIndex = 4;
            edit_Contact_Panel.Visible = false;
            // 
            // deleteContact_Button
            // 
            deleteContact_Button.BackColor = Color.White;
            deleteContact_Button.BackgroundImage = (Image)resources.GetObject("deleteContact_Button.BackgroundImage");
            deleteContact_Button.BackgroundImageLayout = ImageLayout.Stretch;
            deleteContact_Button.FlatAppearance.BorderSize = 0;
            deleteContact_Button.FlatStyle = FlatStyle.Flat;
            deleteContact_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            deleteContact_Button.ForeColor = Color.White;
            deleteContact_Button.Location = new Point(50, 514);
            deleteContact_Button.Name = "deleteContact_Button";
            deleteContact_Button.Size = new Size(173, 77);
            deleteContact_Button.TabIndex = 13;
            deleteContact_Button.Text = "Delete Contact";
            deleteContact_Button.UseVisualStyleBackColor = false;
            deleteContact_Button.Click += deleteContact_Button_Click;
            // 
            // contact_Position_TextBox
            // 
            contact_Position_TextBox.BackColor = Color.White;
            contact_Position_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            contact_Position_TextBox.ForeColor = Color.Black;
            contact_Position_TextBox.Location = new Point(583, 282);
            contact_Position_TextBox.Name = "contact_Position_TextBox";
            contact_Position_TextBox.Size = new Size(283, 27);
            contact_Position_TextBox.TabIndex = 6;
            // 
            // contact_Position_Label
            // 
            contact_Position_Label.AutoSize = true;
            contact_Position_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Position_Label.ForeColor = Color.Black;
            contact_Position_Label.Location = new Point(492, 291);
            contact_Position_Label.Name = "contact_Position_Label";
            contact_Position_Label.Size = new Size(70, 18);
            contact_Position_Label.TabIndex = 10;
            contact_Position_Label.Text = "Position:";
            contact_Position_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // save_Contact_Button
            // 
            save_Contact_Button.BackColor = Color.White;
            save_Contact_Button.BackgroundImage = (Image)resources.GetObject("save_Contact_Button.BackgroundImage");
            save_Contact_Button.BackgroundImageLayout = ImageLayout.Stretch;
            save_Contact_Button.FlatAppearance.BorderSize = 0;
            save_Contact_Button.FlatStyle = FlatStyle.Flat;
            save_Contact_Button.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            save_Contact_Button.ForeColor = Color.White;
            save_Contact_Button.Location = new Point(603, 510);
            save_Contact_Button.Name = "save_Contact_Button";
            save_Contact_Button.Size = new Size(177, 81);
            save_Contact_Button.TabIndex = 9;
            save_Contact_Button.Text = "Save Changes";
            save_Contact_Button.UseVisualStyleBackColor = false;
            save_Contact_Button.Click += save_Contact_Button_Click;
            // 
            // editContact_Label
            // 
            editContact_Label.AutoSize = true;
            editContact_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            editContact_Label.ForeColor = Color.Black;
            editContact_Label.Location = new Point(603, 36);
            editContact_Label.Name = "editContact_Label";
            editContact_Label.Size = new Size(148, 18);
            editContact_Label.TabIndex = 8;
            editContact_Label.Text = "Editing Contact Info";
            editContact_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contact_Email_TextBox
            // 
            contact_Email_TextBox.BackColor = Color.White;
            contact_Email_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            contact_Email_TextBox.ForeColor = Color.Black;
            contact_Email_TextBox.Location = new Point(583, 369);
            contact_Email_TextBox.Name = "contact_Email_TextBox";
            contact_Email_TextBox.Size = new Size(283, 27);
            contact_Email_TextBox.TabIndex = 8;
            // 
            // contact_Phone_TextBox
            // 
            contact_Phone_TextBox.BackColor = Color.White;
            contact_Phone_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            contact_Phone_TextBox.ForeColor = Color.Black;
            contact_Phone_TextBox.Location = new Point(583, 320);
            contact_Phone_TextBox.Name = "contact_Phone_TextBox";
            contact_Phone_TextBox.Size = new Size(283, 27);
            contact_Phone_TextBox.TabIndex = 7;
            // 
            // contact_Name_TextBox
            // 
            contact_Name_TextBox.BackColor = Color.White;
            contact_Name_TextBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            contact_Name_TextBox.ForeColor = Color.Black;
            contact_Name_TextBox.Location = new Point(583, 241);
            contact_Name_TextBox.Name = "contact_Name_TextBox";
            contact_Name_TextBox.Size = new Size(283, 27);
            contact_Name_TextBox.TabIndex = 5;
            // 
            // contact_Email_Label
            // 
            contact_Email_Label.AutoSize = true;
            contact_Email_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Email_Label.ForeColor = Color.Black;
            contact_Email_Label.Location = new Point(489, 373);
            contact_Email_Label.Name = "contact_Email_Label";
            contact_Email_Label.Size = new Size(50, 18);
            contact_Email_Label.TabIndex = 3;
            contact_Email_Label.Text = "Email:";
            contact_Email_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contact_Phone_Label
            // 
            contact_Phone_Label.AutoSize = true;
            contact_Phone_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Phone_Label.ForeColor = Color.Black;
            contact_Phone_Label.Location = new Point(489, 325);
            contact_Phone_Label.Name = "contact_Phone_Label";
            contact_Phone_Label.Size = new Size(70, 18);
            contact_Phone_Label.TabIndex = 2;
            contact_Phone_Label.Text = "Phone #:";
            contact_Phone_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contact_Name_Label
            // 
            contact_Name_Label.AutoSize = true;
            contact_Name_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Name_Label.ForeColor = Color.Black;
            contact_Name_Label.Location = new Point(492, 246);
            contact_Name_Label.Name = "contact_Name_Label";
            contact_Name_Label.Size = new Size(52, 18);
            contact_Name_Label.TabIndex = 1;
            contact_Name_Label.Text = "Name:";
            contact_Name_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contact_Id_Label
            // 
            contact_Id_Label.AutoSize = true;
            contact_Id_Label.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contact_Id_Label.ForeColor = Color.Black;
            contact_Id_Label.Location = new Point(492, 195);
            contact_Id_Label.Name = "contact_Id_Label";
            contact_Id_Label.Size = new Size(54, 18);
            contact_Id_Label.TabIndex = 0;
            contact_Id_Label.Text = "ID = \"\"";
            contact_Id_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HelpUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 235, 225);
            Controls.Add(help_StartOver_Button);
            Controls.Add(help_Start_Panel);
            Controls.Add(help_ContactsOptions_Panel);
            Controls.Add(edit_Contact_Panel);
            Controls.Add(help_Address_Panel);
            Name = "HelpUserControl";
            Size = new Size(1367, 728);
            help_Start_Panel.ResumeLayout(false);
            help_Address_Panel.ResumeLayout(false);
            help_Address_Panel.PerformLayout();
            help_ContactsOptions_Panel.ResumeLayout(false);
            help_ContactsOptions_Panel.PerformLayout();
            edit_Contact_Panel.ResumeLayout(false);
            edit_Contact_Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel help_Start_Panel;
        private MyButton help_StartOver_Button;
        private MyButton help_EditAddress_Button;
        private MyButton help_AddContact_Button;
        private MyButton help_EditContacts_Button;
        private Panel help_Address_Panel;
        private MyLabel address_Zip_Label;
        private MyLabel Address_City_Label;
        private MyLabel address_Street_Label;
        private MyLabel address_Name_Label;
        private MyLabel address_ID_Label;
        private MyLabel myLabel6;
        private MyTextBox address_Zip_TextBox;
        private MyTextBox address_City_TextBox;
        private MyTextBox address_Street_TextBox;
        private MyTextBox address_Name_TextBox;
        private MyButton address_Save_Button;
        private MyTextBox address_State_TextBox;
        private MyLabel address_State_Label;
        private Panel help_ContactsOptions_Panel;
        private MyComboBox select_Contact_ComboBox;
        private MyLabel contact_Select_Label;
        private MyButton load_Contact_Button;
        private Panel edit_Contact_Panel;
        private MyLabel editContact_Label;
        private MyTextBox contact_Email_TextBox;
        private MyTextBox contact_Phone_TextBox;
        private MyTextBox contact_Name_TextBox;
        private MyLabel contact_Email_Label;
        private MyLabel contact_Phone_Label;
        private MyLabel contact_Name_Label;
        private MyLabel contact_Id_Label;
        private MyButton save_Contact_Button;
        private MyTextBox contact_Position_TextBox;
        private MyLabel contact_Position_Label;
        private MyButton deleteContact_Button;
    }
}
