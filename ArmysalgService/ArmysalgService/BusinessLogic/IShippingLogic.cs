using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface IShippingLogic
    {
        // Add shipping to the database.
        /// <summary>
        /// Add shipping to the database.
        /// </summary>
        /// <returns>
        /// Shipping Id of inserted shipping object.
        /// </returns>
        /// <param name="aShipping">Shipping object.</param>
        int AddShipping(Shipping aShipping);

        // Find and return shipping from database by shipping Id.
        /// <summary>
        /// Find and return shipping from database by shipping Id.
        /// </summary>
        /// <returns>
        /// Shipping object.
        /// </returns>
        /// <param name="shippingId">Shipping Id.</param>
        Shipping GetShippingByID(int shippingId);
    }
}