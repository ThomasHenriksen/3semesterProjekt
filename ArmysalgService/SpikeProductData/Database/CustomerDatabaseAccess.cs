using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ArmysalgDataAccess.Database
{
    public class CustomerDatabaseAccess : ICustomerDatabaseAccess
    {
        readonly string _connectionString;

        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        // Used for testing
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public CustomerDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add customer to the database.
        /// <inheritdoc/>
        public int AddCustomer(Customer aCustomer)
        {
            int insertedCustomerNo = -1;

            string insertString = "insert into Customer (firstName, lastName, address, zipCode_fk, phone, email) OUTPUT INSERTED.customerNo " +
                "values (@FirstName, @LastName, @Address, @ZipCode, @Phone, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter firstNameParam = new SqlParameter("@FirstName", aCustomer.FirstName);
                CreateCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", aCustomer.LastName);
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
                insertedCustomerNo = (int)CreateCommand.ExecuteScalar();
            }
            return insertedCustomerNo;
        }

        // Find and return customer from database by customer number.
        /// <inheritdoc/>
        public Customer GetCustomerByCustomerNo(int customerNo)
        {
            Customer foundCustomer = null;

            string queryString = "select customerNo, firstName, lastName, address, zipCode, city, phone, email from Customer" + " join zipCity zc on customer.zipCode_fk = zc.zipCode" + " where customerNo = @CustomerNo";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@CustomerNo", customerNo);
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

        // Find and return customer from database by customer email.
        /// <inheritdoc/>
        public Customer GetCustomerByCustomerEmail(string customerEmail)
        {
            Customer foundCustomer = null;

            string queryString = "SELECT Customer.customerNo, Customer.firstName, Customer.lastName, Customer.address, Customer.phone, Customer.email, ZipCity.zipCode, ZipCity.city FROM Customer INNER JOIN ZipCity ON Customer.zipCode_fk = ZipCity.zipCode WHERE(dbo.Customer.email = @email)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter emailParam = new SqlParameter("@email", customerEmail);
                readCommand.Parameters.Add(emailParam);

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

        // Delete customer from database based on customer number.
        /// <inheritdoc/>
        public bool DeleteCustomerByCustomerNo(int customerNo)
        {
            int numberOfRowsDeleted = 0;
            string deleteString = "DELETE FROM Customer WHERE customerNo = @CustomerNo";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("@CustomerNo", customerNo);

                conn.Open();
                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }

        // Checks if customer has AspNetUser by comparing email parameter.
        /// <inheritdoc/>
        public bool CustomerHasAspNetUser(Customer aCustomer)
        {
            bool customerHasAspNetUser = false;

            string queryString = "select count(1) from AspNetUsers where email = (@Email) ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand GetCommand = new SqlCommand(queryString, con))
            {
                SqlParameter emailParam = new SqlParameter("@Email", aCustomer.Email);
                GetCommand.Parameters.Add(emailParam);

                con.Open();
                int count = (int)GetCommand.ExecuteScalar();

                if (count == 1)
                {
                    customerHasAspNetUser = true;
                }

                return customerHasAspNetUser;
            }


        }

        // Connects customer to AspNetUser in database.
        /// <inheritdoc/>
        public void ConnectCustomerToAspNetUser(Customer aCustomer)
        {
            string insertString = "update AspNetUsers set customerNo_fk = (@CustomerNo) where email = (@Email) ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand UpdateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter customerNoParam = new SqlParameter("@CustomerNo", aCustomer.CustomerNo);
                UpdateCommand.Parameters.Add(customerNoParam);
                SqlParameter emailParam = new SqlParameter("@Email", aCustomer.Email);
                UpdateCommand.Parameters.Add(emailParam);

                con.Open();
                UpdateCommand.ExecuteScalar();
            }
        }

        // Build and return customer object based on SQL data read.
        /// <summary>
        /// Build and return customer object based on SQL data read.
        /// </summary>
        /// <returns>
        /// Customer object.
        /// </returns>
        /// <param name="customerReader">SQL data read.</param>
        private Customer GetCustomerFromReader(SqlDataReader customerReader)
        {
            Customer foundCustomer;
            int tempCustomerNo;
            string tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail;

            tempCustomerNo = customerReader.GetInt32(customerReader.GetOrdinal("customerNo"));
            tempFirstName = customerReader.GetString(customerReader.GetOrdinal("firstName"));
            tempLastName = customerReader.GetString(customerReader.GetOrdinal("lastName"));
            tempAddress = customerReader.GetString(customerReader.GetOrdinal("address"));
            tempZipCode = customerReader.GetString(customerReader.GetOrdinal("zipCode"));
            tempCity = customerReader.GetString(customerReader.GetOrdinal("city"));
            tempPhone = customerReader.GetString(customerReader.GetOrdinal("phone"));
            tempEmail = customerReader.GetString(customerReader.GetOrdinal("email"));

            foundCustomer = new Customer(tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail, tempCustomerNo);

            return foundCustomer;
        }
    }
}