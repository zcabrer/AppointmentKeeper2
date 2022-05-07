using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2.Modules
{
    class CustomerDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomerDetails() { }


        public CustomerDetails(string name, string address, string phone, string city, string country)
        {
            Name = name;
            Address = address;
            Phone = phone;
            City = city;
            Country = country;
        }

    }
}
