using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CartdataWriteDto
    {

       
        public DateTime LastUpdated { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }


        public CartdataWriteDto()
        {
        }

        public CartdataWriteDto(DateTime lastUpdated) 
        {
            LastUpdated = lastUpdated;
        }
        public CartdataWriteDto(DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }
    }
}
