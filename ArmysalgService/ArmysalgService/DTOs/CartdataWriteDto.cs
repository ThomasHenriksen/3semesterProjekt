using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;

namespace ArmysalgService.DTOs
{
    public class CartdataWriteDto
    {
        public DateTime LastUpdated { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }

        public CartdataWriteDto()
        {
        }
    }
}