using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{   // brian
    public interface IShippingDatabaseAccess
    {
        Shipping GetShippingByShippingID(int? shippingID);
        List<Shipping> GetAllShippings();
        int CreateShipping(Shipping shippingToAdd);
        bool DeleteShippingById(int shippingID);
    }
}
