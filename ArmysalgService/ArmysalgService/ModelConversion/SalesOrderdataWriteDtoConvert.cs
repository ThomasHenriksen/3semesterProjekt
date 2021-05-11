using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class SalesOrderdataWriteDtoConvert
    {
        public static SalesOrder ToSalesOrder(SalesOrderdataWriteDto inDto)
        {
            SalesOrder aSalesOrder = null;
            if (inDto != null)
            {
                aSalesOrder = new SalesOrder(inDto.SalesDate, inDto.PaymentAmount, inDto.Status, inDto.SalesLineItem, inDto.Shipping, inDto.Employee, inDto.Customer);
            }
            return aSalesOrder;
        }
    }
}
