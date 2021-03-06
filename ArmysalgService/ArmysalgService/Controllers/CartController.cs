using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        // URL: api/Cart/1
        [HttpGet, Route("{CustomerNo}")]
        public ActionResult<CartdataReadDto> GetCustomer(int customerNo)
        {
            ActionResult<CartdataReadDto> foundReturn;
            // retrieve and convert data
            Cart foundCart = _cartControl.GetCart(_customerController.GetCustomerByCustomerNo(customerNo));
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

        // URL: api/Cart/5
        [HttpPost, Route("{CustomerNo}")]
        public ActionResult<int> PostCart(CartdataWriteDto inCart, int customerNo)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCart != null)
            {
                Cart dbCart = CartdataWriteDtoConvert.ToCart(inCart);
                insertedId = _cartControl.AddCart(dbCart, _customerController.GetCustomerByCustomerNo(customerNo));
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

        // URL: api/Cart
        [HttpPut]
        public ActionResult<int> UpdateCart(CartdataWriteDto inCart)
        {

            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCart != null)
            {
                Cart dbCart = CartdataWriteDtoConvert.ToCart(inCart);
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

        // URL: api/Cart/7
        [HttpDelete, Route("{id}")]
        public ActionResult<bool> DeleteCart(int cartId)
        {
            ActionResult<bool> foundReturn;
            bool insertedId = false;
            Cart findCart = _cartControl.GetCart(_customerController.GetCustomerByCustomerNo(cartId));
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
