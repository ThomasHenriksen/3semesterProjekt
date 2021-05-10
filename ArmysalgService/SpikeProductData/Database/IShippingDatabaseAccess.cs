using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
