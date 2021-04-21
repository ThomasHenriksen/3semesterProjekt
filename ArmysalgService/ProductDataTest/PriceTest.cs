using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;

namespace ProductDataTest
{
    public class TestPriceDataAccess
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IProductAccess _productAccess;
        readonly private IPriceAccess _PriceAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestPriceDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _PriceAccess = new PriceDatabaseAccess(_connectionString);
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }
        [Fact]
        public void TestCreateProduct()
        {
            //Arrange
            decimal value = 200;
            DateTime startTime = DateTime.Today;
            DateTime? endTime = null;
            Product product = null;
            //Act
            product = _productAccess.GetProductById(1);
            Price PriceToCreate = new Price(value, startTime, endTime, product);
            int productToReadByID = _PriceAccess.CreatePriceWithOutEndDate(PriceToCreate);

            bool PrisCreate = (productToReadByID > 0);
            
            extraOutput.WriteLine("Product name: " + PriceToCreate.Product.Name + " Product ID: " + PriceToCreate.Product.Id + " Price: " + PriceToCreate.Value + " StartTime: " + PriceToCreate.StartDate + " EndTime: " + PriceToCreate.EndDate);

            //Assert
            Assert.True(PrisCreate);
        }
        [Fact]
        public void TestGetPriceAll()
        {
            //Arrange

            //Act
            List<Price> readPrices = _PriceAccess.GetPriceAll();
            bool PricesWereRead = (readPrices.Count > 0);
            // Print output
            extraOutput.WriteLine("Number of products: " + readPrices.Count);

            //Assert
            Assert.True(PricesWereRead);
        }

        [Fact]
        public void TestGetPriceForByProductId()
        {
            //Arrange
            int idForProduct1 = 1;

            //Act
            Product productToRead = _productAccess.GetProductById(idForProduct1);
        
            Price price = _PriceAccess.GetPriceByProductNoAndNoEndDate(productToRead.Id);
            bool priceForProductFound = (price.Value == 200);
            extraOutput.WriteLine("Product name: " + price.Product.Name + " Product ID: " + price.Product.Id + " Price: " + price.Value);

            //Assert
            Assert.True(priceForProductFound);
        }


        
    }
}
