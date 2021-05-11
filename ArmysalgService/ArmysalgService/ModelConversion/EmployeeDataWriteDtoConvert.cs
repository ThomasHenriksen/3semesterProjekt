using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class EmployeeDataWriteDtoConvert
    {
        public static Employee ToEmployee(EmployeeDataWriteDto inDto)
        {
            Employee aEmployee = null;
            if (inDto != null)
            {
                aEmployee = new Employee(inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email, inDto.Salary, inDto.Position);
            }
            return aEmployee;
        }
    }
}