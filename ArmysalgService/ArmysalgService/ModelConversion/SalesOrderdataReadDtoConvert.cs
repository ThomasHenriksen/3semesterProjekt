using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System.Collections.Generic;

namespace ArmysalgService.ModelConversion
{
    public class SalesOrderdataReadDtoConvert
    {
        public static List<SalesOrderDataReadDto> FromSalesOrderCollection(List<SalesOrder> inSalesOrders)
        {
            List<SalesOrderDataReadDto> aSalesOrderReadDtoList = null;
            if (inSalesOrders != null)
            {
                aSalesOrderReadDtoList = new List<SalesOrderDataReadDto>();
                SalesOrderDataReadDto tempDto;
                foreach (SalesOrder aSalesOrder in inSalesOrders)
                {
                    tempDto = FromSalesOrder(aSalesOrder);
                    aSalesOrderReadDtoList.Add(tempDto);
                }
            }
            return aSalesOrderReadDtoList;
        }

        public static SalesOrderDataReadDto FromSalesOrder(SalesOrder inSalesOrder)
        {
            SalesOrderDataReadDto aSalesOrderReadDto = null;
            if (inSalesOrder != null)
            {
                aSalesOrderReadDto = new SalesOrderDataReadDto(inSalesOrder.SalesNo, inSalesOrder.SalesDate, inSalesOrder.PaymentAmount, inSalesOrder.Status, inSalesOrder.SalesLineItems, inSalesOrder.Shipping, inSalesOrder.Employee, inSalesOrder.Customer);
            }
            return aSalesOrderReadDto;
        }

    }
}
