using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(int id, string name, string position, string phone, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Position = position;
            this.Phone = phone;
            this.Email = email;
        }

    }

    public class ContactsRoot
    {
        public List<Contact> Contacts { get; set;}
    }
   

}
