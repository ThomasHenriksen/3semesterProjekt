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
    [Route("api/salesOrders")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly SalesOrderdataControl _sControl;
        private readonly IConfiguration _configuration;

        public SalesOrderController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _sControl = new SalesOrderdataControl(_configuration);
        }

        //URL: api/salesOrders
        [HttpGet]
        public ActionResult<List<SalesOrderdataReadDto>> Get()
        {
            return null;
        }

        // URL: api/salesOrders/{id}
        [HttpGet, Route("id")]
        public ActionResult<SalesOrderdataReadDto> Get(int id)
        {
            return null;
        }

        // URL: api/salesOrders
        [HttpPost]
        public ActionResult PostNewSalesOrder(SalesOrderdataWriteDto inSalesOrder)
        {
            return null;
        }

    }
}
