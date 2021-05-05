using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
     class CategoryControl
    {
        CategoryServiceAccess _cAccess;


        public CategoryControl()
        {
            _cAccess = new CategoryServiceAccess();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> foundCategories = await _cAccess.GetAllCategories();
            return foundCategories;
        }

    }
}
