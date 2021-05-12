using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDatabaseAccess _categoryAccess;

        public CategoryLogic(IConfiguration inConfiguration)
        {
            _categoryAccess = new CategoryDatabaseAccess(inConfiguration);
        }

        // Add category to the database.
        /// <inheritdoc/>
        public int AddCategory(Category aCategory)
        {
            int insertedCategoryId;

            try
            {
                insertedCategoryId = _categoryAccess.AddCategory(aCategory);
                aCategory.Id = insertedCategoryId;
            }
            catch (System.Exception)
            {
                insertedCategoryId = -1;
            }
            return insertedCategoryId;
        }

        // Find and return category from database by category id.
        /// <inheritdoc/>
        public Category GetCategory(int categoryId)
        {
            Category foundCategory;
            try
            {
                foundCategory = _categoryAccess.GetCategoryById(categoryId);
            }
            catch
            {
                foundCategory = null;
            }
            return foundCategory;
        }

        // Find and return all categories from database.
        /// <inheritdoc/>
        public List<Category> GetAllCategories()
        {
            List<Category> foundCategories;

            try
            {
                foundCategories = _categoryAccess.GetAllCategories();
            }
            catch
            {
                foundCategories = null;
            }
            return foundCategories;
        }

        // Updates category from database based on category object.
        /// <inheritdoc/>
        public bool UpdateCategory(Category categoryToUpdate)
        {
            bool categoryHasBeenUpdated;

            try
            {
                categoryHasBeenUpdated = _categoryAccess.UpdateCategory(categoryToUpdate);
            }
            catch
            {
                categoryHasBeenUpdated = false;
            }
            return categoryHasBeenUpdated;
        }
    }
}
