using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
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

        // Add product to the database.
        /// <inheritdoc/>
        public int Add(Product aProduct)
        {
            int insertedId;

            insertedId = _productAccess.AddProduct(aProduct);
            aProduct.Id = insertedId;
            _priceData.Add(aProduct.Price, aProduct);


            return insertedId;
        }

        // Find and return product from database by product number.
        /// <inheritdoc/>
        public Product Get(int idToMatch)
        {
            return _productAccess.GetProductByProductNo(idToMatch);
        }

        // Find and return all product from database.
        /// <inheritdoc/>
        public List<Product> Get()
        {
            return _productAccess.GetProductAll();
        }

        // Update a product to the database.
        /// <inheritdoc/>
        public bool Put(Product productToUpdate)
        {
            return _productAccess.UpdateProduct(productToUpdate);
        }
        // Delete product from database based on product object.
        /// <inheritdoc/>
        public bool Delete(int idToMatch)
        {
            return _productAccess.DeleteProductByProductNo(idToMatch);
        }
    }
}
