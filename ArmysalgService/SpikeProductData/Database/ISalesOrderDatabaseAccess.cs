using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesOrderDatabaseAccess
    {
        // Add salesOrder to the database.
        /// <summary>
        /// Add salesOrder to the database.
        /// </summary>
        /// <returns>
        /// SalesOrder number of inserted salesOrder object.
        /// </returns>
        /// <param name="asalesOrder">salesOrder object.</param>
        int AddSalesOrder(SalesOrder aSalesOrder);

        // Find and return salesOrder from database by salesOrder number.
        /// <summary>
        /// Find and return salesOrder from database by salesOrder number.
        /// </summary>
        /// <returns>
        /// SalesOrder object.
        /// </returns>
        /// <param name="salesOrderNo">salesOrder number.</param>
        SalesOrder GetSalesOrderById(int salesOrderId);

        // Delete salesOrder from database based on salesOrder number.
        /// <summary>
        /// Delete salesOrder from database based on salesOrder number.
        /// </summary>
        /// <returns>
        /// Bool statement whether salesOrder was deleted or not.
        /// </returns>
        /// <param name="salesOrderNo">salesOrder number.</param>
        bool DeleteSalesOrderBySalesNo(int id);
    }
}