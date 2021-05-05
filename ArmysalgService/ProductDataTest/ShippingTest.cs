using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class ShippingTest
    {
        private readonly ITestOutputHelper output;
        readonly private IShippingDatabaseAccess _shippingAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";
            
    public ShippingTest(ITestOutputHelper output)
        {
            this.output = output;
            _shippingAccess = new ShippingDatabaseAccess(_connectionString);
        }

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
            string email = "livefastdiemiddleage@onlyfans.com";
            //Act
            Shipping shippingToCreate = new(price, firstName, lastName, address, zipCode, city, phone, email);
            int shippingID = _shippingAccess.CreateShipping(shippingToCreate);
            Shipping shippingToCompare = _shippingAccess.GetShippingByShippingID(shippingID);
            //Assert
            Assert.Equal(shippingToCreate.LastName, shippingToCompare.LastName);
        }       
    }
}