using Microsoft.Extensions.Configuration;
using SpikeProductData.DatabaseLayer;
using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class PersondataControl : IProductdata
    {
        IProductAccess _productAccess;

        public PersondataControl(IConfiguration inConfiguration)
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
