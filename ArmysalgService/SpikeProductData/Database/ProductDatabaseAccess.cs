using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
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

        //For Test 
        public ProductDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;

        }

        public int CreateProduct(Product aProduct)
        {
            int insertedId = -1;

            string insertString = "insert into product (name, description, purchasePrice, stock, minStock, maxStock) OUTPUT INSERTED.productNo " +
                "values (@Name, @Description, @PurchasePrice, @Stock, @MinStock, @MaxStock)";
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
                    foreach (Category inCategory in aProduct.Category)
                    {
                        CreateProductCategory(insertedId, inCategory);
                    }
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not called and the transaction is rolled back.
                    scope.Complete();
                }
                return insertedId;
            }
        }
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
        private bool CheckProductCategory(int insertedId, Category aCategory)
        {
            string queryString = "select category_id_fk, productNo_fk from ProductCategory where category_id_fk = @categoryId and productNo_fk = @productNo";


            bool exiting = false;


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParamCategoryId = new SqlParameter("@categoryId", aCategory.Id);
                readCommand.Parameters.Add(idParamCategoryId);
                SqlParameter idParamProductNo = new SqlParameter("@productNo", insertedId);
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
        public bool DeleteProductById(int id)
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

        public List<Product> GetProductAll()
        {
            List<Product> foundProducts;
            Product readProduct;

            string queryString = "select productNo, name, description, purchasePrice, stock, minStock, maxStock, isDeleted from Product Where isDeleted = 0";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
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
        private List<Category> GetAllCategoryForProduct(int productId)
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
        /* Three possible returns:
         * A Person object
         * An empty Person object (no match on id)
         * Null - Some error occurred
        */
        public Product GetProductById(int findId)
        {
            Product foundProduct = null;

            string queryString = "select productNo, name, description, purchasePrice, stock, minStock, maxStock, isDeleted from Product where productNo = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", findId);
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

        private Product GetProductFromReader(SqlDataReader productReader)
        {
            Product foundProduct;
            int tempId, tempStock, tempMinStock, tempMaxStock;
            string tempName, tempDescription;
            decimal tempPurchasePrice;
            bool tempIsDeleted;
            List<Category> tempCategory = null;

            tempId = productReader.GetInt32(productReader.GetOrdinal("productNo"));
            tempName = productReader.GetString(productReader.GetOrdinal("name"));
            tempDescription = productReader.GetString(productReader.GetOrdinal("description"));
            tempPurchasePrice = productReader.GetDecimal(productReader.GetOrdinal("purchasePrice"));
            tempStock = productReader.GetInt32(productReader.GetOrdinal("stock"));
            tempMinStock = productReader.GetInt32(productReader.GetOrdinal("minStock"));
            tempMaxStock = productReader.GetInt32(productReader.GetOrdinal("maxStock"));
            tempIsDeleted = productReader.GetBoolean(productReader.GetOrdinal("isDeleted"));

            tempCategory = GetAllCategoryForProduct(tempId);

            foundProduct = new Product(tempId, tempName, tempDescription, tempPurchasePrice, tempStock, tempMinStock, tempMaxStock, tempIsDeleted, tempCategory);

            return foundProduct;
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

