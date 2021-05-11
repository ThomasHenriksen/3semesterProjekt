using System;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Model
{
    public class SalesOrder
    {
        public int SalesNo { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }
        public Shipping Shipping { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

        public SalesOrder()
        {

        }

        // Constuct a salesOrder object.
        /// <summary>
        /// Constuct a salesOrder object.
        /// </summary>
        /// <param name="salesDate">Sales date of salesOrder</param>
        /// <param name="paymentAmount">Payment amount of salesOrder</param>
        /// <param name="status">Status of salesOrder</param>
        /// <param name="salesLineItems">Sales line items of salesOrder</param>
        public SalesOrder(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItems)
        {
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItems = salesLineItems;

        }

        // Constuct a salesOrder object.
        /// <summary>
        /// Constuct a salesOrder object.
        /// </summary>
        /// <param name="salesDate">Sales date of salesOrder</param>
        /// <param name="paymentAmount">Payment amount of salesOrder</param>
        /// <param name="status">Status of salesOrder</param>
        /// <param name="salesLineItems">Sales line items of salesOrder</param>
        /// <param name="shippingId">Shipping ID of salesOrder</param>
        /// <param name="employeeId">Employee ID of salesOrder</param>
        /// <param name="customerId">Customer ID of salesOrder</param>
        public SalesOrder(DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItems, Shipping shippingId, Employee employeeId, Customer customerId)
        {
            SalesDate = salesDate;
            PaymentAmount = paymentAmount;
            Status = status;
            SalesLineItems = salesLineItems;
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
        }

        // Constuct a salesOrder object.
        /// <summary>
        /// Constuct a salesOrder object.
        /// </summary>
        /// <param name="salesNo">Sales number of salesOrder</param>
        /// <param name="salesDate">Sales date of salesOrder</param>
        /// <param name="paymentAmount">Payment amount of salesOrder</param>
        /// <param name="status">Status of salesOrder</param>
        /// <param name="salesLineItems">Sales line items of salesOrder</param>
        /// <param name="shippingId">Shipping ID of salesOrder</param>
        /// <param name="employeeId">Employee ID of salesOrder</param>
        /// <param name="customerId">Customer ID of salesOrder</param>
        public SalesOrder(int salesNo, DateTime salesDate, decimal paymentAmount, SalesOrderStatus status, List<SalesLineItem> salesLineItems, Shipping shippingId, Employee employeeId, Customer customerId) : this(salesNo, salesDate, paymentAmount, status)
        {
            SalesLineItems = salesLineItems;
            Shipping = shippingId;
            Employee = employeeId;
            Customer = customerId;
        }

        // Constuct a salesOrder object.
        /// <summary>
        /// Constuct a salesOrder object.
        /// </summary>
        /// <param name="salesNo">Sales number of salesOrder</param>
        /// <param name="salesDate">Sales date of salesOrder</param>
        /// <param name="paymentAmount">Payment amount of salesOrder</param>
        /// <param name="status">Status of salesOrder</param>
        public SalesOrder(int salesNo, DateTime date, decimal paymentAmount, SalesOrderStatus status)
        {
            SalesNo = salesNo;
            SalesDate = date;
            PaymentAmount = paymentAmount;
            Status = status;
        }
    }
}