﻿using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ICategoryDatabaseAccess
    {
        // Add Category to the database.
        /// <summary>
        /// Add Category to the database.
        /// </summary>
        /// <returns>
        /// Category id of inserted Category object.
        /// </returns>
        /// <param name="aCategory">Category object.</param>
        int AddCategory(Category aCategory);

        // Find and return category from database by category id.
        /// <summary>
        /// Find and return category from database by category id.
        /// </summary>
        /// <returns>
        /// Category object.
        /// </returns>
        /// <param name="categoryId">Category id.</param>
        Category GetCategoryById(int categoryId);

        // Find and return all categories from database.
        /// <summary>
        /// Find and return all categories from database.
        /// </summary>
        /// <returns>
        /// A list of category objects.
        /// </returns>
        List<Category> GetAllCategories();

        // Updates category from database based on category object.
        /// <summary>
        /// Updates category from database based on category object.
        /// </summary>
        /// <returns>
        /// Bool statement whether category was updated or not.
        /// </returns>
        /// <param name="categoryToUpdate">Category object.</param>
        bool UpdateCategory(Category categoryToUpdate);

        // Delete category from database based on category id.
        /// <summary>
        /// Delete category from database based on category id.
        /// </summary>
        /// <returns>
        /// Bool statement whether category was deleted or not.
        /// </returns>
        /// <param name="categoryId">Category id.</param>
        bool DeleteCategoryByCategoryId(int categoryId);
    }
}
