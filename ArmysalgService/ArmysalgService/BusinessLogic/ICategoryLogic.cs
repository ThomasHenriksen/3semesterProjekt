using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
  public  interface ICategoryLogic
    {
        int Add(Category aCategory);
        Category Get(int idToMatch);
        List<Category> GetAll();
        bool Put(Category categoryToUpdate);
    }
}
