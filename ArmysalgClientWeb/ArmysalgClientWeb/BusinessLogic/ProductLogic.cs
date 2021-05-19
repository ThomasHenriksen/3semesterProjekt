using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.BusinessLogic
{
    public class ProductLogic
    {
        ProductService _pAccess;
        public ProductLogic()
        {
            _pAccess = new ProductService();
        }
        // Method to retrieve all products.
        /// <summary>
        /// Method to retrieve all products.
        /// </summary>
        /// <returns>
        /// list of product object.
        /// </returns>
        /// <param name="id">Product id.</param>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> foundProducts = await _pAccess.GetProducts();
            return foundProducts;
        }
        // Method to retrieve a product by id.
        /// <summary>
        /// Method to retrieve a product by id.
        /// </summary>
        /// <returns>
        /// product object.
        /// </returns>
        /// <param name="id">Product id.</param>
        public async Task<Product> GetProductById(int id)
        {
            Product foundProduct = await _pAccess.GetProduct(id);
            return foundProduct;
        }
    }
}
