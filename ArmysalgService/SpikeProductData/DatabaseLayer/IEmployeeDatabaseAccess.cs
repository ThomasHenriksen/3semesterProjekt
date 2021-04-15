using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public interface IEmployeeDatabaseAccess
    {
        Employee GetEmployeeByCustomerNo(int employeeNo);
        int CreateEmployee(Employee employeeToAdd);
        bool DeleteEmployeeByCustomerNo(int employeeNo);
    }
}