using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierLogic _supplierLogic;
        private readonly IConfiguration _configuration;

        public SupplierController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _supplierLogic = new SupplierLogic(_configuration);
        }

        // URL: api/suppliers
        [HttpPost]
        public ActionResult<int> PostNewSupplier(SupplierDataWriteDto inSupplier)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if(inSupplier != null)
            {
                Supplier dbSupplier = SupplierDataWriteDtoConvert.ToSupplier(inSupplier);
                insertedId = _supplierLogic.CreateSupplier(dbSupplier);
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
    
    }
}
