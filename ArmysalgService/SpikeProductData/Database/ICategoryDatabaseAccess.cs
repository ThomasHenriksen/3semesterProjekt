using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
