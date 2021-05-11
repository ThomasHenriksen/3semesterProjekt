using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic _customerControl;
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _customerControl = new CustomerLogic(_configuration);
        }

        // URL: api/customer
        [HttpPost]
        public ActionResult<int> PostNewCustomer(CustomerdataWriteDto inCustomer)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCustomer != null)
            {
                Customer dbCustomer = CustomerdataWriteDtoConvert.ToCustomer(inCustomer);
                insertedId = _customerControl.AddCustomer(dbCustomer);
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

        [HttpGet, Route("{customerEmail}")]
        public ActionResult<CustomerdataReadDto> Get(string customerEmail)
        {
            ActionResult<CustomerdataReadDto> foundReturn;
            // retrieve and convert data
            Customer foundCustomer = _customerControl.GetCustomer(customerEmail);

            CustomerdataReadDto foundDts = CustomerdataReadDtoConvert.FromCustomer(foundCustomer);
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
    }
}