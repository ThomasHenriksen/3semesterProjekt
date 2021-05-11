using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ICategoryDatabaseAccess
    {
        int CreateCategory(Category aCategory);
        List<Category> GetCategorysAll();
        Category GetCategoryById(int findId);
        bool UpdateCategory(Category categoryToUpdate);
        bool DeleteCategoryByCategoryId(int categoryId);
    }
}
