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

        // Find and return employee by employee number.
        /// <summary>
        /// Find and return employee by employee number.
        /// </summary>
        /// <returns>
        /// employee object.
        /// </returns>
        /// <param name="id">Employee number.</param>
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

        // Find and return all employees.
        /// <summary>
        /// Find and return all employees.
        /// </summary>
        /// <returns>
        /// List of employee.
        /// </returns>
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
        //  Save a new employee object.
        /// <summary>
        /// Save a new employee object.
        /// </summary>
        /// <returns>
        /// Employee number of saved employee object.
        /// </returns>
        /// <param name="firstName">First name of employee</param>
        /// <param name="lastName">Last name of employee</param>
        /// <param name="address">Address of employee</param>
        /// <param name="zipCode">Zipcode of employee</param>
        /// <param name="city">City of employee</param>
        /// <param name="phone">Phone of employee</param>
        /// <param name="email">Email of employee</param>
        /// <param name="salary">Salary of employee</param>
        /// <param name="position">Position of employee</param>
        public async Task<int> SaveEmployee(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, double salary, string position)
        {
            Employee newEmployee = null;
            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                newEmployee = new Employee(firstName, lastName, address, zipCode, city,
                phone, email, salary, position);
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
                    newEmployee = new Employee(firstName, lastName, address, zipCode, city,
                phone, email, salary, position);
                }
            }       
            return await _eAccess.SaveEmployee(newEmployee, tokenValue);
        }

        //  Find and return Jwt token.
        /// <summary>
        /// Find and return Jwt token.
        /// </summary>
        /// <returns>
        /// A Jwt token objekt.
        /// </returns>
        /// <param name="useState">Jwt token objekt</param>
        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;
        }
    }
}
