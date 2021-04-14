using ArmysalgDataAccess.ModelLayer;
using ArmysalgDataTest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public class SalesOrderDatabaseAccess : ISalesOrderAccess
    {
        readonly string _connectionString;

        public SalesOrderDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        // For test
        public SalesOrderDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public void CreateSalesOrder(SalesOrder salesOrderToAdd)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrderById(int salesOrderId)
        {
            throw new NotImplementedException();
        }
    }

}
