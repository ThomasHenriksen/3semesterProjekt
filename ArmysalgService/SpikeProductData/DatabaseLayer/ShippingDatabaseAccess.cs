using ArmysalgDataAccess.ModelLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public class ShippingDatabaseAccess
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

            string insertString = "insert into Shipping (price, freeShipping, firstName, lastName, address, zipCode_fk, phone, email) OUTPUT INSERTED.employeeNo " +
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
    }
}

