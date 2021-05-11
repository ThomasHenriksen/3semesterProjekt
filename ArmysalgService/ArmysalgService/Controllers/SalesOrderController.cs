using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.Controllers
{
    [Route("api/salesOrders")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderLogic _salesOrderLogíc;
        private readonly IConfiguration _configuration;

        public SalesOrderController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _salesOrderLogíc = new SalesOrderLogic(_configuration);
        }

        //URL: api/salesOrders
        [HttpGet]
        public ActionResult<List<SalesOrderDataReadDto>> Get()
        {
            return null;
        }

        // URL: api/salesOrders/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<SalesOrderDataReadDto> Get(int id)
        {
            ActionResult<SalesOrderDataReadDto> foundReturn;

            SalesOrder foundSalesOrder = _salesOrderLogíc.GetSalesOrderById(id);

            SalesOrderDataReadDto foundDts = SalesOrderdataReadDtoConvert.FromSalesOrder(foundSalesOrder);

            if (foundDts != null)
            {
                if (foundDts != null)
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
        public ActionResult<int> PostNewSalesOrder(SalesOrderDataWriteDto inSalesOrder)
        {
            ActionResult<int> foundReturn;
            int insertedSalesNo = -1;
            if (inSalesOrder != null)
            {
                SalesOrder dbSalesOrder = SalesOrderdataWriteDtoConvert.ToSalesOrder(inSalesOrder);
                insertedSalesNo = _salesOrderLogíc.AddSalesOrder(dbSalesOrder);
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
