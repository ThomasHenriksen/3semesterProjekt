﻿using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public class CartDatabaseAccess : ICartDatabaseAccess
    {
        readonly string _connectionString;

        public CartDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }


        public int CreateCart(Cart aCart, Customer customer)
        {
            int insertedId = -1;

            string insertString = "insert into Cart (lastUpdated, customerNo_fk) OUTPUT INSERTED.id values (@LastUpdated, @CustomerNo) ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter lastUpdatedParam = new SqlParameter("@LastUpdated", aCart.LastUpdated);
                CreateCommand.Parameters.Add(lastUpdatedParam);
                SqlParameter customerNoParam = new SqlParameter("@CustomerNo", customer.CustomerNo);
                CreateCommand.Parameters.Add(customerNoParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

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

        public bool DeleteCartByCartId(int id)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Cart SET isDeleted = @inIsDelete from Cart where productId = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString,
                 new
                 {
                     inIsDelete = 1,
                     Id = id
                 });
            }
            return (numRowsUpdated == 1);
        }


    }
}
