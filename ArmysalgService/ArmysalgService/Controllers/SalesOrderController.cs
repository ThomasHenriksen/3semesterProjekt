using ArmysalgService.BusinesslogicLayer;
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


    }
}
