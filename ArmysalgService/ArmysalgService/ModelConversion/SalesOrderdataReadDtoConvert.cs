using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class SalesOrderdataReadDtoConvert
    {

        //public static SalesOrderdataReadDto FromOrderToReadDto(SalesOrder inSalesOrder)
        //{
        //    SalesOrderdataReadDto foundSales = new SalesOrderdataReadDto(inSalesOrder.SalesNo, inSalesOrder.SalesDate, inSalesOrder.PaymentAmount, inSalesOrder.Status, inSalesOrder.SalesLineItem, inSalesOrder.ShippingId, inSalesOrder.EmployeeId, inSalesOrder.CustomerId);
        //    return foundSales;
        //}

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
                    aSalesOrderReadDto = new SalesOrderdataReadDto(inSalesOrder.SalesNo, inSalesOrder.SalesDate, inSalesOrder.PaymentAmount, inSalesOrder.Status, inSalesOrder.SalesLineItem, inSalesOrder.ShippingId, inSalesOrder.EmployeeId, inSalesOrder.CustomerId);
                }
                return aSalesOrderReadDto;
        }
        
    }
}
