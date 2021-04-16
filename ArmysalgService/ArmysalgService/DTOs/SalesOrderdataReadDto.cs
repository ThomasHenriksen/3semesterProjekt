using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class SalesOrderdataReadDto
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Status { get; set; }
        public int SalesLineItem { get; set; }
        public int ShippingId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }

        public SalesOrderdataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, string status, int salesLineItem)
        {
            SalesNo = salesNo;
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
        }

        public SalesOrderdataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, string status, int salesLineItem, int shippingId, int employeeId, int customerId) : this(salesNo, salesDate, paymentAmount, status, salesLineItem)
        {
            ShippingId = shippingId;
            EmployeeId = employeeId;
            CustomerId = customerId;
        }
    }
}
