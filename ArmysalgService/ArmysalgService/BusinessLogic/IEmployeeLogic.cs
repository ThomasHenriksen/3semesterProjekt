using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface IEmployeeLogic
    {
        Employee GetEmployee(int employeeNo);
        List<Employee> GetAllEmployees();
        int AddEmployee(Employee employeeToAdd);
    }
}
