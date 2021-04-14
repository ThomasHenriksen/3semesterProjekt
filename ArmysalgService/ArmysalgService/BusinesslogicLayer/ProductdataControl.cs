using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class ProductdataControl : IProductdata
    {
        IProductAccess _productAccess;

        public ProductdataControl(IConfiguration inConfiguration)
        {
            _productAccess = new ProductDatabaseAccess(inConfiguration);
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
            }
            catch
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
            Product foundProduct;
            try
            {
                foundProduct = _productAccess.GetProductById(idToMatch);
            }
            catch
            {
                foundProduct = null;
            }
            return foundProduct;
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Product> Get()
        {
            List<Product> foundProducts;
            try
            {
                foundProducts = _productAccess.GetProductAll();
            }
            catch
            {
                foundProducts = null;
            }
            return foundProducts;
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
            return _productAccess.UpdateProduct(productToUpdate);
        }
    }
}
