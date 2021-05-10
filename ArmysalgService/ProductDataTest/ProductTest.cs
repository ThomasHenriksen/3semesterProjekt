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
    }
}
