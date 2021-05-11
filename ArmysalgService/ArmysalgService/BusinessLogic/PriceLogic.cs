using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
            try
            {
                Price price = _PriceAccess.GetPriceByProductNo(product.Id);
                if (price != null)
                {
                    price.EndDate = newPrice.StartDate;
                    Put(price);
                    insertedId = _PriceAccess.AddPrice(newPrice, product);
                }
                else
                {

                    insertedId = _PriceAccess.AddPrice(newPrice, product);
                }

            }
            catch
            {
                insertedId = -1;
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
