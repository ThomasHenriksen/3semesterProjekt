using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private IProductDatabaseAccess _productAccess;
        private IPriceLogic _priceData;
        private ICategoryDatabaseAccess _categoryAccess;
        public ProductLogic(IConfiguration inConfiguration)
        {
            _productAccess = new ProductDatabaseAccess(inConfiguration);
            _priceData = new PriceLogic(inConfiguration);
            _categoryAccess = new CategoryDatabaseAccess(inConfiguration);
        }

        /*
           *  this method is use to create a new product in the database
           *  @param newProduct
           *  
           *  @return insertedId
         */
        public int Add(Product newProduct)
        {
            int insertedId;
            try
            {
                insertedId = _productAccess.CreateProduct(newProduct);
                newProduct.Id = insertedId;
                _priceData.Add(newProduct.Price, newProduct);
            }
            catch (Exception e)
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int idToMatch)
        {
            return _productAccess.DeleteProductById(idToMatch);
        }
        /*
           *  this method is use to find a product in the database by id
           *  @param idToMatch
           *  
           *  @return Product
         */
        public Product Get(int idToMatch)
        {
            return _productAccess.GetProductById(idToMatch);
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Product> Get()
        {
            return _productAccess.GetProductAll();
        }
        /*
           *  this method is use to update a product where ID is use to find product 
           *  @param productToUpdate
           *  @param id 
           *  @return bool
         */
        public bool Put(Product productToUpdate, int id)
        {
            productToUpdate.Id = id;

            Price checkPrice = _priceData.Get(productToUpdate.Id);
            if (checkPrice == null)
            {
                _priceData.Add(productToUpdate.Price, productToUpdate);

            }
            else
            {
                if (checkPrice.Id != productToUpdate.Id)
                {
                    _priceData.Add(productToUpdate.Price, productToUpdate);
                }
            }



            return _productAccess.UpdateProduct(productToUpdate);
        }
    }
}
