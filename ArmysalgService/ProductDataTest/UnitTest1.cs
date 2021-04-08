using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using SpikeProductData.DatabaseLayer;
using SpikeProductData.ModelLayer;

namespace ProductDataTest
{
    public class TestProductDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private IProductAccess _productAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestProductDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }

        [Fact]
        public void TestGetProductAll()
        {
            //Arrange

            //Act
            List<Product> readProducts = _productAccess.GetProductAll();
            bool productsWereRead = (readProducts.Count > 0);
            // Print output
            extraOutput.WriteLine("Number of products: " + readProducts.Count);

            //Assert
            Assert.True(productsWereRead);

        }
    }
}
