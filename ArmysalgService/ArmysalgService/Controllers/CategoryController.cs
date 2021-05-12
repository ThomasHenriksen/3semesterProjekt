using ArmysalgDataAccess.Model;
using ArmysalgService.BusinessLogic;
using ArmysalgService.DTOs;
using ArmysalgService.ModelConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic _categoryLogic;
        private readonly IConfiguration _configuration;

        public CategoryController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _categoryLogic = new CategoryLogic(_configuration);
        }

        // URL: api/categories
        [HttpGet]
        public ActionResult<List<CategoryDataReadDto>> GetAllCategories()
        {
            ActionResult<List<CategoryDataReadDto>> foundReturn;

            // retrieve and convert data
            List<Category> foundCategory = _categoryLogic.GetAllCategories();
            List<CategoryDataReadDto> foundDts = ModelConversion.CategoryDataReadDtoConvert.FromCategoryCollection(foundCategory);

            if (foundDts != null)
            {
                if (foundDts.Count > 0)
                {
                    foundReturn = Ok(foundDts);                 //Statuscode 200
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
            return foundReturn;
        }

        // URL: api/categories/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<CategoryDataReadDto> GetCategoryById(int categoryId)
        {
            ActionResult<CategoryDataReadDto> foundReturn;


            // retrieve and convert data
            Category foundCategorys = _categoryLogic.GetCategory(categoryId);
            CategoryDataReadDto foundDts = ModelConversion.CategoryDataReadDtoConvert.FromCategory(foundCategorys);

            if (foundDts != null)
            {
                if (foundDts != null)
                {
                    foundReturn = Ok(foundDts);                 //Statuscode 200
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
            return foundReturn;
        }

        // URL: api/categories
        [HttpPost]
        public ActionResult<int> PostNewCategory(CategoryDataWriteDto inCategory)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            if (inCategory != null)
            {
                Category dbCategory = CategoryDataWriteDtoConvert.ToCategory(inCategory);
                insertedId = _categoryLogic.AddCategory(dbCategory);
            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);                   //Statuscode 200
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        //Server error
            }
            return foundReturn;
        }

        // URL: api/categories/2
        [HttpPut, Route("{id}")]
        public ActionResult<int> PutUpdateCategory(int id, CategoryDataWriteDto inCategory)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            if (inCategory != null)
            {
                Category dbCategory = CategoryDataWriteDtoConvert.ToCategory(inCategory);
                _categoryLogic.UpdateCategory(dbCategory);

                insertedId = dbCategory.Id;
            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);                   //Statuscode 200             
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        //Server error
            }
            return foundReturn;
        }
    }
}
