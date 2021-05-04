using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public interface IEmployeeDatabaseAccess
    {
        Employee GetEmployeeByEmployeeNo(int? employeeNo);
        List<Employee> GetAllEmployees();
        int CreateEmployee(Employee employeeToAdd);
        bool DeleteEmployeeByEmployeeNo(int employeeNo);
    }
}