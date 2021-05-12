using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;

namespace ArmysalgService.DTOs
{
    public class SalesOrderDataReadDto
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesLineItem> SalesLineItem { get; set; }
        public Shipping Shipping { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

        public SalesOrderDataReadDto()
        {

        }

        public SalesOrderDataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, Shipping shippingId, Employee employeeId, Customer customerId)
        {
            SalesNo = salesNo;
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
        }
    }
}