using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class SalesOrderdataReadDtoConvert
    {
        public static List<SalesOrderdataReadDto> FromSalesOrderCollection(List<SalesOrder> inSalesOrders)
        {
            List<SalesOrderdataReadDto> aSalesOrderReadDtoList = null;
            if (inSalesOrders != null)
            {
                aSalesOrderReadDtoList = new List<SalesOrderdataReadDto>();
                SalesOrderdataReadDto tempDto;
                foreach (SalesOrder aSalesOrder in inSalesOrders)
                {
                    tempDto = FromSalesOrder(aSalesOrder);
                    aSalesOrderReadDtoList.Add(tempDto);
                }
            }
                return aSalesOrderReadDtoList;
        }

        public static SalesOrderdataReadDto FromSalesOrder(SalesOrder inSalesOrder)
        {
                SalesOrderdataReadDto aSalesOrderReadDto = null;
                if (inSalesOrder != null)
                {
                    aSalesOrderReadDto = new SalesOrderdataReadDto(inSalesOrder.SalesDate, inSalesOrder.PaymentAmount, inSalesOrder.Status, inSalesOrder.SalesLineItem);
                }
                return aSalesOrderReadDto;
        }
        
    }
}
