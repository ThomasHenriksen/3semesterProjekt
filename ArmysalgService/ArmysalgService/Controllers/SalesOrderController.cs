using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
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
        private readonly SalesOrderLogic _sControl;
        private readonly IConfiguration _configuration;

        public SalesOrderController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _sControl = new SalesOrderLogic(_configuration);
        }

        //URL: api/salesOrders
        [HttpGet]
        public ActionResult<List<SalesOrderdataReadDto>> Get()
        {
            return null;
        }

        // URL: api/salesOrders/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<SalesOrderdataReadDto> Get(int id)
        {
            ActionResult<SalesOrderdataReadDto> foundReturn;

            SalesOrder foundSalesOrder = _sControl.GetSalesOrderById(id);

            SalesOrderdataReadDto foundDts = SalesOrderdataReadDtoConvert.FromSalesOrder(foundSalesOrder);

            if(foundDts != null)
            {
                if(foundDts != null)
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
            return foundReturn;
        }

        // URL: api/salesOrders
        [HttpPost]
        public ActionResult<int> PostNewSalesOrder(SalesOrderdataWriteDto inSalesOrder)
        {
            ActionResult<int> foundReturn;
            int insertedSalesNo = -1;
            if(inSalesOrder != null)
            {
                SalesOrder dbSalesOrder = ModelConversion.SalesOrderdataWriteDtoConvert.ToSalesOrder(inSalesOrder);
                insertedSalesNo = _sControl.AddSalesOrder(dbSalesOrder);
            }
            if (insertedSalesNo > 0) 
            {
                foundReturn = Ok(insertedSalesNo);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

    }
}
