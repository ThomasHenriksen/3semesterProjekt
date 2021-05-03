using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CartdataReadDto
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }


        public CartdataReadDto()
        {

        }

        public CartdataReadDto(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }
        public CartdataReadDto(int id, DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            Id = id;
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }
    }
}
