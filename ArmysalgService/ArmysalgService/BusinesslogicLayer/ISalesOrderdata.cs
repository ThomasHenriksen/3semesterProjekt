using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
     public interface ISalesOrderdata
    {
        int AddSalesOrder(SalesOrder salesOrderToAdd);

        SalesOrder GetSalesOrderById(int id);

        List<SalesOrder> GetAllSalesOrder();
    }
}
