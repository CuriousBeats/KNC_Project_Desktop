using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Address
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }

        public Address(int id, string name,  string street, string city, string state, string zip)
        {
            this.Id = id;
            this.Name = name;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

    }

    public class AddressesRoot
    {
        public List<Address> Addresses { get; set;}
    }
}
