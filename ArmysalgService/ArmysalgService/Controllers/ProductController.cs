using ArmysalgService.BusinesslogicLayer;
using ArmysalgService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductdataControl _pControl;
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
        public ActionResult<ProductdataReadDto> Get(int id)
        {
            return null;
        }

        // URL: api/persons
        [HttpPost]
        public ActionResult<int> PostNewProduct(ProductdataCreateDto inProduct)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inProduct != null)
            {
                Product dbProduct = ModelConversion.ProductdataCreateDtoConvert.ToProduct(inProduct);
                insertedId = _pControl.Add(dbProduct);
            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);
            } else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn; 
        }

    }
}
