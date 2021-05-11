using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.BusinessLogic
{
    public class ShippingLogic
    {
        IShippingDatabaseAccess _shippingAccess;

        public ShippingLogic(IConfiguration inConfiguration)
        {
            _shippingAccess = new ShippingDatabaseAccess(inConfiguration);
        }

        public int AddShipping(Shipping shippingToAdd)
        {
            int insertedShippingID;
            try
            {
                insertedShippingID = _shippingAccess.CreateShipping(shippingToAdd);
            }
            catch
            {
                insertedShippingID = -1;
            }
            return insertedShippingID;
        }

        public Shipping GetShippingByID(int shippingToFind)
        {
            Shipping foundShipping;
            try
            {
                foundShipping = _shippingAccess.GetShippingByShippingID(shippingToFind);
            }
            catch
            {
                foundShipping = null;
            }
            return foundShipping;
        }
    }
}