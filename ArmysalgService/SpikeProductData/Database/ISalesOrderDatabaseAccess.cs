using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesOrderDatabaseAccess
    {
        int CreateSalesOrder(SalesOrder salesOrderToAdd);
        SalesOrder GetSalesOrderById(int salesOrderId);
      
    }
}
