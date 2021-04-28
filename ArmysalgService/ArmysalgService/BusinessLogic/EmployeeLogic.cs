﻿using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IEmployeeDatabaseAccess _employeeAccess;

        public EmployeeLogic(IConfiguration inConfiguration)
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
           *  Find all employees in the db
           *  
           *  @return List<Employee>
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