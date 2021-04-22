using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class PriceDataReadDtoConvert
    {
        public static List<PriceDataReadDto> FromPriceCollection(List<Price> inPrice)
        {
            List<PriceDataReadDto> aPriceReadDtoList = null;
            if (inPrice != null)
            {
                aPriceReadDtoList = new List<PriceDataReadDto>();
                PriceDataReadDto tempDto;
                foreach (Price aPrice in inPrice)
                {
                    tempDto = FromPrice(aPrice);
                    aPriceReadDtoList.Add(tempDto);
                }
            }
            return aPriceReadDtoList;
        }

        public static PriceDataReadDto FromPrice(Price inPrice)
        {
            PriceDataReadDto aPriceReadDto = null;
            if (inPrice != null)
            {
                aPriceReadDto = new PriceDataReadDto(inPrice.Id, inPrice.Value, inPrice.StartDate, inPrice.EndDate);
            }
            return aPriceReadDto;
        }
    }
}
