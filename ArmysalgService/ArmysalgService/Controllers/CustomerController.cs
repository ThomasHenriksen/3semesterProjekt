using ArmysalgService.BusinesslogicLayer;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgService.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerdata _customerControl;
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _customerControl = new CustomerdataControl(_configuration);
        }

        // URL: api/products/{customerNo}
        [HttpGet, Route("{customerNo}")]
        public ActionResult<CustomerdataReadDto> Get(int customerNo)
        {
            ActionResult<CustomerdataReadDto> foundReturn;
            // retrieve and convert data
            Customer foundCustomer = _customerControl.GetCustomer(customerNo);

            CustomerdataReadDto foundDts = ModelConversion.CustomerdataReadDtoConvert.FromCustomer(foundCustomer);
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

        // URL: api/Product
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
    }
}
