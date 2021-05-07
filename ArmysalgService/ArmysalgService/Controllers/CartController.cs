using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ArmysalgDataAccess.Model;
using Microsoft.AspNetCore.Authorization;

namespace ArmysalgService.Controllers
{
    [Route("api/Cart")]
    [ApiController]
   // [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartLogic _cartControl;
        private readonly IConfiguration _configuration;
        private readonly ICustomerLogic _customerController;
        public CartController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _cartControl = new CartLogic(_configuration);
            _customerController = new CustomerLogic(_configuration);
        }


        /* Data retrieved from the database, is converted to eksternal 
         * format, evaluated and the an response must be sent back*/
        // URL: api/products
        [HttpGet, Route("{CustomerNo}")]
        public ActionResult<CartdataReadDto> Get(int CustomerNo)
        {
            ActionResult<CartdataReadDto> foundReturn;
            // retrieve and convert data
            Cart foundCart = _cartControl.Get(_customerController.GetCustomer(CustomerNo));
            CartdataReadDto foundDts = ModelConversion.CartdataReadDtoConvert.FromCart(foundCart);
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
        [HttpPost, Route("{CustomerNo}")]
        public ActionResult<int> PostCart(CartdataWriteDto inCart, int CustomerNo)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCart != null)
            {
                Cart dbCart = CartdataWriteDtoConvert.ToCart(inCart);
                insertedId = _cartControl.AddCart(dbCart, _customerController.GetCustomer(CustomerNo));
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
        // URL: api/Product/2
        [HttpPut, Route("{id}")]
        public ActionResult<int> PutUpdateProduct(int id, CartdataWriteDto inCart)
        {

            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCart != null)
            {
                Cart dbCart = CartdataWriteDtoConvert.ToCart(inCart);
                dbCart.Id = id;
                _cartControl.UpdateCart(dbCart);
                insertedId = dbCart.Id;
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

        // URL: api/Product/2
        [HttpDelete, Route("{id}")]
        public ActionResult<bool> DeleteCart(int id)
        {
            ActionResult<bool> foundReturn;
            bool insertedId = false;
            Cart findCart = _cartControl.Get(_customerController.GetCustomer(id));
            if (findCart != null)
            {
                insertedId = _cartControl.DeleteCart(findCart.Id);
            }
            if (insertedId == true)
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
