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

        [Fact]
        public void CreateSupplierTest()
        {
            //Arrange
            string name = "TilAftaltTid";
            string address = "Topperedsvägen 7";
            string zipCode = "311 63";
            string city = "Älvsered";
            string country = "Sverige";
            string phone = "900400600";
            string email = "vileverer@tiden.se";

            //Act
            Supplier supplierToCreate = new Supplier(name, address, zipCode, city, country, phone, email);
            int supplierIdOfInsertedSupplier = _supplierAccess.CreateSupplier(supplierToCreate);
            Supplier supplierToRead = _supplierAccess.GetSupplierById(supplierIdOfInsertedSupplier);

            extraOutput.WriteLine("Supplier ID: " + supplierToRead.Id);

            //Assert
            Assert.Equal(supplierIdOfInsertedSupplier.ToString(), supplierToRead.Id.ToString());

            //CleanUp
            _supplierAccess.DeleteSupplierById(supplierIdOfInsertedSupplier);
        }
    }
}
