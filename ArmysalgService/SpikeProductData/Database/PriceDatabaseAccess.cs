using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace ArmysalgDataAccess.Database
{
    public class PriceDatabaseAccess : IPriceDatabaseAccess
    {
        readonly string _connectionString;

        public PriceDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");

        }

        // Used for testing
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public PriceDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;

        }
        // Add price to the database.
        /// <inheritdoc/>
        public int AddPrice(Price aPrice, Product product)
        {
            int insertedId = -1;

            string insertString = "insert into Price (price, startDate, endDate, productNo_fk) OUTPUT INSERTED.id " +
                "values (@price, @startDate, @endDate, @productNo_fk)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter endDateParam = new SqlParameter("@endDate", DBNull.Value);
                SqlParameter priceParam = new SqlParameter("@price", aPrice.Value);
                CreateCommand.Parameters.Add(priceParam);
                SqlParameter startDateParam = new SqlParameter("@startDate", aPrice.StartDate);
                CreateCommand.Parameters.Add(startDateParam);
                if (aPrice.EndDate != null)
                {
                    endDateParam = new SqlParameter("@endDate", aPrice.EndDate);
                }
                CreateCommand.Parameters.Add(endDateParam);
                SqlParameter productNoParam = new SqlParameter("@productNo_fk", product.Id);
                CreateCommand.Parameters.Add(productNoParam);


                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        // Find and return price from database by price id.
        /// <inheritdoc/>
        public Price GetPriceById(int priceId)
        {
            Price foundPrice = null;

            string queryString = "select id, price, startDate, endDate, productNo_fk from Price where id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter productNoParam = new SqlParameter("@id", priceId);
                readCommand.Parameters.Add(productNoParam);

                con.Open();

                SqlDataReader priceReader = readCommand.ExecuteReader();
                foundPrice = new Price();
                while (priceReader.Read())
                {
                    foundPrice = GetPriceFromReader(priceReader);
                }
            }
            return foundPrice;

        }
        // Find and return price from database by product number.
        /// <inheritdoc/>
        public Price GetPriceByProductNo(int productNo)
        {
            Price foundPrice = null;

            string queryString = "select id, price, startDate, endDate, productNo_fk from Price where productNo_fk = @productNo_fk and endDate is null";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter productNoParam = new SqlParameter("@id", productNo);
                readCommand.Parameters.Add(productNoParam);
                SqlDataReader priceReader = null;
                con.Open();
                try
                {

                    priceReader = readCommand.ExecuteReader();
                }
                catch { }
               
                if (priceReader != null)
                {
                    foundPrice = new Price();
                    while (priceReader.Read())
                    {
                        foundPrice = GetPriceFromReader(priceReader);
                    }
                }
            }
            return foundPrice;

        }
        // Update a price in the database.
        /// <inheritdoc/>
        public bool UpdateEndDatePrice(Price priceToUpdate)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Price SET endDate = @inEndDate from Price where id = @id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                numRowsUpdated = con.Execute(queryString,
                                 new
                                 {
                                     inEndDate = priceToUpdate.EndDate,
                                     Id = priceToUpdate.Id
                                 });
            }

            return (numRowsUpdated == 1);
        }



        // Delete product from database based on product object.
        /// <inheritdoc/>
        public bool DeletePriceById(int priceId)
        {
            int numberOfRowsDeleted = 0;
            string deleteString = "DELETE FROM price WHERE id=@PriceId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("@PriceId", priceId);

                conn.Open();
                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }

        // Build and return price object based on SQL data read.
        /// <summary>
        /// Build and return price object based on SQL data read.
        /// </summary>
        /// <returns>
        /// price object.
        /// </returns>
        /// <param name="priceReader">SQL data read.</param>
        private Price GetPriceFromReader(SqlDataReader priceReader)
        {
            Price foundPrice;
            int tempId;
            decimal tempValue;
            DateTime tempStartDate;
            DateTime? tempEndDate = null;



            tempId = priceReader.GetInt32(priceReader.GetOrdinal("id"));
            tempValue = priceReader.GetDecimal(priceReader.GetOrdinal("price"));
            tempStartDate = priceReader.GetDateTime(priceReader.GetOrdinal("startDate"));
            if (!priceReader.IsDBNull(priceReader.GetOrdinal("endDate")))
            {
                tempEndDate = priceReader.GetDateTime(priceReader.GetOrdinal("endDate"));
            }

            foundPrice = new Price(tempId, tempValue, tempStartDate, tempEndDate);

            return foundPrice;
        }

    }
}
