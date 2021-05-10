using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class SupplierTest
    {
        private readonly ITestOutputHelper extraOutput;
        private readonly ISupplierDatabaseAccess _supplierDatabaseAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public SupplierTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _supplierDatabaseAccess = new SupplierDatabaseAccess(_connectionString);
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
            string phone = "+46 900400600";
            string email = "cust@fabriker.se";
            Supplier supplierToCreate = new Supplier(name, address, zipCode, city, country, phone, email);
            
            //Act
            int idOfInsertedSupplier = _supplierDatabaseAccess.CreateSupplier(supplierToCreate);
            Supplier supplierToRead = _supplierDatabaseAccess.GetSupplierById(idOfInsertedSupplier);

            extraOutput.WriteLine("LEVERANDØRINFO");
            extraOutput.WriteLine("Leverandør ID: " + supplierToRead.Id);
            extraOutput.WriteLine("Navn: " + supplierToRead.Name);
            extraOutput.WriteLine("Adresse: " + supplierToRead.Address);
            extraOutput.WriteLine("By: " + supplierToRead.ZipCode + " " + supplierToRead.City);
            extraOutput.WriteLine("Telefon: " + supplierToRead.Phone);
            extraOutput.WriteLine("Mail: " + supplierToRead.Email);

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
            _supplierDatabaseAccess.DeleteSupplierById(idOfInsertedSupplier);
        }
    }
}