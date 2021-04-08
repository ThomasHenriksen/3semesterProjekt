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
            List<Product> foundProducts;
            Product readProduct;

            string queryString = "select productNo, name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted from Product";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();

                SqlDataReader productReader = readCommand.ExecuteReader();

                foundProducts = new List<Product>();
                while (productReader.Read())
                {
                    readProduct = GetProductFromReader(productReader);
                    foundProducts.Add(readProduct);
                }
            }
            return foundProducts;
           
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }

        private Product GetProductFromReader(SqlDataReader productReader)
        {
            Product foundProduct;
            int tempId, tempStock, tempMinStock, tempMaxStock;
            string tempName, tempDescription, tempStatus;
            decimal tempPurchasePrice;
            bool tempIsDeleted;

            tempId = productReader.GetInt32(productReader.GetOrdinal("productNo"));
            tempName = productReader.GetString(productReader.GetOrdinal("name"));
            tempDescription = productReader.GetString(productReader.GetOrdinal("description"));
            tempPurchasePrice = productReader.GetDecimal(productReader.GetOrdinal("purchasePrice"));
            tempStatus = productReader.GetString(productReader.GetOrdinal("status"));
            tempStock = productReader.GetInt32(productReader.GetOrdinal("stock"));
            tempMinStock = productReader.GetInt32(productReader.GetOrdinal("minStock"));
            tempMaxStock = productReader.GetInt32(productReader.GetOrdinal("maxStoct"));
            tempIsDeleted = productReader.GetBoolean(productReader.GetOrdinal("isDeleted"));

            foundProduct = new Product(tempId, tempName, tempDescription, tempPurchasePrice, tempStatus, tempStock, tempMinStock, tempMaxStock, tempIsDeleted);

            return foundProduct;
        }
    }
}
