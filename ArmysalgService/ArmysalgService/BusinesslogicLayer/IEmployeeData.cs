using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public interface IEmployeeData
    {
        Employee GetEmployee(int employeeNo);
        List<Employee> GetAllEmployees();
        int AddEmployee(Employee employeeToAdd);
    }
}
