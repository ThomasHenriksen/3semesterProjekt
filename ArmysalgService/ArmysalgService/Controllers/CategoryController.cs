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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic _cControl;
        private readonly IConfiguration _configuration;

        public CategoryController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _cControl = new CategoryLogic(_configuration);
        }


        /* Data retrieved from the database, is converted to eksternal 
         * format, evaluated and the an response must be sent back*/
        // URL: api/products
        [HttpGet]
        public ActionResult<List<CategoryDataReadDto>> Get()
        {
            ActionResult<List<CategoryDataReadDto>> foundReturn;
            // retrieve and convert data
            List<Category> foundCategory = _cControl.GetAll();
            List<CategoryDataReadDto> foundDts = ModelConversion.CategoryDataReadDtoConvert.FromCategoryCollection(foundCategory);
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
        public ActionResult<CategoryDataReadDto> Get(int id)
        {
            ActionResult<CategoryDataReadDto> foundReturn;
            // retrieve and convert data
            Category foundCategorys = _cControl.Get(id);

            CategoryDataReadDto foundDts = ModelConversion.CategoryDataReadDtoConvert.FromCategory(foundCategorys);
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
        public ActionResult<int> PostNewCategory(CategoryDataWriteDto inCategory)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCategory != null)
            {
                Category dbCategory = CategoryDataWriteDtoConvert.ToCategory(inCategory);
                insertedId = _cControl.Add(dbCategory);
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
        public ActionResult<int> PutUpdateCategory(int id, CategoryDataWriteDto inCategory)
        {

            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCategory != null)
            {
                Category dbCategory = CategoryDataWriteDtoConvert.ToCategory(inCategory);
                _cControl.Put(dbCategory);
                
                insertedId = dbCategory.Id;
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
    /*    // URL: api/Product/2
        [HttpDelete, Route("{id}")]
        public ActionResult<bool> DeleteCategory(int id)
        {
            ActionResult<bool> foundReturn;
            bool insertedId = false;
            Category findCategory = _cControl.Get(id);
            if (findCategory != null)
            {
                insertedId = _cControl.Delete(findCategory.Id);
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
        }*/
    }
}
