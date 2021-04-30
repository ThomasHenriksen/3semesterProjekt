﻿using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ArmysalgDataAccess.Database
{
    public class SalesLineItemDatabaseAccess : ISalesLineItemDatabaseAcces
    {
        readonly string _connectionString;
        private IProductDatabaseAccess _productDatabase;
        public SalesLineItemDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
            _productDatabase = new ProductDatabaseAccess(configuration);
        }
        public int CreateSalesLineItem(SalesLineItem aSalesLineItem, Cart aCart)
        {
            int insertedId = -1;

            string insertString = "insert into SalesLineItem (quantity, cart_id_fk, productNo_fk) OUTPUT INSERTED.id " + " values (@Quantity, @CartId @ProductId)";

            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {

                    SqlParameter nameParam = new SqlParameter("@Quantity", aSalesLineItem.Quantity);
                    CreateCommand.Parameters.Add(nameParam);
                    SqlParameter cartIdParam = new SqlParameter("@CartId", aCart.Id);
                    CreateCommand.Parameters.Add(cartIdParam);
                    SqlParameter ProductIdParam = new SqlParameter("@ProductId", aSalesLineItem.Products.Id);
                    CreateCommand.Parameters.Add(ProductIdParam);

                    con.Open();
                    insertedId = (int)CreateCommand.ExecuteScalar();

                }
                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
            }
            return insertedId;
        }
        public bool UpdateSalesLineItem(SalesLineItem aSalesLineItem, Cart? aCart, SalesOrder? aSalesOrder)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE category SET quantity = @inQuantity ";
            if (aCart != null)
            {
                queryString += " cart_id_fk = @inCartId ";
            }
            else if (aSalesOrder != null)
            {
                queryString += " salesNo_fk = @inSaleId ";
            }

            queryString += " from category where id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (aCart != null)
                {
                    numRowsUpdated = con.Execute(queryString,
                new
                {
                    inQuantity = aSalesLineItem.Quantity,
                    inCartId = aCart.Id,
                    Id = aSalesLineItem.Id
                });
                }
                if (aSalesOrder != null)
                {
                    numRowsUpdated = con.Execute(queryString,
                new
                {
                    inQuantity = aSalesLineItem.Quantity,
                    inSaleId = aSalesOrder.SalesNo,
                    Id = aSalesLineItem.Id
                });
                }
            }

            return (numRowsUpdated == 1);
        }


        public SalesLineItem GetSalesLineItem(int? cartId, int? salesNo)
        {
            SalesLineItem FoundSalesLineItem = null;


            string queryString = "select id, quantity, cart_id_fk, productNo_fk, salesNo_fk from SalesLineItem ";
            if (cartId != null && salesNo == null)
            {
                queryString += " where cart_id_fk = @cartId and salesNo_fk IS NULL ";
            }
            else if (salesNo != null && cartId == null)
            {
                queryString += " where salesNo_fk = @salesNo ";
            }
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                if (cartId != null && salesNo == null)
                {
                    SqlParameter idParam = new SqlParameter("@cartId", cartId);
                    readCommand.Parameters.Add(idParam);
                }
                else if (salesNo != null && cartId == null)
                {
                    SqlParameter idParam = new SqlParameter("@salesNo", salesNo);
                    readCommand.Parameters.Add(idParam);
                }
                con.Open();

                SqlDataReader salesLineItemReader = readCommand.ExecuteReader();
                FoundSalesLineItem = new SalesLineItem();
                while (salesLineItemReader.Read())
                {
                    FoundSalesLineItem = GetSalesLineItemFromReader(salesLineItemReader);
                }
            }
            return FoundSalesLineItem;
        }

        public List<SalesLineItem> GetSalesLineItems(int? cartId, int? salesNo)
        {
            List<SalesLineItem> foundSalesLineItems;
            SalesLineItem FoundSalesLineItem = null;


            string queryString = "select id, quantity, cart_id_fk, productNo_fk, salesNo_fk from SalesLineItem ";
            if (cartId != null && salesNo == null)
            {
                queryString += " where cart_id_fk = @cartId and salesNo_fk IS NULL ";
            }
            else if (salesNo != null && cartId == null)
            {
                queryString += " where salesNo_fk = @salesNo";
            }
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                if (cartId != null && salesNo == null)
                {
                    SqlParameter idParam = new SqlParameter("@cartId", cartId);
                    readCommand.Parameters.Add(idParam);
                }
                else if (salesNo != null && cartId == null)
                {
                    SqlParameter idParam = new SqlParameter("@salesNo", salesNo);
                    readCommand.Parameters.Add(idParam);
                }
                con.Open();

                SqlDataReader salesLineItemReader = readCommand.ExecuteReader();
                foundSalesLineItems = new List<SalesLineItem>();
                while (salesLineItemReader.Read())
                {
                    FoundSalesLineItem = GetSalesLineItemFromReader(salesLineItemReader);
                    foundSalesLineItems.Add(FoundSalesLineItem);
                }
            }
            return foundSalesLineItems;
        }
        public bool DeleteSaleLineItemById(SalesLineItem aSalesLineItem)
        {
            bool deleted = false;

            string insertString = "DELETE FROM SalesLineItem where id = @Id";

            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {

                    SqlParameter nameParam = new SqlParameter("@Id", aSalesLineItem.Id);
                    CreateCommand.Parameters.Add(nameParam);


                    con.Open();
                    deleted = (bool)CreateCommand.ExecuteScalar();

                }

                return deleted;
            }
        }
        private SalesLineItem GetSalesLineItemFromReader(SqlDataReader salesLineItemReader)
        {

            SalesLineItem foundSalesLineItem;
            int tempId, quantity;

            Product tempProduct = null;


            tempId = salesLineItemReader.GetInt32(salesLineItemReader.GetOrdinal("id"));
            quantity = salesLineItemReader.GetInt32(salesLineItemReader.GetOrdinal("lastUpdated"));
            tempProduct = _productDatabase.GetProductById(salesLineItemReader.GetInt32(salesLineItemReader.GetOrdinal("productNo_fk")));


            foundSalesLineItem = new SalesLineItem(tempId, quantity, tempProduct);

            return foundSalesLineItem;
        }
    }
}

