using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface ISalesOrderLogic
    {
        int AddSalesOrder(SalesOrder salesOrderToAdd);

        SalesOrder GetSalesOrderById(int id);

        List<SalesOrder> GetAllSalesOrder();
    }
}
