using System;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

namespace ProductDataTest
{
    public class TestPriceDataAccess
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IProductDatabaseAccess _productAccess;
        readonly private IPriceDatabaseAccess _PriceAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestPriceDataAccess(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _PriceAccess = new PriceDatabaseAccess(_connectionString);
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }   
    }
}
