using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface IEmployeeDatabaseAccess
    {
        Employee GetEmployeeByEmployeeNo(int employeeNo);
        List<Employee> GetAllEmployees();
        int CreateEmployee(Employee employeeToAdd);
        bool DeleteEmployeeByEmployeeNo(int employeeNo);
    }
}