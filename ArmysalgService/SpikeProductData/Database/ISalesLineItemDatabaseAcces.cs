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
        SalesLineItem GetSalesLineItem(int? cartId, int? salesNo);
        List<SalesLineItem> GetSalesLineItems(int? cartId, int? salesNo);
        bool DeleteSaleLineItemById(SalesLineItem aSalesLineItem);
    }
}
