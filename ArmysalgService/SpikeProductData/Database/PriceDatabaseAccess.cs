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
    public class PriceDatabaseAccess : IPriceDatabaseAccess
    {
        readonly string _connectionString;
        
        public PriceDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
         
        }

        //For Test 
        public PriceDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
          
        }

        public int CreatePrice(Price aPrice, Product product)
        {
            int insertedId = -1;

            string insertString = "insert into Price (price, startDate, endDate, productNo_fk) OUTPUT INSERTED.id " +
                "values (@price, @startDate, @endDate, @productNo_fk)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter priceParam = new SqlParameter("@price", aPrice.Value);
                CreateCommand.Parameters.Add(priceParam);
                SqlParameter startDateParam = new SqlParameter("@startDate", aPrice.StartDate);
                CreateCommand.Parameters.Add(startDateParam);
                SqlParameter endDateParam = new SqlParameter("@endDate", aPrice.EndDate);
                CreateCommand.Parameters.Add(endDateParam);

                SqlParameter productNoParam = new SqlParameter("@productNo_fk", product.Id);
                CreateCommand.Parameters.Add(productNoParam);


                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }
        public int CreatePriceWithOutEndDate(Price aPrice, Product product)
        {
            int insertedId = -1;

            string insertString = "insert into Price (price, startDate, productNo_fk) OUTPUT INSERTED.id " +
                "values (@price, @startDate, @productNo_fk)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter priceParam = new SqlParameter("@price", aPrice.Value);
                CreateCommand.Parameters.Add(priceParam);
                SqlParameter startDateParam = new SqlParameter("@startDate", aPrice.StartDate);
                CreateCommand.Parameters.Add(startDateParam);
                SqlParameter productNoParam = new SqlParameter("@productNo_fk", product.Id);
                CreateCommand.Parameters.Add(productNoParam);


                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }
        public List<Price> GetPriceAll()
        {
            List<Price> foundPrices;
            Price readPrice;

            string queryString = "select id, price, startDate, endDate, productNo_fk from Price";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();

                SqlDataReader priceReader = readCommand.ExecuteReader();

                foundPrices = new List<Price>();
                while (priceReader.Read())
                {
                    readPrice = GetPriceFromReader(priceReader);
                    foundPrices.Add(readPrice);
                }
            }
            return foundPrices;

        }
        public List<Price> GetPriceByProductNo( int productNo)
        {
            List<Price> foundPrices;
            Price readPrice;

            string queryString = "select id, price, startDate, endDate, productNo_fk from Price where productNo_fk = @productNo_fk";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {

                SqlParameter productNoParam = new SqlParameter("@productNo_fk", productNo);
                readCommand.Parameters.Add(productNoParam);
                con.Open();

                SqlDataReader priceReader = readCommand.ExecuteReader();

                foundPrices = new List<Price>();
                while (priceReader.Read())
                {
                    readPrice = GetPriceFromReader(priceReader);
                    foundPrices.Add(readPrice);
                }
            }
            return foundPrices;

        }
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

        public Price GetPriceByProductNoAndNoEndDate(int productNo)
        {
            Price foundPrice = null;

            string queryString = "select id, price, startDate, endDate, productNo_fk from Price where productNo_fk = @productNo_fk AND endDate IS NULL";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter productNoParam = new SqlParameter("@productNo_fk", productNo);
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
            if (!priceReader.IsDBNull(priceReader.GetOrdinal("endDate"))) {
                tempEndDate = priceReader.GetDateTime(priceReader.GetOrdinal("endDate"));
            }
            


            foundPrice = new Price(tempId, tempValue, tempStartDate, tempEndDate);




            return foundPrice;
        }

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
    }
}
