using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class EmployeeDataReadDtoConvert
    {
        public static EmployeeDataReadDto FromEmployee(Employee inEmployee)
        {
            EmployeeDataReadDto aEmployeeReadDto = null;
            if (inEmployee != null)
            {
                aEmployeeReadDto = new EmployeeDataReadDto(inEmployee.FirstName, inEmployee.LastName, inEmployee.Address, inEmployee.ZipCode, inEmployee.City, inEmployee.Phone, inEmployee.Email, inEmployee.EmployeeNo, inEmployee.Salary, inEmployee.Position);
            }
            return aEmployeeReadDto;
        }
    }
}