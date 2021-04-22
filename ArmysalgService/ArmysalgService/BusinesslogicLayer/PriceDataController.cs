using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class PriceDataController : IPriceData
    {
        IPriceAccess _PriceAccess;

        public PriceDataController(IConfiguration inConfiguration)
        {
            _PriceAccess = new PriceDatabaseAccess(inConfiguration);
        }

        public int Add(Price newPrice, Product product)
        {
            int insertedId;
            try
            {
                if (newPrice.EndDate != null)
                {
                    insertedId = _PriceAccess. CreatePrice(newPrice, product);
                }
                else
                {
                    Price price = product.price;
                    price.EndDate = newPrice.StartDate;
                    Put(product.price);
                    insertedId = _PriceAccess.CreatePriceWithOutEndDate(newPrice, product);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }


        /*
           *  this method is use to find a product in the database by id
           *  @param idToMatch
           *  
           *  @return Product
         */
        public Price Get(int idToMatch)
        {
            DateTime now = DateTime.Now;
            Price foundPrice = null;
            List<Price> FoundPrices = GetAll(idToMatch);
            int i = 0;
            int j = 0;
            int size = FoundPrices.Count;
            bool foundt = false;
            while (i < size && !foundt)
            {
               
                Price temp = FoundPrices[i];
                if (temp.StartDate < now && now < temp.EndDate)
                {
                    foundPrice = temp;
                    foundt = true;
                }
          
                i++;
            }
            while (j < size && !foundt)
            {

                Price temp = FoundPrices[j];
           
                if (temp.StartDate < now && temp.EndDate == null)
                {
                    foundPrice = temp;
                    foundt = true;
                }
                j++;
            }
            return foundPrice;
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Price> GetAll(int idToMatch)
        {
            List<Price> foundPrices;
            try
            {

                foundPrices = _PriceAccess.GetPriceByProductNo(idToMatch);
            }
            catch
            {
                foundPrices = null;
            }
            return foundPrices;
        }
        /*
           *  this method is use to update a product where ID is use to find product 
           *  @param productToUpdate
           *  @param id 
           *  @return bool
         */
        public bool Put(Price PriceToUpdate)
        {
            return _PriceAccess.UpdateEndDatePrice(PriceToUpdate);
        }
    }
}
