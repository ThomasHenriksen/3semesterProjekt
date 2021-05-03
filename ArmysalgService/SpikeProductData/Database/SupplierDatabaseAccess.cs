using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ArmysalgDataAccess.Database
{
    public class SupplierDatabaseAccess : ISupplierDatabaseAccess
    {
        readonly string _connectionString;

        public SupplierDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        /*
         * For database tests
        */
        public SupplierDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }


        /*
         * Add supplier to the database
         * @param Supplier
         * 
         * @return insertedSupplierId
         */
        public int CreateSupplier(Supplier aSupplier)
        {
            int insertedSupplierId = -1;

            string insertString = "insert into Supplier (name, address, zipCode, city, country, phone, email) OUTPUT INSERTED.id " +
                "values (@Name, @Address, @ZipCode, @City, @Country, @Phone, @Email)";

            using (TransactionScope scope = new TransactionScope())
            {
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
                scope.Complete();
            }
            return insertedSupplierId;
        }

        /* 
         * Delete supplier from the database
         * @param SupplierId
         * 
         * @return bool
        */
        public bool DeleteSupplierById(int supplierId)
        {
            int numberOfRowsDeleted = 0;
            string deleteString = "DELETE FROM supplier WHERE id=@SupplierId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("SupplierId", supplierId);

                conn.Open();
                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }

        /*
         * Three poosible returns:
         * A supplier object
         * An ampty Supplier object (no match on id)
         * Null - Some error occured
         * 
         * @param int SupplierId
         * 
         */
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
