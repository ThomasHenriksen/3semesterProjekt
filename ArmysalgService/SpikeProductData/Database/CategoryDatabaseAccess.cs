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
                scope.Complete();
            }
            return insertedId;
        }
        private void CreateProductCategory(int insertedId, Product aProduct)
        {
            string insertString = "insert into ProductCategory (category_id_fk, productNo_fk) values (@categoryId, @productNo)";
            using (TransactionScope scope = new TransactionScope())
            {
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
                scope.Complete();
            }
        }
        private bool CheckProductCategory(int insertedId, Product aProduct)
        {
            string queryString = "select category_id_fk, productNo_fk from ProductCategory where category_id_fk = @categoryId and productNo_fk = @productNo";


            bool exiting = false;

            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope())
            {
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

                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
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
        public List<Category> GetAllCategorysForAProduct(int productId)
        {
            List<Category> foundCategorys;
            Category readCategory;

            string queryString = "select id, name, description from Category inner join ProductCategory on ProductCategory.category_id_fk = Category.id where ProductCategory.productNo_fk = @ProductId ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@ProductId", productId);
                readCommand.Parameters.Add(idParam);
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
        private Category GetCategoryFromReader(SqlDataReader categoryReader)
        {

            Category foundCateGory;
            int tempId;
            string tempName, tempDescription;
         

            tempId = categoryReader.GetInt32(categoryReader.GetOrdinal("id"));
            tempName = categoryReader.GetString(categoryReader.GetOrdinal("name"));
            tempDescription = categoryReader.GetString(categoryReader.GetOrdinal("description"));
      

            foundCateGory = new Category(tempId, tempName, tempDescription);

            return foundCateGory;
        }
    }
}
