using Xunit;
using Xunit.Abstractions;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

namespace ArmysalgDataTest
{
    public class CustomerTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private ICustomerDatabaseAccess _customerDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public CustomerTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _customerDatabaseAccess = new CustomerDatabaseAccess(_connectionString);
        }
        /*
         *  Test CreateCustomer method.
         */
        [Fact]
        public void CreateCustomerTest()
        {
            //Arrange
            string firstName = "Carsten";
            string lastName = "Dolberg";
            string address = "Vestrebro 45, 3. tv.";
            string zipCode = "8000";
            string city = "AarhusC";
            string phone = "+45 20856640";
            string email = "cardolberg@gmail.com";
            Cart cart = null;
            Customer customerToCreate = new Customer(firstName, lastName, address, zipCode, city, phone, email, cart);

            //Act
            int customerNoOfInsertedCustomer = _customerDatabaseAccess.CreateCustomer(customerToCreate);
            Customer customerToRead = _customerDatabaseAccess.GetCustomerByCustomerNo(customerNoOfInsertedCustomer);

            extraOutput.WriteLine("KUNDEINFO");
            extraOutput.WriteLine("Kunde nr: " + customerToRead.CustomerNo);
            extraOutput.WriteLine("Navn: " + customerToRead.FirstName + " " + customerToRead.LastName);
            extraOutput.WriteLine("Adresse: " + customerToRead.Address);
            extraOutput.WriteLine("By: " + customerToRead.ZipCode + " " + customerToRead.City);
            extraOutput.WriteLine("Telefon: " + customerToRead.Phone);
            extraOutput.WriteLine("Mail: " + customerToRead.Email);

            //Assert
            Assert.Equal(customerNoOfInsertedCustomer.ToString(), customerToRead.CustomerNo.ToString());
            Assert.Equal(customerToCreate.FirstName, customerToRead.FirstName);
            Assert.Equal(customerToCreate.LastName, customerToRead.LastName);
            Assert.Equal(customerToCreate.Address, customerToRead.Address);
            Assert.Equal(customerToCreate.ZipCode, customerToRead.ZipCode);
            Assert.Equal(customerToCreate.City, customerToRead.City);
            Assert.Equal(customerToCreate.Phone, customerToRead.Phone);
            Assert.Equal(customerToCreate.Email, customerToRead.Email);

            //CleanUp
            _customerDatabaseAccess.DeleteCustomerByCustomerNo(customerNoOfInsertedCustomer);
   
        }
    }
}