using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class CategoryDataWriteDtoConvert
    {
        public static Category ToCategory(CategoryDataWriteDto inDto)
        {
            Category aCategory = null;
            if (inDto != null)
            {
                aCategory = new Category(inDto.Name, inDto.Description, inDto.ProductCategory);
            }
            return aCategory;
        }
    }
}
