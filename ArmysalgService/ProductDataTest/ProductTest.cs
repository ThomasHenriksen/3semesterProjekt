using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

namespace ProductDataTest
{
    public class TestProductDataAccess
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IProductDatabaseAccess _productDatabaseAccess;
        readonly private IPriceDatabaseAccess _priceDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestProductDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _productDatabaseAccess = new ProductDatabaseAccess(_connectionString);
            _priceDatabaseAccess = new PriceDatabaseAccess(_connectionString);
        }

        [Fact]
        public void TestGetProductAll()
        {
            //Arrange

            //Act
            List<Product> readProducts = _productDatabaseAccess.GetProductAll();
            bool productsWereRead = (readProducts.Count > 0);
            // Print output
            extraOutput.WriteLine("Number of products: " + readProducts.Count);

            //Assert
            Assert.True(productsWereRead);
        }

        [Fact]
        public void TestGetProductById()
        {
            //Arrange
            int idForProduct1 = 277;

            //Act
            Product productToRead = _productDatabaseAccess.GetProductById(idForProduct1);
            bool product1wasFound = (productToRead.Id == idForProduct1);
            extraOutput.WriteLine("Product name: " + productToRead.Name + " Product ID: " + productToRead.Id);

            //Assert
            Assert.True(product1wasFound);
        }

        [Fact]
        public void CreateProductTest()
        {
            //Arrange
            decimal value = 99;
            DateTime startDate = DateTime.Now;
            DateTime? endDate = null;
            Price priceToTest = new(value, startDate, endDate);

            string name = "Busker for test";
            string description = "Sort";
            decimal purchasePrice = 340;
            int stock = 5;
            int minStock = 3;
            int maxStock = 10;
            bool isDeleted = false;
            List<Category> categoryListForTest = new List<Category>();
            Product productToCreate = new Product(name, description, purchasePrice, stock, minStock, maxStock, isDeleted, priceToTest, categoryListForTest);

            //Act
            int productIdOfInsertedProduct = _productDatabaseAccess.CreateProduct(productToCreate);
            productToCreate.Id = productIdOfInsertedProduct;
            int idOfInsertedPrice = _priceDatabaseAccess.CreatePriceWithOutEndDate(priceToTest, productToCreate);
            Product productToRead = _productDatabaseAccess.GetProductById(productIdOfInsertedProduct);

            extraOutput.WriteLine("PRODUKTINFO");
            extraOutput.WriteLine("Produkt nr:" + productToRead.Id);
            extraOutput.WriteLine("Prokust navn: " + productToRead.Name);
            extraOutput.WriteLine("Produkt beskrives: " + productToRead.Description);
            extraOutput.WriteLine("Antal på lager: " + productToRead.Stock);
            extraOutput.WriteLine("Min på lager: " + productToRead.MinStock);
            extraOutput.WriteLine("Max på lager: " + productToRead.MaxStock);
            extraOutput.WriteLine("Er fjernet: " + productToRead.IsDeleted.ToString());

            //Assert
            Assert.Equal(productIdOfInsertedProduct.ToString(), productToRead.Id.ToString());
            Assert.Equal(productToCreate.Name, productToRead.Name);
            Assert.Equal(productToCreate.Description, productToRead.Description);
            Assert.Equal(productToCreate.Stock.ToString(), productToRead.Stock.ToString());
            Assert.Equal(productToCreate.MinStock.ToString(), productToRead.MinStock.ToString());
            Assert.Equal(productToCreate.MaxStock.ToString(), productToRead.MaxStock.ToString());
            Assert.Equal(productToCreate.IsDeleted.ToString(), productToRead.IsDeleted.ToString());

            //CleanUp
            _productDatabaseAccess.DeleteProductById(productIdOfInsertedProduct);
            _priceDatabaseAccess.DeletePriceById(idOfInsertedPrice);
        }
        [Fact]
        public void TestUpdateProduct()
        {
            //Arrange
            int targetId = 8;
            string name = "bukser";
            string description = "blå";
            decimal purchasePrice = 3220;
            int stock = 10;
            int minStock = 3;
            int maxStock = 10;
            //Act
            Product findProductToUpdate = _productDatabaseAccess.GetProductById(targetId);
            findProductToUpdate.Name = name;
            findProductToUpdate.Description = description;
            findProductToUpdate.PurchasePrice = purchasePrice;
            findProductToUpdate.Stock = stock;
            findProductToUpdate.MinStock = minStock;
            findProductToUpdate.MaxStock = maxStock;
            bool productToUpdateByID = _productDatabaseAccess.UpdateProduct(findProductToUpdate);
            //Assert
            Assert.True(productToUpdateByID);
        }
        [Fact]
        public void TestDeleteProduct()
        {
            //Arrange
            string name = "bukser";
            string description = "sort";
            decimal purchasePrice = 340;
            string status = "Indorder";
            int stock = 10;
            int minStock = 3;
            int maxStock = 10;
            bool isDeleted = false;
            Price priceForTest = new Price();
            List<Category> listForTest = new List<Category>();
            //Act
            Product productToCreate = new Product(name, description, purchasePrice, stock, minStock, maxStock, isDeleted, priceForTest, listForTest);
            int productToReadByID = _productDatabaseAccess.CreateProduct(productToCreate);
            bool productToUpdateByID = _productDatabaseAccess.DeleteProductById(productToReadByID);
            //Assert
            Assert.True(_productDatabaseAccess.GetProductById(productToReadByID).IsDeleted);
        }
    }
}
