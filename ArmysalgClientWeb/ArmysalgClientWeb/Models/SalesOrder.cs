using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class SalesOrder
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Status { get; set; }
        public int SalesLineItem { get; set; }
        public int ShippingId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }

        public SalesOrder()
        {

        }
        public SalesOrder(int salesNo, DateTime salesDate, decimal paymentAmount, string status, int salesLineItem)
        {
            SalesNo = salesNo;
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
        }
    }
}
