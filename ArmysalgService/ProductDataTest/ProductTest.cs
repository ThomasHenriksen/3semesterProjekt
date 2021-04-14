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

        [Fact]
        public void TestGetProductById()
        {
            //Arrange
            int idForProduct1 = 1;

            //Act
            Product productToRead = _productAccess.GetProductById(idForProduct1);
            bool product1wasFound = (productToRead.Id == 1);
            extraOutput.WriteLine("Product name: " + productToRead.Name + " Product ID: " + productToRead.Id);

            //Assert
            Assert.True(product1wasFound);
        }

        [Fact]
        public void TestCreateProduct()
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
            //Act
            Product productToCreate = new Product(name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted);
            int productToReadByID = _productAccess.CreateProduct(productToCreate);
            Product productToRead = _productAccess.GetProductById(productToReadByID);

            bool product1wasFound = (productToRead.Id == 1);
            extraOutput.WriteLine("Product name: " + productToRead.Name + " Product ID: " + productToRead.Id);

            //Assert
            Assert.True(productToCreate.Name.Equals(productToRead.Name));
        }
        [Fact]
        public void TestUpdateProduct()
        {
            //Arrange
            int targetId = 8;
            string name = "bukser";
            string description = "blå";
            decimal purchasePrice = 3220;
            string status = "Indorder";
            int stock = 10;
            int minStock = 3;
            int maxStock = 10;
            //Act
            Product findProductToUpdate = _productAccess.GetProductById(targetId);
            findProductToUpdate.Name = name;
            findProductToUpdate.Description = description;
            findProductToUpdate.PurchasePrice = purchasePrice;
            findProductToUpdate.Status = status;
            findProductToUpdate.Stock = stock;
            findProductToUpdate.MinStock = minStock;
            findProductToUpdate.MaxStock = maxStock;
            bool productToUpdateByID = _productAccess.UpdateProduct(findProductToUpdate);
            //Assert
            Assert.True(productToUpdateByID);
        }
        [Fact]
        public void TestDeleteProduct()
        {
            //Arrange
            int targetId = 8;
            //Act
            bool productToUpdateByID = _productAccess.DeleteProductById(targetId);
            //Assert
            Assert.True(_productAccess.GetProductById(targetId).IsDeleted);
        }
    }
}
