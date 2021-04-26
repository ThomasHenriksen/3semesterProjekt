using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class ShippingDataReadDto
    {
        private double Price { get; set; }
        private bool FreeShipping { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Address { get; set; }
        private string ZipCode { get; set; }
        private string City { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }

        public ShippingDataReadDto()
        {
        }
        public ShippingDataReadDto(double price, bool freeShipping, string firstName, string lastName, string address, string zipCode,
            string city, string phone, string email)
        {
            Price = price;
            FreeShipping = freeShipping;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
        }
    }
}