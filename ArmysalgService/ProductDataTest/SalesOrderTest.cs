﻿using ArmysalgDataAccess.Database;
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
        readonly SalesOrderDatabaseAccess _connection;
        
        // For test
        public SalesOrderTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
           _salesOrderAccess = new SalesOrderDatabaseAccess(_connectionString);
        }
        [Fact]
        public void TestCreateSalesOrderObject()
        {
            //Arrange
            SalesOrder testOrder = new SalesOrder(1, DateTime.Today, 200, SalesOrderStatus.Delivered);
            int salesNo = 1;
            DateTime date = DateTime.Today;
            decimal paymentAmount = 200;
            var status = SalesOrderStatus.Delivered;
            int salesLineItem = 1;

            //Act
            SalesOrder newOrder = new SalesOrder(salesNo, date, paymentAmount, status);

            //Assert
            Assert.Equal(testOrder.SalesNo.ToString(), newOrder.SalesNo.ToString());
            Assert.Equal(testOrder.SalesDate.ToString(), newOrder.SalesDate.ToString());
            Assert.Equal(testOrder.PaymentAmount.ToString(), newOrder.PaymentAmount.ToString());
            Assert.Equal(testOrder.Status, newOrder.Status);
            //Assert.Equal(testOrder.SalesLineItem.ToString(), newOrder.SalesLineItem.ToString());
        }

        [Fact]
        public void TestInsertCreatedSalesOrderToDatabase()
        {
            //Arrange
            SalesLineItem salesLineItemToTest = new();
            List<SalesLineItem> listOfSalesLineItemToTest = new();
            SalesOrder salesOrderToDatabase = new SalesOrder(DateTime.Today, 200, SalesOrderStatus.Shipped, listOfSalesLineItemToTest, null, null, null);

            //Act
            int salesOrderNoOnNewSalesOrderInDatabase = _salesOrderAccess.CreateSalesOrder(salesOrderToDatabase);
            SalesOrder getNewlyInsertedSalesOrder = _salesOrderAccess.GetSalesOrderById(salesOrderNoOnNewSalesOrderInDatabase);

            //Assert
            Assert.Equal(getNewlyInsertedSalesOrder.SalesNo.ToString(), salesOrderNoOnNewSalesOrderInDatabase.ToString());
        }
    }
}
