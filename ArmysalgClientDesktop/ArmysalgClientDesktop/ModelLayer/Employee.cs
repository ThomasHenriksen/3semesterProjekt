using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ModelLayer
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int EmployeeNo { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
       
        public Employee()
        {
        }

        public Employee(double salary, string position, string firstName, string lastName,
            string address, string zipCode, string city, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            Salary = salary;
            Position = position;
        }
        public Employee(int employeeNo, double salary, string position, string firstName, string lastName, 
            string address, string zipCode, string city, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            EmployeeNo = employeeNo;
            Salary = salary;
            Position = position;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}