using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Person
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String address { get; set; }
        public String zipCode { get; set; }
        public String city { get; set; }
        public String phone { get; set; }
        public String email { get; set; }

        public Person(String firstName, String lastName, String address, String zipCode, String city, String phone, String email) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.zipCode = zipCode;
            this.city = city;
            this.phone = phone;
            this.email = email;
        }
    }
}