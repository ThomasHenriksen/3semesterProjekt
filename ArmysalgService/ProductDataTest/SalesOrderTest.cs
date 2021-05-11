using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class SalesOrderTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private ISalesOrderDatabaseAccess _salesOrderAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";


        public SalesOrderTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _salesOrderAccess = new SalesOrderDatabaseAccess(_connectionString);
        }

        /*
         * Tests instantiation of objects of class SalesOrder.
         */
        [Fact]
        public void TestCreateSalesOrderObject()
        {
            //Arrange
            SalesOrder initialSalesOrderToCompare = new(1, DateTime.Today, 200, SalesOrderStatus.Delivered);
            int salesNo = 1;
            DateTime date = DateTime.Today;
            decimal paymentAmount = 200;
            var status = SalesOrderStatus.Delivered;

            //Act
            SalesOrder SalesOrderToCompare = new SalesOrder(salesNo, date, paymentAmount, status);

            extraOutput.WriteLine("Sales Order INFO");
            extraOutput.WriteLine("Sales Order ID: " + initialSalesOrderToCompare.SalesNo);
            extraOutput.WriteLine("Date: " + initialSalesOrderToCompare.SalesDate);
            extraOutput.WriteLine("Payment amount: " + initialSalesOrderToCompare.SalesNo);
            extraOutput.WriteLine("Delivered: " + SalesOrderStatus.Delivered);

            //Assert
            Assert.Equal(initialSalesOrderToCompare.SalesNo.ToString(), SalesOrderToCompare.SalesNo.ToString());
            Assert.Equal(initialSalesOrderToCompare.SalesDate.ToString(), SalesOrderToCompare.SalesDate.ToString());
            Assert.Equal(initialSalesOrderToCompare.PaymentAmount.ToString(), SalesOrderToCompare.PaymentAmount.ToString());
            Assert.Equal(initialSalesOrderToCompare.Status, SalesOrderToCompare.Status);
        }

        /*
         * Tests CreateSalesOrder method.
         */
        [Fact]
        public void TestCreateSalesOrder()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            decimal paymentAmount = 150;
            SalesOrderStatus status = 0;
            List<SalesLineItem> salesLineItems = new();
            Shipping shipping = null;
            Employee employee = null;
            Customer customer = null;
            SalesOrder salesOrderToCreate = new SalesOrder(dateTime, paymentAmount, status, salesLineItems, shipping, employee, customer);

            //Act
            int idOfInsertedSalesOrder = _salesOrderAccess.AddSalesOrder(salesOrderToCreate);
            SalesOrder readSalesOrder = _salesOrderAccess.GetSalesOrderById(idOfInsertedSalesOrder);

            extraOutput.WriteLine("Sales Order INFO");
            extraOutput.WriteLine("Sales Order ID: " + salesOrderToCreate.SalesNo);
            extraOutput.WriteLine("Date: " + salesOrderToCreate.SalesDate);
            extraOutput.WriteLine("Payment amount: " + salesOrderToCreate.SalesNo);
            extraOutput.WriteLine("Delivered: " + SalesOrderStatus.Delivered);

            //Assert
            Assert.Equal(idOfInsertedSalesOrder, readSalesOrder.SalesNo);
            Assert.Equal(salesOrderToCreate.SalesDate.ToString(), readSalesOrder.SalesDate.ToString());
            Assert.Equal(salesOrderToCreate.PaymentAmount, readSalesOrder.PaymentAmount);
            Assert.Equal(salesOrderToCreate.Status, readSalesOrder.Status);

            //CleanUp
            _salesOrderAccess.DeleteSalesOrderBySalesNo(idOfInsertedSalesOrder);
        }
    }
}