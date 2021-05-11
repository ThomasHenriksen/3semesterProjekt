using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IEmployeeDatabaseAccess _employeeAccess;

        public EmployeeLogic(IConfiguration inConfiguration)
        {
            _employeeAccess = new EmployeeDatabaseAccess(inConfiguration);
        }

        // Add a new employee in the database.
        /// <inheritdoc/>
        public int AddEmployee(Employee newEmployee)
        {
            int insertedEmployeeNo;
            try
            {
                insertedEmployeeNo = _employeeAccess.AddEmployee(newEmployee);
            }
            catch
            {
                insertedEmployeeNo = -1;
            }
            return insertedEmployeeNo;
        }

        // Find and return employee from database by employee number.
        /// <inheritdoc/>
        public Employee GetEmployee(int employeeNoToMatch)
        {
            Employee foundEmployee;
            try
            {
                foundEmployee = _employeeAccess.GetEmployeeByEmployeeNo(employeeNoToMatch);
            }
            catch
            {
                foundEmployee = null;
            }
            return foundEmployee;
        }

        // Find and return employees from database.
        /// <inheritdoc/>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> foundEmployees;
            try
            {
                foundEmployees = _employeeAccess.GetAllEmployees();
            }
            catch
            {
                foundEmployees = null;
            }
            return foundEmployees;
        }
    }
}