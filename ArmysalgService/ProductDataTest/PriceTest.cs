using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

namespace ArmysalgDataTest
{
    public class TestPriceDataAccess
    {
        private readonly ITestOutputHelper extraOutput;
        private readonly IPriceDatabaseAccess _priceDatabaseAccess;
        private readonly IProductDatabaseAccess _productDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestPriceDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _priceDatabaseAccess = new PriceDatabaseAccess(_connectionString);
            _productDatabaseAccess = new ProductDatabaseAccess(_connectionString);
        }

        /*
         * Tests CreatePriceWithOutEndDate method.
         */
        [Fact]
        public void CreatePriceTest()
        {
            //Arrange
            decimal value = 99;
            DateTime startDate = DateTime.Now;
            DateTime? endDate = null;
            Price priceToCreate = new (value, startDate, endDate);

            string productName = "Army Bukser";
            string productDescription = "Busker i Army farve";
            decimal purchasePrice = 200;
            int stock = 10;
            int minStock = 5;
            int maxStock = 50;
            bool isDeleted = false;
            List<Category> categories = new();

            Product productToCreate = new (productName, productDescription, purchasePrice, stock, minStock, maxStock, isDeleted, priceToCreate, categories);
            
            //Act
            int idOfInsertedProduct = _productDatabaseAccess.AddProduct(productToCreate);
            productToCreate.Id = idOfInsertedProduct;
            int idOfInsertedPrice = _priceDatabaseAccess.AddPrice(priceToCreate, productToCreate);
            Price priceToRead = _priceDatabaseAccess.GetPriceById(idOfInsertedPrice);

            extraOutput.WriteLine("PRIS");
            extraOutput.WriteLine("Pris ID: " + priceToRead.Id);
            extraOutput.WriteLine("Prisen: " + priceToRead.Value);
            extraOutput.WriteLine("Start dato: " + priceToRead.StartDate);

            //Assert
            Assert.Equal(idOfInsertedPrice.ToString(), priceToRead.Id.ToString());
            Assert.Equal(priceToCreate.Value, priceToRead.Value);
            Assert.Equal(priceToCreate.StartDate.ToString(), priceToRead.StartDate.ToString());

            //CleanUp
            _priceDatabaseAccess.DeletePriceById(idOfInsertedPrice);
            _productDatabaseAccess.DeleteProductByProductNo(idOfInsertedProduct);
        }
    }
}
