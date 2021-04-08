using Microsoft.Extensions.Configuration;
using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SpikeProductData.DatabaseLayer
{
    public class ProductDatabaseAccess : IProductAccess
    {
        readonly string _connectionString;

        public ProductDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }
        public int CreateProduct(Product productToAdd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductAll()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
