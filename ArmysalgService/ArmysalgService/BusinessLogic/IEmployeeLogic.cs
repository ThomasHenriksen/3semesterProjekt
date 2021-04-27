using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public interface IEmployeeLogic
    {
        Employee GetEmployee(int employeeNo);
        List<Employee> GetAllEmployees();
        int AddEmployee(Employee employeeToAdd);
    }
}
