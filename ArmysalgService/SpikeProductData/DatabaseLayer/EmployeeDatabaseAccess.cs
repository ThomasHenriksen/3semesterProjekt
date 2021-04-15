using ArmysalgDataAccess.ModelLayer;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public class EmployeeDatabaseAccess : IEmployeeDatabaseAccess
    {
        readonly string _connectionString;

        public EmployeeDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        //For Test 
        public EmployeeDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateEmployee(Employee aEmployee)
        {
            int insertedId = -1;

            string insertString = "insert into employee (firstName, lastName, address, zipCode_fk, phone, email, salary, position) OUTPUT INSERTED.employeeNo " +
                "values (@FirstName, @LastName, @Address, @ZipCode, @Phone, @Email, @Salary, @Position)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter firstNameParam = new SqlParameter("@FirstName", aEmployee.FirstName);
                CreateCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", aEmployee.FirstName);
                CreateCommand.Parameters.Add(lastNameParam);
                SqlParameter address = new SqlParameter("@Address", aEmployee.Address);
                CreateCommand.Parameters.Add(address);
                SqlParameter zipCode = new SqlParameter("@ZipCode", aEmployee.ZipCode);
                CreateCommand.Parameters.Add(zipCode);
                SqlParameter phone = new SqlParameter("@Phone", aEmployee.Phone);
                CreateCommand.Parameters.Add(phone);
                SqlParameter email = new SqlParameter("@Email", aEmployee.Email);
                CreateCommand.Parameters.Add(email);
                SqlParameter salary = new SqlParameter("@Salary", aEmployee.Salary);
                CreateCommand.Parameters.Add(salary);
                SqlParameter position = new SqlParameter("@Position", aEmployee.Position);
                CreateCommand.Parameters.Add(position);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }


        /* Three possible returns:
        * A Customer object
        * An empty Customer object (no match on customerNo)
        * Null - Some error occurred
        */
        public Employee GetEmployeeByEmployeeNo(int findEmployeeNo)
        {
            Employee foundEmployee = null;
            string queryString = "select employeeNo, firstName, lastName, address, zipCode, city, phone, email, salary, position from Employee" + " join zipCity zc on employee.zipCode_fk = zc.zipCode" + " where employeeNo = @EmployeeNo";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@EmployeeNo", findEmployeeNo);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader employeeReader = readCommand.ExecuteReader();
                foundEmployee = new Employee();
                while (employeeReader.Read())
                {
                    foundEmployee = GetEmployeeFromReader(employeeReader);
                }
            }
            return foundEmployee;
        }

        private Employee GetEmployeeFromReader(SqlDataReader employeeReader)
        {
            Employee foundEmployee;
            int tempEmployeeNo;
            string tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail, tempPosition;
            double tempSalary;

            tempEmployeeNo = employeeReader.GetInt32(employeeReader.GetOrdinal("employeeNo"));
            tempFirstName = employeeReader.GetString(employeeReader.GetOrdinal("firstName"));
            tempLastName = employeeReader.GetString(employeeReader.GetOrdinal("lastName"));
            tempAddress = employeeReader.GetString(employeeReader.GetOrdinal("address"));
            tempZipCode = employeeReader.GetString(employeeReader.GetOrdinal("zipCode"));
            tempCity = employeeReader.GetString(employeeReader.GetOrdinal("city"));
            tempPhone = employeeReader.GetString(employeeReader.GetOrdinal("phone"));
            tempEmail = employeeReader.GetString(employeeReader.GetOrdinal("email"));
            tempSalary = decimal.ToDouble(employeeReader.GetDecimal(employeeReader.GetOrdinal("salary")));
            tempPosition = employeeReader.GetString(employeeReader.GetOrdinal("position"));

            foundEmployee = new Employee(tempFirstName, tempLastName, tempAddress, tempZipCode, tempCity, tempPhone, tempEmail, tempEmployeeNo, tempSalary, tempPosition);

            return foundEmployee;
        }

        public bool DeleteEmployeeByEmployeeNo(int id)
        {
            int numRowsUpdated = 0;
            string queryString = "UPDATE Product SET  isDeleted = @inIsDelete from Product where productNo = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString,
                 new
                 {
                     inIsDelete = 1,
                     Id = id
                 });
            }
            return (numRowsUpdated == 1);
        }
    }
}