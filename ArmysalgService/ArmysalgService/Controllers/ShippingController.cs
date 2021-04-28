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
    [Route("api/shippings")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ShippingLogic _sControl;
        private readonly IConfiguration _configuration;

        public ShippingController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _sControl = new ShippingLogic(_configuration);
        }

        //URL: api/shippings
        [HttpGet]
        public ActionResult<List<ShippingDataReadDto>> Get()
        {
            return null;
        }

        // URL: api/shipping/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<ShippingDataReadDto> Get(int id)
        {
            ActionResult<ShippingDataReadDto> foundReturn;

            Shipping foundShipping = _sControl.GetShippingByID(id);

            ShippingDataReadDto foundDts = ShippingDataReadDtoConvert.FromShipping(foundShipping);

            if (foundDts != null)
            {
                if (foundDts != null)
                {
                    foundReturn = Ok(foundDts);             // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    //Ok, but not content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Server error
            }
            return foundReturn;
        }

        // URL: api/shippings
        [HttpPost]
        public ActionResult<int> PostNewShipping(ShippingDataWriteDto inShipping)
        {
            ActionResult<int> foundReturn;
            int insertedShippingID = -1;
            if (inShipping != null)
            {
                Shipping dbShipping = ModelConversion.ShippingDataWriteDtoConvert.ToShipping(inShipping);
                insertedShippingID = _sControl.AddShipping(dbShipping);
            }
            if (insertedShippingID > 0)
            {
                foundReturn = Ok(insertedShippingID);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

    }
}