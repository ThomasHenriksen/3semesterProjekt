using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeLogic _employeeControl;
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _employeeControl = new EmployeeLogic(_configuration);
        }

        // URL: api/products/{employeeNo}
        [HttpGet, Route("{employeeNo}")]
        public ActionResult<EmployeeDataReadDto> Get(int employeeNo)
        {
            ActionResult<EmployeeDataReadDto> foundReturn;
            // retrieve and convert data
            Employee foundEmployee = _employeeControl.GetEmployee(employeeNo);

            EmployeeDataReadDto foundDts = ModelConversion.EmployeeDataReadDtoConvert.FromEmployee(foundEmployee);
            // evaluate
            if (foundDts != null)
            {
                if (foundDts != null)
                {
                    foundReturn = Ok(foundDts);         //Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    //Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        //Server error
            }
            // send response back to client
            return foundReturn;
        }
        public ActionResult<List<EmployeeDataReadDto>> GetAll()
        {
            ActionResult<List<EmployeeDataReadDto>> foundReturn;
            // retrieve and convert data
            List<Employee> foundEmployees = _employeeControl.GetAllEmployees();
            List<EmployeeDataReadDto> foundDts = ModelConversion.EmployeeDataReadDtoConvert.FromEmployeeCollection(foundEmployees);
            // evaluate
            if (foundDts != null)
            {
                if (foundDts != null)
                {
                    foundReturn = Ok(foundDts);         //Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    //Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        //Server error
            }
            // send response back to client
            return foundReturn;
        }


        // URL: api/employees
        [HttpPost]
        public ActionResult<int> PostNewEmployee(EmployeeDataWriteDto inEmployee)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inEmployee != null)
            {
                Employee dbEmployee = EmployeeDataWriteDtoConvert.ToEmployee(inEmployee);
                insertedId = _employeeControl.AddEmployee(dbEmployee);
            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }
    }
}