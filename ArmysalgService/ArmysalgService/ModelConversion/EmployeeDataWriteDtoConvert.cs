using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{   
    public class EmployeeDataWriteDtoConvert
    {
        public static Employee FromEmployee(EmployeeDataWriteDto inDto)
        {
            Employee aEmployee = null;
            if (inDto != null)
            {
                aEmployee = new Employee(inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email, inDto.EmployeeNo, inDto.Salary, inDto.Position);
            }
            return aEmployee;
        }
    }
}
