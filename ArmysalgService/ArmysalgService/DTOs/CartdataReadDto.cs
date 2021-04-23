using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CartdataReadDto
    {
        public DateTime LastUpdated { get; set; }

        public CartdataReadDto()
        {

        }

        public CartdataReadDto(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }
    }
}
