using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.Controllers
{

    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartLogic _cControl;
        private readonly IConfiguration _configuration;

        public CartController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _cControl = new CartLogic(_configuration);
        }

        // URL: api/persons/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<CartdataReadDto> Get(int id)
        {
            ActionResult<CartdataReadDto> foundReturn;
            // retrieve and convert data
            Cart foundCart = _cControl.GetCart(id);
            CartdataReadDto foundDto = ModelConversion.CartdataReadDtoConvert.FromCart(foundCart);


            if (foundDto != null)
            {
                if (foundDto != null)
                {
                    foundReturn = Ok(foundDto); //Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204); //Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500); //server error
            }
            // send response back to client
            return foundReturn;
        }

        // URL api/carts
        [HttpPost]
        public ActionResult<int> PostNewCart(CartdataWriteDto inCart)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCart != null)
            {
                Cart dbCart = ModelConversion.CartdataWriteDtoConvert.ToCart(inCart);
                insertedId = _cControl.AddCart(dbCart);
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

        // URL: api/Product/{id}
        [HttpDelete, Route("{id}")]
        public ActionResult<bool> DeleteCart(int id)
        {
            ActionResult<bool> foundReturn;
            bool isDeleted = false;
            Cart findCart = _cControl.GetCart(id);
            
            if (findCart != null)
            {
                isDeleted = _cControl.DeleteCart(findCart.Id);
            }
            if (isDeleted == true)
            {
                foundReturn = Ok(isDeleted);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }
    }
}
