using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class SalesOrderdataWriteDto
    {
        //public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesLineItem> SalesLineItem { get; set; }
        public Shipping? Shipping { get; set; }
        public Employee? Employee { get; set; }
        public Customer? Customer { get; set; }

        public SalesOrderdataWriteDto()
        {
        }

        public SalesOrderdataWriteDto(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem)
        {
            
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
        }

        public SalesOrderdataWriteDto(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, Shipping shippingId, Employee employeeId, Customer customerId) : this(salesDate, paymentAmount, status, salesLineItem)
        {
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
        }
    }
}
