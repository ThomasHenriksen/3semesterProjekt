using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
        [HttpGet]
        public ActionResult<List<SupplierDataReadDto>> GetAllSuppliers()
        {
            ActionResult<List<SupplierDataReadDto>> foundReturn;

            // Retrieve and convert data
            List<Supplier> foundSuppliers = _supplierLogic.GetAllSuppliers();
            List<SupplierDataReadDto> foundDto = ModelConversion.SupplierDataReadDtoConvert.FromSupplierCollection(foundSuppliers);

            if (foundDto != null)
            {
                if (foundDto != null)
                {
                    foundReturn = Ok(foundDto); //Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);  //Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500); //Server error
            }
            return foundReturn;
        }

        // URL: api/suppliers
        [HttpPost]
        public ActionResult<int> PostNewSupplier(SupplierDataWriteDto inSupplier)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            if (inSupplier != null)
            {
                Supplier dbSupplier = SupplierDataWriteDtoConvert.ToSupplier(inSupplier);
                insertedId = _supplierLogic.AddSupplier(dbSupplier);
            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);               //Statuscode 200
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    //Server error    
            }
            return foundReturn;
        }
    }
}
