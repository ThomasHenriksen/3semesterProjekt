using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArmysalgDataAccess.Database
{
    public class ShippingDatabaseAccess : IShippingDatabaseAccess
    {
        readonly string _connectionString;

        public ShippingDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        //For test
        public ShippingDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateShipping(Shipping aShipping)
        {
            int insertedId = -1;

            string insertString = "insert into Shipping (price, firstName, lastName, address, zipCode_fk, phone, email) OUTPUT INSERTED.id " +
                "values (@Price, @FirstName, @LastName, @Address, @ZipCode, @Phone, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter price = new SqlParameter("@Price", aShipping.Price);
                CreateCommand.Parameters.Add(price);
                SqlParameter firstNameParam = new SqlParameter("@FirstName", aShipping.FirstName);
                CreateCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", aShipping.LastName);
                CreateCommand.Parameters.Add(lastNameParam);
                SqlParameter address = new SqlParameter("@Address", aShipping.Address);
                CreateCommand.Parameters.Add(address);
                SqlParameter zipCode = new SqlParameter("@ZipCode", aShipping.ZipCode);
                CreateCommand.Parameters.Add(zipCode);
                SqlParameter phone = new SqlParameter("@Phone", aShipping.Phone);
                CreateCommand.Parameters.Add(phone);
                SqlParameter email = new SqlParameter("@Email", aShipping.Email);
                CreateCommand.Parameters.Add(email);


                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public Shipping GetShippingByShippingID(int shippingID)
        {

            Shipping foundShipping = null;
            string queryString = "SELECT dbo.Shipping.id, dbo.Shipping.price, dbo.Shipping.firstName, dbo.Shipping.lastName, dbo.Shipping.address, dbo.Shipping.zipCode_fk, dbo.Shipping.phone, dbo.Shipping.email, dbo.ZipCity.zipCode, dbo.ZipCity.city " +
                "FROM dbo.Shipping INNER JOIN dbo.ZipCity ON dbo.Shipping.zipCode_fk = dbo.ZipCity.zipCode" +
                " WHERE(dbo.Shipping.id = @ShippingID) ";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@ShippingID", shippingID);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader shippingReader = readCommand.ExecuteReader();
                foundShipping = new Shipping();
                while (shippingReader.Read())
                {
                    foundShipping = GetShippingFromReader(shippingReader);
                }
            }
            return foundShipping;
        }

        private Shipping GetShippingFromReader(SqlDataReader shippingReader)
        {
            Shipping foundShipping;
            int tempShippingID;
            double tempPrice;

            string tempFirstName, tempLastName, tempAddress, tempZipCode_fk, tempCity, tempPhone, tempEmail;

            tempShippingID = shippingReader.GetInt32(shippingReader.GetOrdinal("id"));
            tempPrice = decimal.ToDouble(shippingReader.GetDecimal(shippingReader.GetOrdinal("price")));
            tempFirstName = shippingReader.GetString(shippingReader.GetOrdinal("firstName"));
            tempLastName = shippingReader.GetString(shippingReader.GetOrdinal("lastName"));
            tempAddress = shippingReader.GetString(shippingReader.GetOrdinal("address"));
            tempZipCode_fk = shippingReader.GetString(shippingReader.GetOrdinal("zipCode_fk"));
            tempCity = shippingReader.GetString(shippingReader.GetOrdinal("city"));
            tempPhone = shippingReader.GetString(shippingReader.GetOrdinal("phone"));
            tempEmail = shippingReader.GetString(shippingReader.GetOrdinal("email"));

            foundShipping = new(tempShippingID, tempPrice, tempFirstName, tempLastName, tempAddress, tempZipCode_fk, tempCity, tempPhone, tempEmail);

            return foundShipping;

        }

        public bool DeleteShippingById(int ShippingId)
        {
            int numberOfRowsDeleted = 0;
            string deleteString = "DELETE FROM shipping WHERE id=@ShippingId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("ShippingId", ShippingId);

                conn.Open();
                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }

        public List<Shipping> GetAllShippings()
        {
            throw new NotImplementedException();
        }
    }
}