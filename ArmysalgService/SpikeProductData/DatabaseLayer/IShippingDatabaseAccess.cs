using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public interface IShippingDatabaseAccess
    {
        Shipping GetShippingByShippingID(int shippingID);
        List<Shipping> GetAllShippings();
        int CreateShipping(Shipping shippingToAdd);
        bool DeleteShippingByshippingID(int shippingID);
    }
}
