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
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductdata _pControl;
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _pControl = new ProductdataControl(_configuration);
        }


        /* Data retrieved from the database, is converted to eksternal 
         * format, evaluated and the an response must be sent back*/
        // URL: api/products
        [HttpGet]
        public ActionResult<List<ProductdataReadDto>> Get()
        {
            ActionResult<List<ProductdataReadDto>> foundReturn;
            // retrieve and convert data
            List<Product> foundProducts = _pControl.Get();
            List<ProductdataReadDto> foundDts = ModelConversion.ProductdataReadDtoConvert.FromProductCollection(foundProducts);
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
        public ActionResult<ProductdataReadDto> Get(int id, Product product)
        {
            ActionResult<ProductdataReadDto> foundReturn;
            // retrieve and convert data
            Product foundProducts = _pControl.Get(id);

            ProductdataReadDto foundDts = ModelConversion.ProductdataReadDtoConvert.FromProduct(foundProducts);
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
        public ActionResult<int> PostNewProduct(ProductdataWriteDto inProduct)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inProduct != null)
            {
                Product dbProduct = ProductdataWriteDtoConvert.ToProduct(inProduct);
                insertedId = _pControl.Add(dbProduct);
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
        public ActionResult<int> PutUpdateProduct(int id, ProductdataWriteDto inProduct)
        {

            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inProduct != null)
            {
                Product dbProduct = ProductdataWriteDtoConvert.ToProduct(inProduct);
                _pControl.Put(dbProduct, id);
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
            Product findProduct = _pControl.Get(id);
            if (findProduct != null)
            {
                insertedId = _pControl.Delete(findProduct.Id);
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
