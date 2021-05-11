using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesLineItemDatabaseAcces
    {
        //  Add saleLineItem to the database
        /// <summary>
        /// Add saleLineItem to the database
        /// </summary>
        /// <returns>
        /// SaleLineItem Id of inserted saleLineItem
        /// </returns>
        /// <param name="aSalesLineItem">SaleLineItem object</param>
        /// <param name="aCart">Cart object</param>
        int AddSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart);

        // Update a saleLineItem to the database base on a cart or salesOrder object.
        /// <summary>
        /// Update a saleLineItem to the database base on a cart or salesOrder object.
        /// </summary>
        /// <returns>
        /// Bool statement whether saleLineItem has be updated or not.
        /// </returns>
        /// <param name="aSalesLineItem">SaleLineItem object</param>
        /// <param name="aCart">Cart object</param>
        /// <param name="aSalesOrder">SalesOrder object</param>
        bool UpdateSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart, SalesOrder aSalesOrder);

        // Find and return saleLineItem from database by saleLineItem Id.
        /// <summary>
        /// Find and return product from database by product number.
        /// </summary>
        /// <returns>
        /// SaleLineItem object.
        /// </returns>
        /// <param name="saleLineItemId">SaleLineItem Id.</param>
        SalesLineItem GetSalesLineItem(int saleLineItemId);

        // Find and return all SaleLineItem from database by cart Id or sales number.
        /// <summary>
        /// Find and return all SaleLineItem from database by cart Id or sales number.
        /// </summary>
        /// <returns>
        /// SaleLineItem objects.
        /// </returns>
        /// <param name="cartId">Cart Id</param>
        /// <param name="salesNo">SalesOrder number</param>
        List<SalesLineItem> GetSalesLineItems(int? cartId, int? salesNo);


        // Delete SaleLineItem from database based on saleLineItem object.
        /// <summary>
        /// Delete SaleLineItem from database based on saleLineItem object.
        /// </summary>
        /// <returns>
        /// Bool statement whether saleLineItem was deleted or not.
        /// </returns>
        /// <param name="aSalesLineItem">SaleLineItem object</param>
        bool DeleteSaleLineItem(SalesLineItem aSalesLineItem);

        // Check if saleLineItem exists in the database base on a cart object.
        /// <summary>
        /// Check if saleLineItem exists in the database base on a cart object.
        /// </summary>
        /// <returns>
        /// Bool statment whether saleLineItem exists or not.
        /// </returns>
        /// <param name="aSalesLineItem">SaleLineItem object</param>
        /// <param name="aCart">Cart object</param>
        bool CheckSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart);
    }
}
