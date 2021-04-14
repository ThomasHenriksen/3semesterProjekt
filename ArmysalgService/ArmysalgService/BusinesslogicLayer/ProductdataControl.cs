using Microsoft.Extensions.Configuration;
using SpikeProductData.DatabaseLayer;
using SpikeProductData.ModelLayer;
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

        public int Add(Product newProduct)
        {
            int insertedId;
            try {
                insertedId = _productAccess.CreateProduct(newProduct);
            } catch {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int idToMatch)
        {
            Product foundProduct = null;
            bool delete = false;
            try
            {
                foundProduct = _productAccess.GetProductById(idToMatch);
            }
            catch
            {
                foundProduct = null;
            }
            return delete;
        }

        public Product Get(int idToMatch)
        {
            Product foundProduct;
            try {
                foundProduct = _productAccess.GetProductById(idToMatch);
            } catch {
                foundProduct = null;
            }
            return foundProduct;
        }

        public List<Product> Get()
        {
            List<Product> foundProducts;
            try {
                foundProducts = _productAccess.GetProductAll();
            } catch {
                foundProducts = null;
            }
            return foundProducts;
        }

        public bool Put(Product productToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
