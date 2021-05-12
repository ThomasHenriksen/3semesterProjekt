using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.BusinessLogic
{
    public class PriceLogic : IPriceLogic
    {
        IPriceDatabaseAccess _PriceAccess;

        public PriceLogic(IConfiguration inConfiguration)
        {
            _PriceAccess = new PriceDatabaseAccess(inConfiguration);
        }

        // Add price to the database.
        /// <inheritdoc/>
        public int Add(Price newPrice, Product product)
        {
            int insertedId;

            Price price = _PriceAccess.GetPriceByProductNo(product.Id);
            if (price != null)
            {
                price.EndDate = newPrice.StartDate;
                Put(price);
                insertedId = _PriceAccess.AddPrice(newPrice, product);
                newPrice.Id = insertedId;
            }
            else
            {

                insertedId = _PriceAccess.AddPrice(newPrice, product);
                newPrice.Id = insertedId;
            }
            return insertedId;
        }




        // Update a price in the database.
        /// <inheritdoc/>
        public bool Put(Price PriceToUpdate)
        {
            return _PriceAccess.UpdateEndDatePrice(PriceToUpdate);
        }
    }
}
