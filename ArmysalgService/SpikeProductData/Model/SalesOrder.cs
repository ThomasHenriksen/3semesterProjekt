using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Model
{
    public class SalesOrder
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesLineItem> SalesLineItem { get; set; }
        public int ShippingId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }

        public SalesOrder()
        {

        }

        public SalesOrder(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItems) 
        {
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItems;
            
        }

        public SalesOrder(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, int shippingId, int employeeId, int customerId)
        {
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
            ShippingId = shippingId;
            EmployeeId = employeeId;
            CustomerId = customerId;
        }



        public SalesOrder(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, int shippingId, int employeeId, int customerId) : this(salesNo, salesDate, paymentAmount, status)
        {
            ShippingId = shippingId;
            EmployeeId = employeeId;
            CustomerId = customerId;
        }

        public SalesOrder(int salesNo, DateTime date, decimal paymentAmount, SalesOrderStatus status) 
        {
            SalesNo = salesNo;
            SalesDate = date;
            PaymentAmount = paymentAmount;
            Status = status;
            
        }
    }
}
