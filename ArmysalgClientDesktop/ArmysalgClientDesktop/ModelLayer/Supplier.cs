using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ModelLayer
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Supplier()
        {

        }

        public Supplier(string name, string address, string zipCode, string city, string country, string phone, string email)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
