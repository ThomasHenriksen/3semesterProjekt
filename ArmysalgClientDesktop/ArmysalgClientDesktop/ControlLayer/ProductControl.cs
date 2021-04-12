using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
    public class ProductControl
    {
        ProductServiceAccess _pAccess;

        public ProductControl()
        {
            _pAccess = new ProductServiceAccess();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> foundProducts = await _pAccess.GetProducts();
            return foundProducts;
        }

        public async Task<int> SaveProduct(string name, string description, decimal purchasePrice, string status,
            int stock, int minStock, int maxStock, bool isDeleted)
        {
            Product newProduct = new Product(name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted);
            int insertedId = await _pAccess.SaveProduct(newProduct);
            return insertedId;
        }
    }
}
