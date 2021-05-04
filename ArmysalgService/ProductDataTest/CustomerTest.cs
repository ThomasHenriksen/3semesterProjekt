using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

namespace CustomerDataTest
{
    public class TestCustomerDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private ICustomerDatabaseAccess _customerAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestCustomerDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _customerAccess = new CustomerDatabaseAccess(_connectionString);
        }

        [Fact]
        public void TestCreateCustomer()
        {
            //Arrange
            string firstName = "Carsten";
            string lastName = "Dolberg";
            string address = "Vestrebro 45, 3. tv.";
            string zipCode = "8000";
            string city = "Aarhus";
            string phone = "20856640";
            string email = "cardolberg@gmail.com";
            Cart cart = null;

            //Act
            Customer customerToCreate = new Customer(firstName, lastName, address, zipCode, city, phone, email, cart);
            int customerNoOfInsertedCustomer = _customerAccess.CreateCustomer(customerToCreate);
            Customer customerToRead = _customerAccess.GetCustomerByCustomerNo(customerNoOfInsertedCustomer);

            extraOutput.WriteLine("KUNDEINFO");
            extraOutput.WriteLine("Kunde nr: " + customerToRead.CustomerNo);
            extraOutput.WriteLine("Navn: " + customerToRead.FirstName + " " + customerToRead.LastName);
            extraOutput.WriteLine("Adresse: " + customerToRead.Address);
            extraOutput.WriteLine("By: " + customerToRead.ZipCode + " " + customerToRead.City);
            extraOutput.WriteLine("Telefon: " + customerToRead.Phone);
            extraOutput.WriteLine("Mail: " + customerToRead.Email);

            //Assert
            Assert.True(customerToCreate.FirstName.Equals(customerToRead.FirstName));
            Assert.True(customerToCreate.LastName.Equals(customerToRead.LastName));
            Assert.True(customerToCreate.Address.Equals(customerToRead.Address));
            Assert.True(customerToCreate.ZipCode.Equals(customerToRead.ZipCode));
            Assert.True(customerToCreate.City.Equals(customerToRead.City));
            Assert.True(customerToCreate.Phone.Equals(customerToRead.Phone));
            Assert.True(customerToCreate.Email.Equals(customerToRead.Email));
        }
    }
}