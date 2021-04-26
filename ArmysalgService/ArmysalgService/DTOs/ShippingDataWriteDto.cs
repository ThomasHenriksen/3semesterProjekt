using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class ShippingDataWriteDto
    {
        public double Price { get; set; }
        public bool FreeShipping { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ShippingDataWriteDto()
        {
        }
        public ShippingDataWriteDto(double price, bool freeShipping, string firstName, string lastName, string address, string zipCode,
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