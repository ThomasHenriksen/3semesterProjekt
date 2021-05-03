using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class SalesOrderdataWriteDtoConvert
    {
        public static SalesOrder ToSalesOrder(SalesOrderdataWriteDto inDto)
        {
            SalesOrder aSalesOrder = null;
            if(inDto != null)
            {
                aSalesOrder = new SalesOrder(inDto.SalesDate, inDto.PaymentAmount, inDto.Status, inDto.SalesLineItem, inDto.ShippingId, inDto.EmployeeId, inDto.CustomerId); 
            }
            return aSalesOrder;
        }
    }
}
