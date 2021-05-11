using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesLineItemDatabaseAcces
    {
        int CreateSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart);
        bool UpdateSalesLineItem(SalesLineItem aSalesLineItem, Cart? aCart, SalesOrder? aSalesOrder);
        SalesLineItem GetSalesLineItem(int saleLineItemId);
        List<SalesLineItem> GetSalesLineItems(int? cartId, int? salesNo);
        bool DeleteSaleLineItem(SalesLineItem aSalesLineItem);
        bool CheckSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart);
    }
}
