using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace ArmysalgDataAccess.Database
{
    public class ProductDatabaseAccess : IProductDatabaseAccess
    {
        readonly string _connectionString;


        public ProductDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");


        }

        // Used for testing
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public ProductDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;

        }

        // Add product to the database.
        /// <inheritdoc/>
        public int AddProduct(Product aProduct)
        {
            int insertedId = -1;

            string insertString = "insert into product (name, description, purchasePrice, stock, minStock, maxStock) ";
            string output = "OUTPUT INSERTED.productNo ";
            string values = "values (@Name, @Description, @PurchasePrice, @Stock, @MinStock, @MaxStock)";
            insertString = insertString + output + values;
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {
                    SqlParameter nameParam = new SqlParameter("@Name", aProduct.Name);
                    CreateCommand.Parameters.Add(nameParam);
                    SqlParameter descParam = new SqlParameter("@Description", aProduct.Description);
                    CreateCommand.Parameters.Add(descParam);
                    SqlParameter purPriceParam = new SqlParameter("@PurchasePrice", aProduct.PurchasePrice);
                    CreateCommand.Parameters.Add(purPriceParam);
                    SqlParameter stockParam = new SqlParameter("@Stock", aProduct.Stock);
                    CreateCommand.Parameters.Add(stockParam);
                    SqlParameter minStockParam = new SqlParameter("@MinStock", aProduct.MinStock);
                    CreateCommand.Parameters.Add(minStockParam);
                    SqlParameter maxStockParam = new SqlParameter("@MaxStock", aProduct.MaxStock);
                    CreateCommand.Parameters.Add(maxStockParam);

                    con.Open();
                    insertedId = (int)CreateCommand.ExecuteScalar();


                }
                foreach (Category inCategory in aProduct.Category)
                {
                    CreateProductCategory(insertedId, inCategory);
                }
                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
                return insertedId;
            }
        }

        // Checks if product has a connects with category or not.
        /// <summary>
        /// Checks if product has a connects with category or not.
        /// </summary>
        /// <returns>
        /// Bool statement whether product has a connects with category or not.
        /// </returns>
        /// <param name="productNo">product number.</param>
        /// <param name="aCategory">Category object.</param>
        private bool CheckProductCategory(int productNo, Category aCategory)
        {
            string queryString = "select category_id_fk, productNo_fk from ProductCategory where category_id_fk = @categoryId and productNo_fk = @productNo";


            bool exiting = false;


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParamCategoryId = new SqlParameter("@categoryId", aCategory.Id);
                readCommand.Parameters.Add(idParamCategoryId);
                SqlParameter idParamProductNo = new SqlParameter("@productNo", productNo);
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

        // Add a connects with categories
        /// <summary>
        /// Add a connects with categories
        /// </summary>
        /// <returns>
        /// Makes a coonects with a product to categories 
        /// </returns>
        /// <param name="productNo">product number.</param>
        /// <param name="aCategory">Category object.</param>
        private void CreateProductCategory(int insertedId, Category aCategory)
        {
            string insertString = "insert into ProductCategory (category_id_fk, productNo_fk) values (@categoryId, @productNo)";
            if (!CheckProductCategory(insertedId, aCategory))
            {


                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {
                    SqlParameter nameParam = new SqlParameter("@categoryId", aCategory.Id);
                    CreateCommand.Parameters.Add(nameParam);
                    SqlParameter descParam = new SqlParameter("@productNo", insertedId);
                    CreateCommand.Parameters.Add(descParam);

                    con.Open();
                    CreateCommand.ExecuteScalar();

                }
            }
        }

        // Find and return product from database by product number.
        /// <inheritdoc/>
        public Product GetProductByProductNo(int ProductNo)
        {
            Product foundProduct = null;

            DateTime currDate = DateTime.Now;
            string querySelectString = "select ProductNo, ProductName, ProductDescription, purchasePrice, stock, maxStock, minStock, PriceID, price, startDate, endDate, isDeleted ";
            string queryFromString = "from ProductPrice ";
            string queryWhereString = "where isDeleted = 0 and startDate >= @CurrDate and @CurrDate <= endDate or endDate is null and productNo = @Id ";
            string queryString = querySelectString + queryFromString + queryWhereString;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter DateParam = new SqlParameter("@CurrDate", currDate);
                readCommand.Parameters.Add(DateParam);
                SqlParameter idParam = new SqlParameter("@Id", ProductNo);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader productReader = readCommand.ExecuteReader();
                foundProduct = new Product();
                while (productReader.Read())
                {
                    foundProduct = GetProductFromReader(productReader);
                }
            }
            return foundProduct;
        }

        // Find and return all product from database.
        /// <inheritdoc/>
        public List<Product> GetProductAll()
        {
            List<Product> foundProducts;
            Product readProduct;

            DateTime currDate = DateTime.Now;
            string querySelectString = "select ProductNo, ProductName, ProductDescription, purchasePrice, stock, maxStock, minStock, PriceID, price, startDate, endDate, isDeleted ";
            string queryFromString = "from ProductPrice ";
            string queryWhereString = "where isDeleted = 0 and startDate >= @CurrDate and @CurrDate <= endDate or endDate is null ";
            string queryString = querySelectString + queryFromString + queryWhereString;
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@CurrDate", currDate);
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

        // Find and return all Category from database for a product number.
        /// <summary>
        /// Find and return all Category from database for a product number.
        /// </summary>
        /// <returns>
        /// List of category objects.
        /// </returns>
        /// <param name="productNo">product number.</param>
        private List<Category> GetAllCategoryForProduct(int productNo)
        {
            List<Category> foundCategorys;
            Category readCategory;

            string queryString = "select id, name, description from Category inner join ProductCategory on ProductCategory.category_id_fk = Category.id where ProductCategory.productNo_fk = @ProductId ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@ProductId", productNo);
                readCommand.Parameters.Add(idParam);
                con.Open();

                SqlDataReader CategoryReader = readCommand.ExecuteReader();

                foundCategorys = new List<Category>();
                while (CategoryReader.Read())
                {
                    readCategory = GetCategoryFromReader(CategoryReader);
                    foundCategorys.Add(readCategory);
                }
            }
            return foundCategorys;

        }

        // Update a product to the database.
        /// <inheritdoc/>
        public bool UpdateProduct(Product productToUpdate)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Product SET name = @inName, description = @inDescription, purchasePrice = @inPurchasePrice, stock = @inStock, minStock = @inMinStock, maxStock = @inMaxStock, isDeleted = @inIsDelete from Product where productNo = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                numRowsUpdated = con.Execute(queryString,
                                 new
                                 {
                                     inName = productToUpdate.Name,
                                     inDescription = productToUpdate.Description,
                                     inPurchasePrice = productToUpdate.PurchasePrice,

                                     inStock = productToUpdate.Stock,
                                     inMinStock = productToUpdate.MinStock,
                                     inMaxStock = productToUpdate.MaxStock,
                                     inIsDelete = productToUpdate.IsDeleted,
                                     Id = productToUpdate.Id
                                 });
            }
            foreach (Category inCategory in productToUpdate.Category)
            {
                CreateProductCategory(productToUpdate.Id, inCategory);
            }
            return (numRowsUpdated == 1);
        }

        // Delete product from database based on product object.
        /// <inheritdoc/>
        public bool DeleteProductByProductNo(int id)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Product SET  isDeleted = @inIsDelete from Product where productNo = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString,
                 new
                 {
                     inIsDelete = 1,
                     Id = id
                 });
            }
            return (numRowsUpdated == 1);
        }

        // Build and return product object and price object based on SQL data read.
        /// <summary>
        /// Build and return product object and price object based on SQL data read.
        /// </summary>
        /// <returns>
        /// product object.
        /// </returns>
        /// <param name="productReader">SQL data read.</param>
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
            List<Category> tempCategory = null;

            // Build a  product object
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

            // Build a price object
            tempPriceId = productReader.GetInt32(productReader.GetOrdinal("PriceID"));
            tempValue = productReader.GetDecimal(productReader.GetOrdinal("price"));
            tempStartDate = productReader.GetDateTime(productReader.GetOrdinal("startDate"));
            if (!productReader.IsDBNull(productReader.GetOrdinal("endDate")))
            {
                tempEndDate = productReader.GetDateTime(productReader.GetOrdinal("endDate"));
            }

            foundPrice = new Price(tempPriceId, tempValue, tempStartDate, tempEndDate);
            foundProduct = new Product(tempId, tempName, tempDescription, tempPurchasePrice, tempStock, tempMinStock, tempMaxStock, tempIsDeleted, foundPrice, tempCategory);

            return foundProduct;
        }
        // Build and return category object based on SQL data read.
        /// <summary>
        /// Build and return category object based on SQL data read.
        /// </summary>
        /// <returns>
        /// category object.
        /// </returns>
        /// <param name="categoryReader">SQL data read.</param>
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

