using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class Customer : Person
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
        }

        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, Cart cart)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            Cart = cart;
        }
    }
}
