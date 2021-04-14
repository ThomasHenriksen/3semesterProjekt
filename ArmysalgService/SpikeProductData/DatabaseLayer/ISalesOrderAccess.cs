using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataTest
{
    public interface ISalesOrderAccess
    {
        int CreateSalesOrder(SalesOrder salesOrderToAdd);
        SalesOrder GetSalesOrderById(int salesOrderId);
    }
}
