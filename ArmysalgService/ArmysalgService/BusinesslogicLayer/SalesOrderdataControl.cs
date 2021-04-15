using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using ArmysalgDataTest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class SalesOrderdataControl : ISalesOrderdata
    {
        ISalesOrderAccess _salesOrderAccess;

        public SalesOrderdataControl(IConfiguration inConfiguration)
        {
            _salesOrderAccess = new SalesOrderDatabaseAccess(inConfiguration);
        }

        public int AddSalesOrder(SalesOrder salesOrderToAdd)
        {
            int insertedSalesNo;
            try
            {
                insertedSalesNo = _salesOrderAccess.CreateSalesOrder(salesOrderToAdd);
            }
            catch 
            {
                insertedSalesNo = -1;
            }
            return insertedSalesNo;
        }

        public List<SalesOrder> GetAllSalesOrder()
        {
            throw new NotImplementedException(); //Todo or not todo!
        }

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
