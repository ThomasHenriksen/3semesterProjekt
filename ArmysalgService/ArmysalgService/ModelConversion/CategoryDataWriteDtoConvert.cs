using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

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
