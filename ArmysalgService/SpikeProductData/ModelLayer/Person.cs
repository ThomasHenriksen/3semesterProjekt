using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String ZipCode { get; set; }
        public String City { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        public Person()
        {
        }
    }
}