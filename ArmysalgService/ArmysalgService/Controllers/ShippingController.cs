using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        // URL: api/shippings
        [HttpPost]
        public ActionResult<int> PostNewShipping(ShippingDataWriteDto inShipping)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inShipping != null)
            {
                Shipping dbShipping = ShippingDataWriteDtoConvert.ToShipping(inShipping);
                insertedId = _sControl.AddShipping(dbShipping);
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

        // URL: api/shipping/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<ShippingDataReadDto> Get(int shippingId)
        {
            ActionResult<ShippingDataReadDto> foundReturn;
            // retrieve and convert data
            Shipping foundShipping = _sControl.GetShippingByID(shippingId);

            ShippingDataReadDto foundDts = ShippingDataReadDtoConvert.FromShipping(foundShipping);
            // evaluate
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
            // send response back to client
            return foundReturn;
        }
    }
}