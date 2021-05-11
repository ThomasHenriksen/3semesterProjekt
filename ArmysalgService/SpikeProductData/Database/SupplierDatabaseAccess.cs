using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArmysalgDataAccess.Database
{
    public class SupplierDatabaseAccess : ISupplierDatabaseAccess
    {
        readonly string _connectionString;

        public SupplierDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        // Used for testing
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public SupplierDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add customer to the database.
        /// <inheritdoc/>
        public int AddSupplier(Supplier aSupplier)
        {
            int insertedSupplierId = -1;

            string insertString = "insert into Supplier (name, address, zipCode, city, country, phone, email) OUTPUT INSERTED.id " +
                "values (@Name, @Address, @ZipCode, @City, @Country, @Phone, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter nameParam = new SqlParameter("@Name", aSupplier.Name);
                CreateCommand.Parameters.Add(nameParam);
                SqlParameter addressParam = new SqlParameter("@Address", aSupplier.Address);
                CreateCommand.Parameters.Add(addressParam);
                SqlParameter zipCodeParam = new SqlParameter("@ZipCode", aSupplier.ZipCode);
                CreateCommand.Parameters.Add(zipCodeParam);
                SqlParameter cityParam = new SqlParameter("@City", aSupplier.City);
                CreateCommand.Parameters.Add(cityParam);
                SqlParameter countryParam = new SqlParameter("@Country", aSupplier.Country);
                CreateCommand.Parameters.Add(countryParam);
                SqlParameter phoneParam = new SqlParameter("@Phone", aSupplier.Phone);
                CreateCommand.Parameters.Add(phoneParam);
                SqlParameter emailParam = new SqlParameter("@Email", aSupplier.Email);
                CreateCommand.Parameters.Add(emailParam);

                con.Open();
                insertedSupplierId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedSupplierId;
        }

        // Find and return supplier from database by supplier id.
        /// <inheritdoc/>
        public Supplier GetSupplierById(int supplierId)
        {
            Supplier foundSupplier = null;

            string queryString = "select id, name, address, zipCode, city, country, phone, email from supplier where id = @SupplierId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@SupplierId", supplierId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader supplierReader = readCommand.ExecuteReader();
                foundSupplier = new Supplier();
                while (supplierReader.Read())
                {
                    foundSupplier = GetSupplierFromReader(supplierReader);
                }
            }
            return foundSupplier;
        }

        // Find and return all suppliers from database.
        /// <inheritdoc/>
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> foundSuppliers = new List<Supplier>();
            Supplier readSupplier;

            string queryString = "select id, name, address, zipCode, city, country, phone, email from Supplier";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();

                SqlDataReader supplierReader = readCommand.ExecuteReader();

                while (supplierReader.Read())
                {
                    readSupplier = GetSupplierFromReader(supplierReader);
                    foundSuppliers.Add(readSupplier);
                }
            }
            return foundSuppliers;
        }

        // Delete supplier from database based on supplier id.
        /// <inheritdoc/>
        public bool DeleteSupplierById(int supplierId)
        {
            int numberOfRowsDeleted = 0;

            string deleteString = "DELETE FROM supplier WHERE id=@SupplierId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("@SupplierId", supplierId);

                conn.Open();

                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }

        // Build and return supplier object based on SQL data read.
        /// <summary>
        /// Build and return supplier object based on SQL data read.
        /// </summary>
        /// <returns>
        /// Supplier object.
        /// </returns>
        /// <param name="supplierReader">SQL data read.</param>
        private Supplier GetSupplierFromReader(SqlDataReader supplierReader)
        {
            Supplier foundSupplier;
            int tempSupperId;
            string tempName, tempAddress, tempZipCode, tempCity, tempCountry, tempPhone, tempEmail;

            tempSupperId = supplierReader.GetInt32(supplierReader.GetOrdinal("id"));
            tempName = supplierReader.GetString(supplierReader.GetOrdinal("name"));
            tempAddress = supplierReader.GetString(supplierReader.GetOrdinal("address"));
            tempZipCode = supplierReader.GetString(supplierReader.GetOrdinal("zipCode"));
            tempCity = supplierReader.GetString(supplierReader.GetOrdinal("city"));
            tempCountry = supplierReader.GetString(supplierReader.GetOrdinal("country"));
            tempPhone = supplierReader.GetString(supplierReader.GetOrdinal("phone"));
            tempEmail = supplierReader.GetString(supplierReader.GetOrdinal("email"));

            foundSupplier = new Supplier(tempSupperId, tempName, tempAddress, tempZipCode, tempCity, tempCountry, tempPhone, tempEmail);

            return foundSupplier;
        }
    }
}
