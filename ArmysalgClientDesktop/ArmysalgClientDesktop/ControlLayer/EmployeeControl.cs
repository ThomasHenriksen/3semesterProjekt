using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
    public class EmployeeControl
    {
        EmployeeServiceAccess _eAccess;

        public EmployeeControl()
        {
            _eAccess = new EmployeeServiceAccess();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee foundEmployee = await _eAccess.GetEmployee(id);
            return foundEmployee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> foundEmployees = await _eAccess.GetAllEmployees();
            return foundEmployees;
        }

        public async Task<int> SaveEmployee(string firstName, string lastName, string address, string zipCode,
            string city, string phone, string email, double salary, string position)
        {
            Employee newEmployee = new(firstName, lastName, address, zipCode,
            city, phone, email, salary, position);
            int insertedId = await _eAccess.SaveEmployee(newEmployee);
            return insertedId;
        }
    }
}
