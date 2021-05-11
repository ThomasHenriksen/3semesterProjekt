using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.Controllers
{
    [Route("api/products")]
    [ApiController]
    // [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _productLogic;
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _productLogic = new ProductLogic(_configuration);
        }


        /* Data retrieved from the database, is converted to eksternal 
         * format, evaluated and the an response must be sent back*/
        // URL: api/products
        [HttpGet]
        public ActionResult<List<ProductDataReadDto>> Get()
        {
            ActionResult<List<ProductDataReadDto>> foundReturn;
            // retrieve and convert data
            List<Product> foundProducts = _productLogic.Get();
            List<ProductDataReadDto> foundDts = ModelConversion.ProductDataReadDtoConvert.FromProductCollection(foundProducts);
            // evaluate
            if (foundDts != null)
            {
                if (foundDts.Count > 0)
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

        // URL: api/products/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<ProductDataReadDto> Get(int id)
        {
            ActionResult<ProductDataReadDto> foundReturn;
            // retrieve and convert data
            Product foundProducts = _productLogic.Get(id);

            ProductDataReadDto foundDts = ModelConversion.ProductDataReadDtoConvert.FromProduct(foundProducts);
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
        public ActionResult<int> PostNewProduct(ProductDataWriteDto inProduct)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inProduct != null)
            {
                Product dbProduct = ProductDataWriteDtoConvert.ToProduct(inProduct);
                insertedId = _productLogic.Add(dbProduct);
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
        public ActionResult<int> PutUpdateProduct(int id, ProductDataWriteDto inProduct)
        {

            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inProduct != null)
            {
                Product dbProduct = ProductDataWriteDtoConvert.ToProduct(inProduct);
                dbProduct.Id = id;
                _productLogic.Put(dbProduct);
                insertedId = dbProduct.Id;
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
        public ActionResult<bool> DeleteProduct(int id)
        {
            ActionResult<bool> foundReturn;
            bool insertedId = false;
            Product findProduct = _productLogic.Get(id);
            if (findProduct != null)
            {
                insertedId = _productLogic.Delete(findProduct.Id);
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
