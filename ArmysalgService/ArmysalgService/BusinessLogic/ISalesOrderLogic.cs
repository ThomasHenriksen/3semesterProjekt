using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface ISalesOrderLogic
    {
        // Add salesOrder to the database.
        /// <summary>
        /// Add salesOrder to the database.
        /// </summary>
        /// <returns>
        /// SalesOrder number of inserted salesOrder object.
        /// </returns>
        /// <param name="aSalesOrder">SalesOrder object.</param>
        int AddSalesOrder(SalesOrder salesOrderToAdd);

        // Find and return salesOrder from database by salesOrder number.
        /// <summary>
        /// Find and return salesOrder from database by salesOrder number.
        /// </summary>
        /// <returns>
        /// SalesOrder object.
        /// </returns>
        /// <param name="salesOrderNo">SalesOrder number.</param>
        SalesOrder GetSalesOrderById(int id);

        // Find and return salesOrders from database.
        /// <summary>
        /// Find and return salesOrders from database.
        /// </summary>
        /// <returns>
        /// List of saleOrder objects.
        /// </returns>
        List<SalesOrder> GetAllSalesOrder();
    }
}
