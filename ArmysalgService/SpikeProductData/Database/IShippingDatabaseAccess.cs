using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{   
    public interface IShippingDatabaseAccess
    {
        Shipping GetShippingByShippingID(int shippingID);
        List<Shipping> GetAllShippings();
        int CreateShipping(Shipping shippingToAdd);
        bool DeleteShippingById(int shippingID);
    }
}
