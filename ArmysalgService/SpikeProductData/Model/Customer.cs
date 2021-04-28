﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Model
{
    public class Customer : Person
    {
        public int CustomerNo { get; set; }

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

        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int customerNo)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            CustomerNo = customerNo;
        }
    }
}