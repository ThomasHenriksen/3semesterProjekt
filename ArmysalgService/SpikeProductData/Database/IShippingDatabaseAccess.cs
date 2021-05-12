using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface IShippingDatabaseAccess
    {
        //Add shipping to the database.
        /// <summary>
        /// Add shipping to the database.
        /// </summary>
        /// <returns>
        /// Shipping Id of inserted shipping object.
        /// </returns>
        /// <param name="aShipping">Shipping object.</param>
        int AddShipping(Shipping aShipping);

        // Find and return shipping from database by shipping id.
        /// <summary>
        /// Find and return shipping from database by shipping id.
        /// </summary>
        /// <returns>
        /// Shipping object.
        /// </returns>
        /// <param name="shippingID"></param>
        Shipping GetShippingByShippingID(int shippingID);

        // Delete shipping from database based on shipping id.
        /// <summary>
        /// Delete shipping from database based on shipping id.
        /// </summary>
        /// <returns>
        /// Bool statement whether shipping was deleted or not.
        /// </returns>
        /// <param name="shippingID">Shipping Id.</param>
        bool DeleteShippingById(int shippingID);
    }
}
