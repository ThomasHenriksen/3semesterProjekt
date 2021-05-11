using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class SalesOrderLogic : ISalesOrderLogic
    {
        ISalesOrderDatabaseAccess _salesOrderAccess;

        public SalesOrderLogic(IConfiguration inConfiguration)
        {
            _salesOrderAccess = new SalesOrderDatabaseAccess(inConfiguration);
        }

        // Add a new salesOrder in the database.
        /// <inheritdoc/>
        public int AddSalesOrder(SalesOrder salesOrderToAdd)
        {
            int insertedSalesNo;
            try
            {
                insertedSalesNo = _salesOrderAccess.AddSalesOrder(salesOrderToAdd);
            }
            catch
            {
                insertedSalesNo = -1;
            }
            return insertedSalesNo;
        }

        // Find and return salesOrders from database.
        /// <inheritdoc/>
        public List<SalesOrder> GetAllSalesOrder()
        {
            throw new NotImplementedException(); //Todo or not todo!
        }

        // Find and return salesOrder from database by salesOrder number.
        /// <inheritdoc/>
        public SalesOrder GetSalesOrderById(int salesNoToMatch)
        {
            SalesOrder foundSalesOrder;
            try
            {
                foundSalesOrder = _salesOrderAccess.GetSalesOrderById(salesNoToMatch);
            }
            catch
            {
                foundSalesOrder = null;
            }
            return foundSalesOrder;
        }
    }
}