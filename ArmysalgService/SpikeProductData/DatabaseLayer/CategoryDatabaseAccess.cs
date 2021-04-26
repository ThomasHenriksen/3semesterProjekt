﻿using ArmysalgDataAccess.ModelLayer;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    class CategoryDatabaseAccess : ICategoryAccess
    {
        readonly string _connectionString;
        private IProductAccess _productAccess;
        public CategoryDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }

        //For Test 
        public CategoryDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }

        public int CreateCategory(Category aCategory)
        {
            int insertedId = -1;

            string insertString = "insert into category (name, description) OUTPUT INSERTED.id " + " values (@Name, @Description)";

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

        public bool UpdateProduct(Category categoryToUpdate)
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
            List<Product> tempProducts;

            tempId = categoryReader.GetInt32(categoryReader.GetOrdinal("id"));
            tempName = categoryReader.GetString(categoryReader.GetOrdinal("name"));
            tempDescription = categoryReader.GetString(categoryReader.GetOrdinal("description"));
            tempProducts = _productAccess.GetAllProductsForCategory(tempId);

            foundCateGory = new Category(tempId, tempName, tempDescription, tempProducts);

            return foundCateGory;
        }
    }
}
