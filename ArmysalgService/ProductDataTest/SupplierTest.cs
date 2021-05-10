using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class SupplierTest
    {
        private readonly ITestOutputHelper extraOutput;
        private readonly ISupplierDatabaseAccess _supplierAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public SupplierTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _supplierAccess = new SupplierDatabaseAccess(_connectionString);
        }

        /*
         * Tests CreateSupplier method.
         */
        [Fact]
        public void CreateSupplierTest()
        {
            //Arrange
            string name = "Militärfabriker";
            string address = "Topperedsvägen 7";
            string zipCode = "311 63";
            string city = "Älvsered";
            string country = "Sverige";
            string phone = "900400600";
            string email = "cust@fabriker.se";
            Supplier supplierToCreate = new Supplier(name, address, zipCode, city, country, phone, email);
            
            //Act
            int idOfInsertedSupplier = _supplierAccess.CreateSupplier(supplierToCreate);
            Supplier supplierToRead = _supplierAccess.GetSupplierById(idOfInsertedSupplier);

            extraOutput.WriteLine("Supplier ID: " + supplierToRead.Id);

            //Assert
            Assert.Equal(idOfInsertedSupplier.ToString(), supplierToRead.Id.ToString());
            Assert.Equal(supplierToCreate.Name, supplierToRead.Name);
            Assert.Equal(supplierToCreate.Address, supplierToRead.Address);
            Assert.Equal(supplierToCreate.ZipCode, supplierToRead.ZipCode);
            Assert.Equal(supplierToCreate.City, supplierToRead.City);
            Assert.Equal(supplierToCreate.Country, supplierToRead.Country);
            Assert.Equal(supplierToCreate.Phone, supplierToRead.Phone);
            Assert.Equal(supplierToCreate.Email, supplierToRead.Email);

            //CleanUp
            _supplierAccess.DeleteSupplierById(idOfInsertedSupplier);
        }
    }
}
