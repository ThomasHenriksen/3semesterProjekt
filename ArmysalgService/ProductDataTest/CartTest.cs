using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class CartTest
    {
        private readonly ITestOutputHelper extraOutput;
        private readonly ICartDatabaseAccess _cartDatabaseAccess;
        private readonly ICustomerDatabaseAccess _customerDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public CartTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _cartDatabaseAccess = new CartDatabaseAccess(_connectionString);
            _customerDatabaseAccess = new CustomerDatabaseAccess(_connectionString);
        }

        /*
         * Tests CreateCart method.
         */
        [Fact]
        public void CreateCartTest()
        {
            //Arrange
            DateTime lastupdated = DateTime.Now;
            Cart cartToCreate = new Cart(lastupdated);

            string firstName = "Carsten";
            string lastName = "Dolberg";
            string address = "Vestrebro 45, 3. tv.";
            string zipCode = "8000";
            string city = "AarhusC";
            string phone = "20856640";
            string email = "cardolberg@gmail.com";
            Cart cart = null;
            Customer customerToCreate = new Customer(firstName, lastName, address, zipCode, city, phone, email, cart);

            //Act
            int idOfInsertedCustomer = _customerDatabaseAccess.AddCustomer(customerToCreate);
            Customer customerToRead = _customerDatabaseAccess.GetCustomerByCustomerNo(idOfInsertedCustomer);

            int idOfInsertedCart = _cartDatabaseAccess.AddCart(cartToCreate, customerToRead);
            Cart cartToRead = _cartDatabaseAccess.GetCartById(idOfInsertedCart);

            extraOutput.WriteLine("KURVINFO");
            extraOutput.WriteLine("Kurv ID: " + cartToRead.Id);
            extraOutput.WriteLine("Sidst opdateret: " + cartToRead.LastUpdated);

            //Assert
            Assert.Equal(idOfInsertedCart.ToString(), cartToRead.Id.ToString());
            Assert.Equal(cartToCreate.LastUpdated.ToString(), cartToRead.LastUpdated.ToString());

            //CleanUp
            _cartDatabaseAccess.DeleteCartByCartId(idOfInsertedCart);
            _customerDatabaseAccess.DeleteCustomerByCustomerNo(idOfInsertedCustomer);

        }
    }
}
