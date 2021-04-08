﻿using Microsoft.Extensions.Configuration;
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

        //For Test 
        public ProductDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateProduct(Product aProduct)
        {
            int insertedId = -1;

            string insertString = "insert into product (name, description, purchasePrice, status, stock, minStock, maxStock) OUTPUT INSERTED.productNo " +
                "values (@Name, @Description, @PurchasePrice, @Status, @Stock, @MinStock, @MaxStock)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter nameParam = new SqlParameter("@Name", aProduct.Name);
                CreateCommand.Parameters.Add(nameParam);
                SqlParameter descParam = new SqlParameter("@Description", aProduct.Description);
                CreateCommand.Parameters.Add(descParam);
                SqlParameter purPriceParam = new SqlParameter("@PurchasePrice", aProduct.PurchasePrice);
                CreateCommand.Parameters.Add(purPriceParam);
                SqlParameter statusParam = new SqlParameter("@Status", aProduct.Status);
                CreateCommand.Parameters.Add(statusParam);
                SqlParameter stockParam = new SqlParameter("@Stock", aProduct.Stock);
                CreateCommand.Parameters.Add(stockParam);
                SqlParameter minStockParam = new SqlParameter("@MinStock", aProduct.MinStock);
                CreateCommand.Parameters.Add(minStockParam);
                SqlParameter maxStockParam = new SqlParameter("@MaxStock", aProduct.MaxStock);
                CreateCommand.Parameters.Add(maxStockParam);
            }
            return insertedId;
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

        /* Three possible returns:
         * A Person object
         * An empty Person object (no match on id)
         * Null - Some error occurred
        */
        public Product GetProductById(int findId)
        {
            Product foundProduct = null;

            string queryString = "select productNo, name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted from Product where productNo = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader productReader = readCommand.ExecuteReader();
                foundProduct = new Product();
                while (productReader.Read())
                {
                    foundProduct = GetProductFromReader(productReader);
                }
            }
            return foundProduct;
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
            tempMaxStock = productReader.GetInt32(productReader.GetOrdinal("maxStock"));
            tempIsDeleted = productReader.GetBoolean(productReader.GetOrdinal("isDeleted"));

            foundProduct = new Product(tempId, tempName, tempDescription, tempPurchasePrice, tempStatus, tempStock, tempMinStock, tempMaxStock, tempIsDeleted);

            return foundProduct;
        }
    }
}