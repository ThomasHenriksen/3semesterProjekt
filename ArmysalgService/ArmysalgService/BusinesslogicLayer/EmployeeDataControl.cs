using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class EmployeeDataControl : IEmployeeData
    {
        IEmployeeDatabaseAccess _employeeAccess;

        public EmployeeDataControl(IConfiguration inConfiguration)
        {
            _employeeAccess = new EmployeeDatabaseAccess(inConfiguration);
        }

        /*
           *  Create a new employee in the database
           *  @param newEmployee
           *  
           *  @return insertedEmployeeNo
         */
        public int AddEmployee(Employee newEmployee)
        {
            int insertedEmployeeNo;
            try
            {
                insertedEmployeeNo = _employeeAccess.CreateEmployee(newEmployee);
            }
            catch
            {
                insertedEmployeeNo = -1;
            }
            return insertedEmployeeNo;
        }

        /*
           *  Find a employee in the database by employeeNo
           *  @param employeeNoToMatch
           *  
           *  @return Employee
         */
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
    }
}
