using ArmysalgDataAccess.Model;
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


        public int CreateCart(Cart aCart)
        {
            int insertedId = -1;

            string insertString = "insert into Cart (lastUpdated, customerNo_fk) OUTPUT INSERTED.id values (@LastUpdated, @CustomerNo) ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter lastUpdatedParam = new SqlParameter("@LastUpdated", aCart.LastUpdated);
                CreateCommand.Parameters.Add(lastUpdatedParam);
                SqlParameter customerNoParam = new SqlParameter("@CustomerNo", aCart.Customer.CustomerNo);
                CreateCommand.Parameters.Add(customerNoParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
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

        public Cart GetCartById(int cartId)
        {
            Cart foundCart = null;

            string queryString = "select lastUpdated from Cart where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", cartId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader cartReader = readCommand.ExecuteReader();
                foundCart = new Cart();
                while (cartReader.Read())
                {
                    foundCart = GetCartFromReader(cartReader);
                }
            }
            return foundCart;
        }

        private Cart GetCartFromReader(SqlDataReader cartReader)
        {
            Cart foundCart;
            DateTime tempLastUpdated;

            tempLastUpdated = cartReader.GetDateTime(cartReader.GetOrdinal("lastUpdated"));

            foundCart = new Cart(tempLastUpdated);

            return foundCart;
        }
    }
}
