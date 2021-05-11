using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface IEmployeeLogic
    {
        // Add employee to the database.
        /// <summary>
        /// Add employee to the database.
        /// </summary>
        /// <returns>
        /// employee number of inserted employee object.
        /// </returns>
        /// <param name="aEmployee">Employee object.</param>
        int AddEmployee(Employee employeeToAdd);

        // Find and return employee from database by employee number.
        /// <summary>
        /// Find and return employee from database by employee number.
        /// </summary>
        /// <returns>
        /// employee object.
        /// </returns>
        /// <param name="employeeNo">Employee number.</param>
        Employee GetEmployee(int employeeNo);

        // Find and return employees from database.
        /// <summary>
        /// Find and return employees from database.
        /// </summary>
        /// <returns>
        /// List of employee.
        /// </returns>
        List<Employee> GetAllEmployees();
    }
}
