using ArmysalgService.BusinesslogicLayer;
using ArmysalgService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.Controllers
{
    [Route("api/persons")]
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

        // URL: api/products
        [HttpGet]
        public ActionResult<List<ProductdataReadDto>> Get()
        {
            return null;
        }

        // URL: api/products/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<ProductdataReadDto> Get(int id)
        {
            return null;
        }

        // URL: api/persons
        [HttpPost]
        public ActionResult PostNewProduct(ProductdataCreateDto inProduct)
        {
            return null;
        }

    }
}
