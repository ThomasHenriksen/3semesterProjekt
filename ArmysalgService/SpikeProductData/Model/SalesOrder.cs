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
        public Shipping? Shipping { get; set; }
        public Employee? Employee { get; set; }
        public Customer? Customer { get; set; }

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

        public SalesOrder(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, Shipping shippingId, Employee employeeId, Customer customerId)
        {
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItem = salesLineItem;
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
        }



        public SalesOrder(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItem, Shipping? shippingId, Employee? employeeId, Customer? customerId) : this(salesNo, salesDate, paymentAmount, status)
        {
            SalesLineItem = salesLineItem;
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
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
