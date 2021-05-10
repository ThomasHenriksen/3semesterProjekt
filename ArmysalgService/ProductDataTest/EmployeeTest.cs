using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Xunit;
using Xunit.Abstractions;

namespace ArmysalgDataTest
{
    public class TestCreateEmployee
    {
        private readonly ITestOutputHelper extraOutput;
        private readonly IEmployeeDatabaseAccess _employeeAccess;
        readonly string _connectionString = "Server = hildur.ucn.dk; Database = dmaa0220_1085014; User Id = dmaa0220_1085014; Password = Password1!; Trusted_Connection = False";

        public TestCreateEmployee(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _employeeAccess = new EmployeeDatabaseAccess(_connectionString);
        }

        /*
         * Tests CreateEmployee method.
         */
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
            string email = "perfekt@gmail.com";
            double salary = 350000;
            string position = "RX designer";
            Employee employeeToCreate = new(firstName, lastName, address, zipCode, city, phone, email, salary, position);

            //Act
            int idOfInsertedEmployee = _employeeAccess.CreateEmployee(employeeToCreate);
            Employee readEmployee = _employeeAccess.GetEmployeeByEmployeeNo(idOfInsertedEmployee);

            extraOutput.WriteLine("EMPLOYEE INFO");
            extraOutput.WriteLine("Employee ID: " + readEmployee.EmployeeNo);
            extraOutput.WriteLine("Navn: " + readEmployee.FirstName + " " + readEmployee.LastName);
            extraOutput.WriteLine("Adresse: " + readEmployee.Address);
            extraOutput.WriteLine("By: " + readEmployee.ZipCode + " " + readEmployee.City);
            extraOutput.WriteLine("Telefon: " + readEmployee.Phone);
            extraOutput.WriteLine("Mail: " + readEmployee.Email);
            extraOutput.WriteLine("Mail: " + readEmployee.Salary);
            extraOutput.WriteLine("Mail: " + readEmployee.Position);

            //Assert
            Assert.Equal(employeeToCreate.FirstName, readEmployee.FirstName);
            Assert.Equal(employeeToCreate.LastName, readEmployee.LastName);
            Assert.Equal(employeeToCreate.Address, readEmployee.Address);
            Assert.Equal(employeeToCreate.ZipCode, readEmployee.ZipCode);
            Assert.Equal(employeeToCreate.City, readEmployee.City);
            Assert.Equal(employeeToCreate.Phone, readEmployee.Phone);
            Assert.Equal(employeeToCreate.Email, readEmployee.Email);
            Assert.Equal(employeeToCreate.Salary, readEmployee.Salary);
            Assert.Equal(employeeToCreate.Position, readEmployee.Position);

            //CleanUp
            _employeeAccess.DeleteEmployeeByEmployeeNo(idOfInsertedEmployee);
        }
    }
}