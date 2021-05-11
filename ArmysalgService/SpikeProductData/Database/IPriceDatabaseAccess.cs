using ArmysalgDataAccess.Model;


namespace ArmysalgDataAccess.Database
{
    public interface IPriceDatabaseAccess
    {
        // Add price to the database.
        /// <summary>
        /// Add price to the database.
        /// </summary>
        /// <returns>
        /// price id of inserted price object.
        /// </returns>
        /// <param name="aProduct">product object.</param>
        int AddPrice(Price aPrice, Product product);

        // Find and return price from database by price id.
        /// <summary>
        /// Find and return price from database by price id.
        /// </summary>
        /// <returns>
        /// price object.
        /// </returns>
        /// <param name="priceId">price number.</param>
        Price GetPriceById(int priceId);

        // Find and return price from database by product number.
        /// <summary>
        /// Find and return price from database by product number.
        /// </summary>
        /// <returns>
        /// price object.
        /// </returns>
        /// <param name="productNo">product number.</param>
        Price GetPriceByProductNo(int productNo);


        // Update a price in the database.
        /// <summary>
        /// Update a price in the database.
        /// </summary>
        /// <returns>
        ///  Bool statement whether price has be updated or not.
        /// </returns>
        /// <param name="aPrice">price object.</param>
        bool UpdateEndDatePrice(Price aPrice);

        // Delete product from database based on product object.
        /// <summary>
        /// Delete product from database based on product object.
        /// </summary>
        /// <returns>
        /// Bool statement whether product was deleted or not.
        /// </returns>
        /// <param name="priceId">price Id.</param>
        bool DeletePriceById(int priceId);
    }
}
