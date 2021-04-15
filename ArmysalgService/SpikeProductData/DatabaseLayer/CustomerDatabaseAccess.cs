using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public class CustomerDatabaseAccess : ICustomerAccess
    {
        readonly string _connectionString;

        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        //For Test 
        public CustomerDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateCustomer(Customer aCustomer)
        {
            int insertedId = -1;

            string insertString = "insert into product (firstName, lastName, address, zipCode, phone, email) OUTPUT INSERTED.customerNo " +
                "values (@FirstName, @LastName, @Address, @ZipCode, @Phone, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter firstNameParam = new SqlParameter("@FirstName", aCustomer.FirstName);
                CreateCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", aCustomer.FirstName);
                CreateCommand.Parameters.Add(lastNameParam);
                SqlParameter address = new SqlParameter("@Address", aCustomer.Address);
                CreateCommand.Parameters.Add(address);
                SqlParameter zipCode = new SqlParameter("@ZipCode", aCustomer.ZipCode);
                CreateCommand.Parameters.Add(zipCode);
                SqlParameter phone = new SqlParameter("@Phone", aCustomer.Phone);
                CreateCommand.Parameters.Add(phone);
                SqlParameter email = new SqlParameter("@Email", aCustomer.Email);
                CreateCommand.Parameters.Add(email);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }




        /* Three possible returns:
         * A Customer object
         * An empty Customer object (no match on customerNo)
         * Null - Some error occurred
        */
        public Customer GetCustomerByCustomerNo(int findCustomerNo)
        {
            Customer foundCustomer = null;

            string queryString = "select customerNo, firstName, address, zipCode, city, phone, email from Customer where customerNo = @CustomerNo" + "join zipCity zc on customer.zipCity_fk = zc.zipCode";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@CustomerNo", findCustomerNo);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetCustomerFromReader(customerReader);
                }
            }
            return foundCustomer;
        }

        private Customer GetCustomerFromReader(SqlDataReader customerReader)
        {
            Customer foundCustomer;
            int tempCustomerNo;
            string tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail;

            tempCustomerNo = customerReader.GetInt32(customerReader.GetOrdinal("customerNo"));
            tempFirstName = customerReader.GetString(customerReader.GetOrdinal("firstName"));
            tempLastName = customerReader.GetString(customerReader.GetOrdinal("lastName"));
            tempAddress = customerReader.GetString(customerReader.GetOrdinal("addressName"));
            tempZipCode = customerReader.GetString(customerReader.GetOrdinal("zipCodeName"));
            tempCity = customerReader.GetString(customerReader.GetOrdinal("cityName"));
            tempPhone = customerReader.GetString(customerReader.GetOrdinal("phoneName"));
            tempEmail = customerReader.GetString(customerReader.GetOrdinal("emailName"));

            foundCustomer = new Customer(tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail, tempCustomerNo);

            return foundCustomer;
        }

        public bool DeleteCustomerByCustomerNo(int customerNo)
        {
            throw new NotImplementedException();
        }
    }
}