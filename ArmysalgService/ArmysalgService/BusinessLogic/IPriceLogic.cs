using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface IPriceLogic
    {
        // Find and return price from database by price id.
        /// <summary>
        /// Find and return price from database by price id.
        /// </summary>
        /// <returns>
        /// price object.
        /// </returns>
        /// <param name="priceId">price number.</param>
        int Add(Price newPrice, Product product);

        // Update a price in the database.
        /// <summary>
        /// Update a price in the database.
        /// </summary>
        /// <returns>
        ///  Bool statement whether price has be updated or not.
        /// </returns>
        /// <param name="aPrice">price object.</param>
        bool Put(Price aPrice);
    }
}
