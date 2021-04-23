using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CartdataWriteDto
    {
        public DateTime LastUpdated;

        public CartdataWriteDto()
        {

        }

        public CartdataWriteDto(DateTime lastUpdated) 
        {
            LastUpdated = lastUpdated;
        }
    }
}
