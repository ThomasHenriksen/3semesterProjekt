using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class ProductDataWriteDtoConvert
    {
        public static Product ToProduct(ProductDataWriteDto inDto)
        {
            Product aProduct = null;
            if (inDto != null)
            {
                aProduct = new Product(inDto.Name, inDto.Description, inDto.PurchasePrice, inDto.Stock, inDto.MinStock, inDto.MaxStock, inDto.IsDeleted, inDto.price, inDto.Categories);
            }
            return aProduct;
        }
    }
}
