using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{   // brian
    public class ShippingDatabaseAccess : IShippingDatabaseAccess
    {
        readonly string _connectionString;

        public ShippingDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmyalgConnection");
        }

        //For test
        public ShippingDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateShipping(Shipping aShipping)
        {
            int insertedId = -1;

            string insertString = "insert into Shipping (price, freeShipping, firstName, lastName, address, zipCode_fk, phone, email) OUTPUT INSERTED.id " +
                "values (@Price, @FreeShipping, @FirstName, @LastName, @Address, @ZipCode, @Phone, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter price = new SqlParameter("@Price", aShipping.Price);
                CreateCommand.Parameters.Add(price);
                SqlParameter freeShipping = new SqlParameter("@FreeShipping", aShipping.FreeShipping);
                CreateCommand.Parameters.Add(freeShipping);
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
            string queryString = "select price, freeShipping, firstName, lastName, address, zipCode_fk, phone, email from Shipping" + " join zipCity zc on shipping.zipCode_fk = zc.zipCode" + " where id = @ShippingID";
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

        public Shipping GetShippingFromReader(SqlDataReader shippingReader)
        {
            Shipping foundShipping;
            int tempShippingID;
            double tempPrice;
            bool tempFreeShipping;
            string tempFirstName, tempLastName, tempAddress, tempZipCode_fk, tempCity, tempPhone, tempEmail;

            //tempShippingID = shippingReader.GetInt32(shippingReader.GetOrdinal("id"));
            tempPrice = shippingReader.GetDouble(shippingReader.GetOrdinal("price"));
            tempFreeShipping = shippingReader.GetBoolean(shippingReader.GetOrdinal("freeShipping"));
            tempFirstName = shippingReader.GetString(shippingReader.GetOrdinal("firstName"));
            tempLastName = shippingReader.GetString(shippingReader.GetOrdinal("lastName"));
            tempAddress = shippingReader.GetString(shippingReader.GetOrdinal("address"));
            tempZipCode_fk = shippingReader.GetString(shippingReader.GetOrdinal("zipCode_fk"));
            tempCity = shippingReader.GetString(shippingReader.GetOrdinal("city"));
            tempPhone = shippingReader.GetString(shippingReader.GetOrdinal("phone"));
            tempEmail = shippingReader.GetString(shippingReader.GetOrdinal("email"));

            foundShipping = new(tempPrice, tempFreeShipping, tempFirstName, tempLastName, tempAddress, tempZipCode_fk, tempCity, tempPhone, tempEmail);

            return foundShipping;

        }

        public bool DeleteShippingByshippingID(int shippingID)
        {
            throw new NotImplementedException();
        }

        public List<Shipping> GetAllShippings()
        {
            throw new NotImplementedException();
        }
    }
}