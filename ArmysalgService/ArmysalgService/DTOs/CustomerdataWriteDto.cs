﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CustomerdataWriteDto : PersondataWriteDto
    {
        public int CustomerNo { get; set; }

        public CustomerdataWriteDto()
        {
        }

        public CustomerdataWriteDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
        }

        public CustomerdataWriteDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int customerNo)
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