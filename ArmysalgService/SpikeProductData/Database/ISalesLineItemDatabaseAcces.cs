using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public interface ISalesLineItemDatabaseAcces
    {
        int CreateSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart);
        bool UpdateSalesLineItem(SalesLineItem aSalesLineItem, Cart? aCart, SalesOrder? aSalesOrder);
        SalesLineItem GetSalesLineItem(int saleLineItemId);
        List<SalesLineItem> GetSalesLineItems(int? cartId, int? salesNo);
        bool DeleteSaleLineItem(SalesLineItem aSalesLineItem);
    }
}
