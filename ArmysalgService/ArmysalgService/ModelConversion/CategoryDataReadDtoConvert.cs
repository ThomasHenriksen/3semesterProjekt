using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System.Collections.Generic;

namespace ArmysalgService.ModelConversion
{
    public class CategoryDataReadDtoConvert
    {
        public static List<CategoryDataReadDto> FromCategoryCollection(List<Category> inCategory)
        {
            List<CategoryDataReadDto> aCategoryDataReadDto = null;
            if (inCategory != null)
            {
                aCategoryDataReadDto = new List<CategoryDataReadDto>();
                CategoryDataReadDto tempDto;
                foreach (Category aCategory in inCategory)
                {
                    tempDto = FromCategory(aCategory);
                    aCategoryDataReadDto.Add(tempDto);
                }
            }
            return aCategoryDataReadDto;
        }

        public static CategoryDataReadDto FromCategory(Category inCategory)
        {
            CategoryDataReadDto aCategoryDataReadDto = null;
            if (inCategory != null)
            {
                aCategoryDataReadDto = new CategoryDataReadDto(inCategory.Id, inCategory.Name, inCategory.Description, inCategory.ProductCategory);
            }
            return aCategoryDataReadDto;
        }
    }
}
