using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> foundProducts = await _pAccess.GetProducts();
            return foundProducts;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product foundProduct = await _pAccess.GetProduct(id);
            return foundProduct;
        }
    }
}
