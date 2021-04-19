using ArmysalgClientDesktop.ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ServiceLayer
{
    public class EmployeeServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/employees";
        readonly HttpClient _httpClient;

        public EmployeeServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        /* Method to retrieve an Employee
         */
        public async Task<Employee> GetEmployee(int id)
        {
            Employee employeeFromService = null;

            // api/persons/{id}
            string useRestUrl = restUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                useRestUrl += id;
            }
            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (hasValidId)
                    {
                        Employee foundEmployee = JsonConvert.DeserializeObject<Employee>(content);
                    }
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        employeeFromService = null;
                    }
                }
            }
            catch
            {
                employeeFromService = null;
            }
            return employeeFromService;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employeesFromService = null;

            // api/persons/{id}
            string useRestUrl = restUrl;

            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Employee foundEmployee = JsonConvert.DeserializeObject<Employee>(content);
                    if(foundEmployee != null)
                    {
                        employeesFromService = new List<Employee> { foundEmployee };
                    }
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        employeesFromService = null;
                    }
                }
            }
            catch
            {
                employeesFromService = null;
            }
            return employeesFromService;
        }

        public async Task<int> SaveEmployee(Employee employeeToSave)
        {
            int insertedEmployeeId;

            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(employeeToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedEmployeeId);
                }
                else
                {
                    insertedEmployeeId = -2;
                }
            }
            catch
            {
                insertedEmployeeId = -3;
            }
            return insertedEmployeeId;
        }
    }
}
