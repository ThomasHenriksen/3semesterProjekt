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
        private ISalesLineItemDatabaseAcces _salelineitem;
        private string connectionString;

        public CartDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
            _salelineitem = new SalesLineItemDatabaseAccess(configuration);
        }

       /*
         * Used for testing.
        */
        public CartDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
            _salelineitem = new SalesLineItemDatabaseAccess(inConnectionString);
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
        public Cart GetCartById(int id)
        {
            Cart FoundCart = null;


            string queryString = "select id, lastUpdated from Cart where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", id);
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
            string queryString = "Delete Cart where id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString,
                 new
                 {
                     Id = id
                 });
            }
            return (numRowsUpdated == 1);
        }

        private Cart GetCartFromReader(SqlDataReader CartReader)
        {

            Cart foundCart;
            int tempId;
            DateTime tempLastUpdated;
            List<SalesLineItem> tempSalesLineItem = null;


            tempId = CartReader.GetInt32(CartReader.GetOrdinal("id"));
            tempLastUpdated = CartReader.GetDateTime(CartReader.GetOrdinal("lastUpdated"));
            if (_salelineitem.GetSalesLineItems(tempId, null) != null)
            {
                tempSalesLineItem = _salelineitem.GetSalesLineItems(tempId, null);
            }

            foundCart = new Cart(tempId, tempLastUpdated, tempSalesLineItem);

            return foundCart;
        }


    }
}
