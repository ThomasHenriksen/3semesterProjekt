using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class CategoryTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private ICategoryDatabaseAccess _categoryDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public CategoryTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _categoryDatabaseAccess = new CategoryDatabaseAccess(_connectionString);
        }

        /*
         *  Test CreateCustomer method.
         */
        [Fact]
        public void CreateCategoryTest()
        {
            //Arrange
            string name = "Vandre sko";
            string description = "Sko til en god tur";
            List<Product> products = new List<Product>();
            Category categoryToCreate = new Category(name, description, products);

            //Act 
            int idOfInsertedCategory = _categoryDatabaseAccess.CreateCategory(categoryToCreate);
            Category categoryToRead = _categoryDatabaseAccess.GetCategoryById(idOfInsertedCategory);

            extraOutput.WriteLine("KATEGORIINFO");
            extraOutput.WriteLine("Kategori nr: " + categoryToRead.Id);
            extraOutput.WriteLine("Navn: " + categoryToRead.Name);
            extraOutput.WriteLine("Beskrive: " + categoryToRead.Description);
            extraOutput.WriteLine("Antal: " + categoryToRead.ProductCategory.Count());

            //Assert
            Assert.Equal(idOfInsertedCategory.ToString(), categoryToRead.Id.ToString());
            Assert.Equal(categoryToCreate.Name, categoryToRead.Name);
            Assert.Equal(categoryToCreate.Description, categoryToRead.Description);

            //CleanUp
            _categoryDatabaseAccess.DeleteCategoryByCategoryId(idOfInsertedCategory);
        }
    }
}
