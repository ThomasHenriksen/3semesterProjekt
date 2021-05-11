using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class ShippingTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IShippingDatabaseAccess _shippingDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public ShippingTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _shippingDatabaseAccess = new ShippingDatabaseAccess(_connectionString);
        }

        /*
         * Tests CreateShipping method.
         */
        [Fact]
        public void CreateShippingTest()
        {
            //Arrange
            double price = 150;
            string firstName = "Ryan";
            string lastName = "Engelbrecht";
            string address = "Brosundet 69";
            string zipCode = "9400";
            string city = "Nørresundby";
            string phone = "35353535";
            string email = "Ryan@Engelbrecht.com";
            Shipping shippingToCreate = new(price, firstName, lastName, address, zipCode, city, phone, email);

            //Act
            int idOfInsertedShipping = _shippingDatabaseAccess.AddShipping(shippingToCreate);
            Shipping shippingToRead = _shippingDatabaseAccess.GetShippingByShippingID(idOfInsertedShipping);

            extraOutput.WriteLine("LEVERINGSINFO");
            extraOutput.WriteLine("Leverandør ID: " + shippingToRead.Id);
            extraOutput.WriteLine("Pris for levering: " + shippingToRead.Price);
            extraOutput.WriteLine("Navn: " + shippingToRead.FirstName + " " + shippingToRead.LastName);
            extraOutput.WriteLine("Adresse: " + shippingToRead.Address);
            extraOutput.WriteLine("By: " + shippingToRead.ZipCode + " " + shippingToRead.City);
            extraOutput.WriteLine("Telefon: " + shippingToRead.Phone);
            extraOutput.WriteLine("Mail: " + shippingToRead.Email);

            //Assert
            Assert.Equal(idOfInsertedShipping.ToString(), shippingToRead.Id.ToString());
            Assert.Equal(shippingToCreate.Price, shippingToRead.Price);
            Assert.Equal(shippingToCreate.FirstName, shippingToRead.FirstName);
            Assert.Equal(shippingToCreate.LastName, shippingToRead.LastName);
            Assert.Equal(shippingToCreate.Address, shippingToRead.Address);
            Assert.Equal(shippingToCreate.ZipCode, shippingToRead.ZipCode);
            Assert.Equal(shippingToCreate.City, shippingToRead.City);
            Assert.Equal(shippingToCreate.Phone, shippingToRead.Phone);
            Assert.Equal(shippingToCreate.Email, shippingToRead.Email);

            //CleanUp
            _shippingDatabaseAccess.DeleteShippingById(idOfInsertedShipping);
        }
    }
}