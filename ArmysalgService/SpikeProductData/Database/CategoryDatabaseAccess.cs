using ArmysalgDataAccess.Model;
using Dapper;
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
    public class CategoryDatabaseAccess : ICategoryDatabaseAccess
    {
        readonly string _connectionString;

        public CategoryDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
           
        }

        //For Test 
        public CategoryDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        
        }

        public int CreateCategory(Category aCategory)
        {
            int insertedId = -1;

            string insertString = "insert into category (name, description) OUTPUT INSERTED.id " + " values (@Name, @Description)";

            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {

                    SqlParameter nameParam = new SqlParameter("@Name", aCategory.Name);
                    CreateCommand.Parameters.Add(nameParam);
                    SqlParameter descParam = new SqlParameter("@Description", aCategory.Description);
                    CreateCommand.Parameters.Add(descParam);

                    con.Open();
                    insertedId = (int)CreateCommand.ExecuteScalar();
                    foreach (Product inProduct in aCategory.ProductCategory)
                    {
                        CreateProductCategory(insertedId, inProduct);
                    }
                }
                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
            }
            return insertedId;
        }
        private void CreateProductCategory(int insertedId, Product aProduct)
        {
            string insertString = "insert into ProductCategory (category_id_fk, productNo_fk) values (@categoryId, @productNo)";
          
                if (!CheckProductCategory(insertedId, aProduct))
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                    {
                        SqlParameter nameParam = new SqlParameter("@categoryId", insertedId);
                        CreateCommand.Parameters.Add(nameParam);
                        SqlParameter descParam = new SqlParameter("@productNo", aProduct.Id);
                        CreateCommand.Parameters.Add(descParam);

                        con.Open();
                        CreateCommand.ExecuteScalar();

                    }
                }
           
        }
        private bool CheckProductCategory(int insertedId, Product aProduct)
        {
            string queryString = "select category_id_fk, productNo_fk from ProductCategory where category_id_fk = @categoryId and productNo_fk = @productNo";


            bool exiting = false;

          
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(queryString, con))
                {
                    SqlParameter idParamCategoryId = new SqlParameter("@categoryId", insertedId);
                    readCommand.Parameters.Add(idParamCategoryId);
                    SqlParameter idParamProductNo = new SqlParameter("@productNo", aProduct.Id);
                    readCommand.Parameters.Add(idParamProductNo);
                    con.Open();

                    SqlDataReader reader = readCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        exiting = true;
                    }
                }

           
         
            return exiting;
        }
        public List<Category> GetCategorysAll()
        {
            List<Category> foundCategorys;
            Category readCategory;

            string queryString = "select id, name, description from category ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();

                SqlDataReader categoryReader = readCommand.ExecuteReader();

                foundCategorys = new List<Category>();
                while (categoryReader.Read())
                {
                    readCategory = GetCategoryFromReader(categoryReader);
                    foundCategorys.Add(readCategory);
                }
            }
            return foundCategorys;

        }

        /* Three possible returns:
         * A Person object
         * An empty Person object (no match on id)
         * Null - Some error occurred
        */
        public Category GetCategoryById(int findId)
        {
            Category foundCategory = null;

            string queryString = "select id, name, description from category where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader categoryReader = readCommand.ExecuteReader();
                foundCategory = new Category();
                while (categoryReader.Read())
                {
                    foundCategory = GetCategoryFromReader(categoryReader);
                }
            }
            return foundCategory;
        }

        public bool UpdateCategory(Category categoryToUpdate)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE category SET name = @inName, description = @inDescription from category where id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                numRowsUpdated = con.Execute(queryString,
                                 new
                                 {
                                     inName = categoryToUpdate.Name,
                                     inDescription = categoryToUpdate.Description,
                                     Id = categoryToUpdate.Id
                                 });
            }
            foreach (Product inProduct in categoryToUpdate.ProductCategory)
            {
                CreateProductCategory(categoryToUpdate.Id, inProduct);
            }
            return (numRowsUpdated == 1);
        }
       
        private List<Product> GetAllProductsForACategory(int categoryId)
        {

            List<Product> foundProducts;
            Product readProduct;

            DateTime currDate = DateTime.Now;
            string querySelectString = "select ProductNo, ProductName, ProductDescription, purchasePrice, stock, maxStock, minStock, PriceID, price, startDate, endDate, isDeleted ";
            string queryFromString = "from ProductCategoryView ";
            string queryWhereString = "where CategoryId = @CategoryId and isDeleted = 0 and startDate >= @CurrDate and @CurrDate <= endDate or endDate is null ";
            string queryString = querySelectString + queryFromString + queryWhereString;
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter DateParam = new SqlParameter("@CurrDate", currDate);
                readCommand.Parameters.Add(DateParam);
                SqlParameter idParam = new SqlParameter("@CategoryId", categoryId);
                readCommand.Parameters.Add(idParam);
                con.Open();

                SqlDataReader productReader = readCommand.ExecuteReader();

                foundProducts = new List<Product>();
                while (productReader.Read())
                {
                    readProduct = GetProductFromReader(productReader);
                    foundProducts.Add(readProduct);
                }
            }
            return foundProducts;
        }
        private Category GetCategoryFromReader(SqlDataReader categoryReader)
        {

            Category foundCateGory;
            int tempId;
            string tempName, tempDescription;
            List<Product> tempProducts = null;

            tempId = categoryReader.GetInt32(categoryReader.GetOrdinal("id"));
            tempName = categoryReader.GetString(categoryReader.GetOrdinal("name"));
            tempDescription = categoryReader.GetString(categoryReader.GetOrdinal("description"));
            tempProducts = GetAllProductsForACategory(tempId);

            foundCateGory = new Category(tempId, tempName, tempDescription, tempProducts);

            return foundCateGory;
        }

        private Product GetProductFromReader(SqlDataReader productReader)
        {
            Product foundProduct;
            int tempId, tempStock, tempMinStock, tempMaxStock;
            string tempName, tempDescription;
            decimal tempPurchasePrice;
            bool tempIsDeleted;
            Price foundPrice;
            int tempPriceId;
            decimal tempValue;
            DateTime tempStartDate;
            DateTime? tempEndDate = null;


            tempId = productReader.GetInt32(productReader.GetOrdinal("productNo"));
            tempName = productReader.GetString(productReader.GetOrdinal("ProductName"));
            tempDescription = productReader.GetString(productReader.GetOrdinal("ProductDescription"));
            tempPurchasePrice = productReader.GetDecimal(productReader.GetOrdinal("purchasePrice"));
            tempStock = productReader.GetInt32(productReader.GetOrdinal("stock"));
            tempMinStock = productReader.GetInt32(productReader.GetOrdinal("minStock"));
            tempMaxStock = productReader.GetInt32(productReader.GetOrdinal("maxStock"));
            if (!productReader.IsDBNull(productReader.GetOrdinal("isDeleted")))
            {
                tempIsDeleted = productReader.GetBoolean(productReader.GetOrdinal("isDeleted"));
            }
            else
            {
                tempIsDeleted = false;
            }

            tempPriceId = productReader.GetInt32(productReader.GetOrdinal("PriceID"));
            tempValue = productReader.GetDecimal(productReader.GetOrdinal("price"));
            tempStartDate = productReader.GetDateTime(productReader.GetOrdinal("startDate"));
            if (!productReader.IsDBNull(productReader.GetOrdinal("endDate")))
            {
                tempEndDate = productReader.GetDateTime(productReader.GetOrdinal("endDate"));
            }

         
            foundPrice = new Price(tempPriceId, tempValue, tempStartDate, tempEndDate);
            foundProduct = new Product(tempId, tempName, tempDescription, tempPurchasePrice, tempStock, tempMinStock, tempMaxStock, tempIsDeleted, foundPrice);

            return foundProduct;
        }

        public bool DeleteCategoryByCategoryId(int categoryId)
        {
            int numberOfRowsDeleted = 0;
            string deleteString = "DELETE FROM Category WHERE id = @CategoryId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteString, conn))
            {
                deleteCommand.Parameters.AddWithValue("@CategoryId", categoryId);

                conn.Open();
                numberOfRowsDeleted = deleteCommand.ExecuteNonQuery();
            }
            return (numberOfRowsDeleted > 0);
        }
    }
}
