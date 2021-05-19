using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.BusinessLogic
{
    public class SalesOrderLogic
    {
        private readonly SalesOrderService _salesOrderService;

        public SalesOrderLogic()
        {
            _salesOrderService = new SalesOrderService();
        }
        // Method to save a SalesOrder.
        /// <summary>
        /// Method to save a SalesOrder.
        /// </summary>
        /// <returns>
        /// int 
        /// </returns>
        /// <param name="salesOrderToSave">SalesOrder object.</param>
        public async Task<int> InsertSalesOrder(SalesOrder salesOrder)
        {
            int wasInserted = -1;
            try
            {
                wasInserted = await _salesOrderService.SaveSalesOrder(salesOrder);
            }
            catch
            {
                wasInserted = -1;
            }
            return wasInserted;
        }
    }
}
