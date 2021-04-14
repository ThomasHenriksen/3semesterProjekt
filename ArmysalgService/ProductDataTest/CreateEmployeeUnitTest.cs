//using Xunit;
//using Xunit.Abstractions;

//namespace ArmysalgDataTest
//{
//    public class TestCreateEmployee
//    {
//        private readonly ITestOutputHelper output;
//        readonly private IEmployeeAccess _employeeAccess;
//        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

//        public TestCreateEmployee(ITestOutputHelper output)
//        {
//            this.output = output;
//            _employeeAccess = new EmployeeDatabaseAccess(_connectionString);
//        }

//        [Fact]
//        public void CreateCustomerTest()
//        {
//            //Arrange
//            string firstName = "Larskovic";
//            string lastName = "35 lol";
//            string address = "Oldstreet 1986";
//            string zipCode = "9400";
//            string city = "Nørresundby";
//            string phone = "35353535";
//            string email = "livefastdiemiddleage@onlyfans.com";
//            int employeeNo = 1337;
//            double salary = 350000;
//            string position = "Swaggy";
//            //Act
//            Employee employeeToCreate = new(firstName, lastName, address, zipCode, city, phone, email, employeeNo, salary, position);
//            _employeeAccess.CreateEmployee(employeeToCreate);
//            Employee readEmployee = _employeeAccess.GetEmployeeByID(1337);
//            //Assert
//            Assert.Equal(employeeToCreate, readEmployee);
//        }
//    }
//}