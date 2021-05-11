using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesOrderDatabaseAccess
    {
        int CreateSalesOrder(SalesOrder aSalesOrder);
        SalesOrder GetSalesOrderById(int salesOrderId);
        bool DeleteSalesOrderBySalesNo(int id);
    }
}
