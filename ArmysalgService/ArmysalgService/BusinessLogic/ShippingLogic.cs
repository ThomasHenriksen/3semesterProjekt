using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.BusinessLogic
{
    public class ShippingLogic : IShippingLogic
    {
        IShippingDatabaseAccess _shippingAccess;

        public ShippingLogic(IConfiguration inConfiguration)
        {
            _shippingAccess = new ShippingDatabaseAccess(inConfiguration);
        }

        // Add shipping to the database.
        /// <inheritdoc/>
        public int AddShipping(Shipping aShipping)
        {
            int insertedShippingID;

            try
            {
                insertedShippingID = _shippingAccess.AddShipping(aShipping);
            }
            catch
            {
                insertedShippingID = -1;
            }
            return insertedShippingID;
        }

        // Find and return shipping from database by shipping Id.
        /// <inheritdoc/>
        public Shipping GetShippingByID(int shippingId)
        {
            Shipping foundShipping;
            try
            {
                foundShipping = _shippingAccess.GetShippingByShippingID(shippingId);
            }
            catch
            {
                foundShipping = null;
            }
            return foundShipping;
        }
    }
}