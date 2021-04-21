using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class TestCreateEmployee
    {
        private readonly ITestOutputHelper output;
        readonly private IEmployeeDatabaseAccess _employeeAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestCreateEmployee(ITestOutputHelper output)
        {
            this.output = output;
            _employeeAccess = new EmployeeDatabaseAccess(_connectionString);
        }

        [Fact]
        public void CreateEmployeeTest()
        {
            //Arrange
            string firstName = "Per";
            string lastName = "Ølstrøm";
            string address = "Østergade 45";
            string zipCode = "9400";
            string city = "Nørresundby";
            string phone = "35353535";
            string email = "livefastdiemiddleage@onlyfans.com";
            double salary = 350000;
            string position = "RX designer";
            //Act
            Employee employeeToCreate = new(firstName, lastName, address, zipCode, city, phone, email, salary, position);
            employeeToCreate.EmployeeNo = _employeeAccess.CreateEmployee(employeeToCreate);
            Employee readEmployee = _employeeAccess.GetEmployeeByEmployeeNo(employeeToCreate.EmployeeNo);
            //Assert
            Assert.Equal(employeeToCreate.FirstName, readEmployee.FirstName);
        }
    }
}