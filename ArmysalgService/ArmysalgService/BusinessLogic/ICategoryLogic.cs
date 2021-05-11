using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface ICategoryLogic
    {
        int Add(Category aCategory);
        Category Get(int idToMatch);
        List<Category> GetAll();
        bool Put(Category categoryToUpdate);
    }
}
