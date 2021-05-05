using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
     public interface ISalesOrderLogic
    {
        int AddSalesOrder(SalesOrder salesOrderToAdd);

        SalesOrder GetSalesOrderById(int id);

        List<SalesOrder> GetAllSalesOrder();
    }
}
