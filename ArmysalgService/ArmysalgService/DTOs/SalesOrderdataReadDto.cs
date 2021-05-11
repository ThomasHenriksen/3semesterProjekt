using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;

namespace ArmysalgService.DTOs
{
    public class SalesOrderdataReadDto
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesLineItem> SalesLineItem { get; set; }
        public Shipping? Shipping { get; set; }
        public Employee? Employee { get; set; }
        public Customer? Customer { get; set; }

        public SalesOrderdataReadDto()
        {

        }

        public SalesOrderdataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, Shipping shippingId, Employee employeeId, Customer customerId)
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


        //public SalesOrderdataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem)
        //{
        //    SalesNo = salesNo;
        //    SalesDate = salesDate;
        //    PaymentAmount = paymentAmount;
        //    Status = status;
        //    SalesLineItem = salesLineItem;
        //}

        //public SalesOrderdataReadDto(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, int shippingId, int employeeId, int customerId) : this(salesNo, salesDate, paymentAmount, status, salesLineItem)
        //{
        //    ShippingId = shippingId;
        //    EmployeeId = employeeId;
        //    CustomerId = customerId;
        //}
    }
}
