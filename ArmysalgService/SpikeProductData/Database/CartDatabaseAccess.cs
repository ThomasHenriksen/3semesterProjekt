using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArmysalgDataAccess.Database
{
    public class CartDatabaseAccess : ICartDatabaseAccess
    {
        readonly string _connectionString;
        private ISalesLineItemDatabaseAcces _salelineitemDatabaseAccess;

        public CartDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
            _salelineitemDatabaseAccess = new SalesLineItemDatabaseAccess(configuration);
        }

        // Used for testing
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public CartDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
            _salelineitemDatabaseAccess = new SalesLineItemDatabaseAccess(inConnectionString);
        }

        // Add cart to the database.
        /// <inheritdoc/>
        public int AddCart(Cart aCart, Customer aCustomer)
        {
            int insertedId = -1;

            string insertString = "insert into Cart (lastUpdated, customerNo_fk) OUTPUT INSERTED.id values (@LastUpdated, @CustomerNo) ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter lastUpdatedParam = new SqlParameter("@LastUpdated", aCart.LastUpdated);
                CreateCommand.Parameters.Add(lastUpdatedParam);
                SqlParameter customerNoParam = new SqlParameter("@CustomerNo", aCustomer.CustomerNo);
                CreateCommand.Parameters.Add(customerNoParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        // Find and return cart from database by cart ID.
        /// <inheritdoc/>
        public Cart GetCartById(int cartId)
        {
            Cart FoundCart = null;

            string queryString = "select id, lastUpdated from Cart where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", cartId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader cartReader = readCommand.ExecuteReader();
                FoundCart = new Cart();
                while (cartReader.Read())
                {
                    FoundCart = GetCartFromReader(cartReader);
                }
            }
            return FoundCart;
        }

        // Find and return cart from database by customer number.
        /// <inheritdoc/>
        public Cart GetCartByCustomerNo(int CustomerNo)
        {
            Cart FoundCart = null;

            string queryString = "select id, lastUpdated from Cart where customerNo_fk = @CustomerNo";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@CustomerNo", CustomerNo);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader cartReader = readCommand.ExecuteReader();
                FoundCart = new Cart();
                while (cartReader.Read())
                {
                    FoundCart = GetCartFromReader(cartReader);
                }
            }
            return FoundCart;
        }

        // Update cart in the database.
        /// <inheritdoc/>
        public bool UpdateCart(Cart aCart)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Cart SET lastUpdated = @inLastUpdated from Cart where id = @inId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                numRowsUpdated = con.Execute(queryString,
                                 new
                                 {
                                     inLastUpdated = aCart.LastUpdated,
                                     inId = aCart.Id,
                                 });

            }

            return (numRowsUpdated == 1);
        }

        // Delete cart from database based on cart ID.
        /// <inheritdoc/>
        public bool DeleteCartByCartId(int cartId)
        {
            int numRowsUpdated = 0;
            string queryString = "Delete Cart where id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString,
                 new
                 {
                     Id = cartId
                 });
            }
            return (numRowsUpdated == 1);
        }

        // Build and return cart object based on SQL data read.
        /// <summary>
        /// Build and return cart object based on SQL data read.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="cartReader">SQL data read.</param>
        private Cart GetCartFromReader(SqlDataReader cartReader)
        {
            Cart foundCart;
            int tempId;
            DateTime tempLastUpdated;
            List<SalesLineItem> tempSalesLineItem = null;

            tempId = cartReader.GetInt32(cartReader.GetOrdinal("id"));
            tempLastUpdated = cartReader.GetDateTime(cartReader.GetOrdinal("lastUpdated"));
            if (_salelineitemDatabaseAccess.GetSalesLineItems(tempId, null) != null)
            {
                tempSalesLineItem = _salelineitemDatabaseAccess.GetSalesLineItems(tempId, null);
            }

            foundCart = new Cart(tempId, tempLastUpdated, tempSalesLineItem);

            return foundCart;
        }
    }
}