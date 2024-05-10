using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KNCDesktopApp
{
    public partial class HelpUserControl : UserControl
    {
        public HelpUserControl()
        {
            InitializeComponent();
        }

        List<Address> addressList = new List<Address>();
        String assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        Address selectedAddress = null;


        List<Contact> contactList = new List<Contact>();
        Contact selectedContact = null;



        private void help_EditAddress_Button_Click(object sender, EventArgs e)
        {
            help_Start_Panel.Hide();
            help_Address_Panel.Show();
            help_StartOver_Button.Show();

            // load addresses from json and display in textboxes and stuff
            addressList.Clear();
            // addresses are loaded from file
            AddAddressesFromFile(Path.Combine(assetsDirectory, "addresses.json"));
            selectedAddress = addressList[0];

            address_ID_Label.Text = $"ID = {selectedAddress.Id}";
            address_City_TextBox.Text = selectedAddress.City;
            address_Name_TextBox.Text = selectedAddress.Name;
            address_State_TextBox.Text = selectedAddress.State;
            address_Street_TextBox.Text = selectedAddress.Street;
            address_Zip_TextBox.Text = selectedAddress.Zip;



        }

        public void AddAddressesFromFile(string pathToJson)
        {
            string json = File.ReadAllText(pathToJson);
            var addresses = JsonConvert.DeserializeObject<AddressesRoot>(json);
            if (addresses?.Addresses != null)
            {
                addressList.AddRange(addresses.Addresses);
            }
        }



        public void help_StartOver_Button_Click(object sender, EventArgs e)
        {
            help_Address_Panel.Hide();
            help_Start_Panel.Show();
            help_StartOver_Button.Hide();
            edit_Contact_Panel.Hide();
            help_ContactsOptions_Panel.Hide();
            selectedAddress = null;
            selectedContact = null;
            contactList.Clear();
            addressList.Clear();

        }

        public void ResetVisually() 
        {
            help_Address_Panel.Hide();
            help_Start_Panel.Show();
            help_StartOver_Button.Hide();
            edit_Contact_Panel.Hide();
            help_ContactsOptions_Panel.Hide();
            //selectedAddress = null;
            //selectedContact = null;
            //contactList.Clear();
            //addressList.Clear();
        }



        private void address_Save_Button_Click(object sender, EventArgs e)
        {
            ResetVisually();


            string name = selectedAddress.Name;
            // take info from textboxes and write to json file using the Utilities.write address to json
            selectedAddress.Id = 0;
            selectedAddress.Name = address_Name_TextBox.Text;
            selectedAddress.Street = address_Street_TextBox.Text;
            selectedAddress.City = address_City_TextBox.Text;
            selectedAddress.State = address_State_TextBox.Text;
            selectedAddress.Zip = address_Zip_TextBox.Text;

            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

            Task.Run(() =>
            {
                // initial actions to take place
                // now that weve saved the address to the selected address item. we can write the "list" (one item)  to the json.
                Utilities.WriteAddressesToJson(Path.Combine(assetsDirectory, "addresses.json"), addressList);
                // When the actions above have been completed, do this
                this.Invoke(new Action(() =>
                {
                    progressDialog.Close();
                    progressDialog = null;
                    // show message box here

                    help_StartOver_Button_Click(sender, e);

                    MessageBox.Show($"Address info for {name} has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }));
            });
        }


        private void select_Contact_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_Contact_Button.Show();
            selectedContact = select_Contact_ComboBox.SelectedItem as Contact;
        }

        private void help_EditContacts_Button_Click(object sender, EventArgs e)
        {
            select_Contact_ComboBox.DataSource = null;
            // load in contacts from json file
            contactList.Clear();
            AddContactsFromFile(Path.Combine(assetsDirectory, "contacts.json"));

            select_Contact_ComboBox.DataSource = contactList;
            select_Contact_ComboBox.DisplayMember = "Name";
            select_Contact_ComboBox.ValueMember = "id";
            select_Contact_ComboBox.SelectedIndex = -1;

            help_ContactsOptions_Panel.Show();
            help_Start_Panel.Hide();
            //edit_Contact_Panel.Show();
            help_StartOver_Button.Show();

        }

        public void AddContactsFromFile(string pathToJson)
        {
            string json = File.ReadAllText(pathToJson);
            var contacts = JsonConvert.DeserializeObject<ContactsRoot>(json);
            if (contacts?.Contacts != null)
            {
                contactList.AddRange(contacts.Contacts);
            }
        }

        private void load_Contact_Button_Click(object sender, EventArgs e)
        {
            edit_Contact_Panel.Show();
            help_ContactsOptions_Panel.Hide();

            contact_Id_Label.Text = $"ID = {selectedContact.Id}";
            contact_Name_TextBox.Text = selectedContact.Name;
            contact_Phone_TextBox.Text = selectedContact.Phone;
            contact_Email_TextBox.Text = selectedContact.Email;
            contact_Position_TextBox.Text = selectedContact.Position;
        }

        private void help_AddContact_Button_Click(object sender, EventArgs e)
        {
            contactList.Clear();
            AddContactsFromFile(Path.Combine(assetsDirectory, "contacts.json"));

            edit_Contact_Panel.Show();
            //help_ContactsOptions_Panel.Hide();
            help_Start_Panel.Hide();
            contact_Id_Label.Text = $"ID = {contactList.Count}";
            contact_Name_TextBox.Text = "";
            contact_Phone_TextBox.Text = "";
            contact_Email_TextBox.Text = "";
            contact_Position_TextBox.Text = "";
            help_StartOver_Button.Show();
        }

        private void save_Contact_Button_Click(object sender, EventArgs e)
        {
            int index = contactList.Count;
            string name = contact_Name_TextBox.Text;
            string position = contact_Position_TextBox.Text;
            string phone = contact_Phone_TextBox.Text;
            string email = contact_Email_TextBox.Text;

            ResetVisually();
            Loading progressDialog = new Loading();
            progressDialog.Show();
            progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";


            if (selectedContact == null)
            {
                selectedContact = new Contact(index, name, position, phone, email);
                contactList.Add(selectedContact);

                Task.Run(() =>
                {
                    // initial actions to take place
                    // Assume RemoveAnnouncement is a method that removes the announcement
                    // and announcementsList is your list of announcements
                    Utilities.WriteContactsToJson(Path.Combine(assetsDirectory, "contacts.json"), contactList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        help_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Contact info for {name} has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }));
                });


            }
            else
            {
                selectedContact.Name = name;
                selectedContact.Position = position;
                selectedContact.Phone = phone;
                selectedContact.Email = email;

                Task.Run(() =>
                {
                    // initial actions to take place
                    // Assume RemoveAnnouncement is a method that removes the announcement
                    // and announcementsList is your list of announcements
                    Utilities.WriteContactsToJson(Path.Combine(assetsDirectory, "contacts.json"), contactList);

                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        help_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Contact info for {name} has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }));
                });
            }
        }

        private void deleteContact_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this contact? This process cannot be reversed.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                ResetVisually();
                contactList.RemoveAll(a => a.Name == selectedContact.Name);

                Loading progressDialog = new Loading();
                progressDialog.Show();
                progressDialog.lblMessage.Text = "Syncing with Google Drive.. Please wait";

                Task.Run(() =>
                {
                    // initial actions to take place
                    Utilities.WriteContactsToJson(Path.Combine(assetsDirectory, "contacts.json"), contactList);


                    // When the actions above have been completed, do this
                    this.Invoke(new Action(() =>
                    {
                        progressDialog.Close();
                        progressDialog = null;
                        // show message box here
                        help_StartOver_Button_Click(sender, e);
                        MessageBox.Show($"Contact deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }));
                });
            }


        }
    }
}
