using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.Security;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Employee foundEmployee = null; // await _eAccess.GetEmployee(id);

            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                foundEmployee = await _eAccess.GetEmployee(tokenValue, id);
                if (_eAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    foundEmployee = await _eAccess.GetEmployee(tokenValue, id);
                }
            }
            return foundEmployee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> foundEmployees = null; // await _eAccess.GetAllEmployees();

            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                foundEmployees = await _eAccess.GetAllEmployees(tokenValue);
                if (_eAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    foundEmployees = await _eAccess.GetAllEmployees(tokenValue);
                }
            }
            return foundEmployees;
        }

        public async Task<int> SaveEmployee(string firstName, string lastName, string address, string zipCode,
            string city, string phone, string email, double salary, string position)
        {
            Employee newEmployee = null;
            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                newEmployee = new Employee(salary, position, firstName, lastName,
                address, zipCode, city, phone, email);
                if (_eAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if(tokenValue != null)
                {
                    newEmployee = new Employee(salary, position, firstName, lastName,
                address, zipCode, city, phone, email);
                }
            }            

            return await _eAccess.SaveEmployee(newEmployee, tokenValue);
        }

        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;

        }
    }
}
