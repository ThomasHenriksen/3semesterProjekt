using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class PriceDataWriteDtoConvert
    {
        public static Price ToPrice(PriceDataWriteDto inDto)
        {
            Price aPrice = null;
            if (inDto != null)
            {
                aPrice = new Price(inDto.Value, inDto.StartDate, inDto.EndDate);
            }
            return aPrice;
        }
    }
}
