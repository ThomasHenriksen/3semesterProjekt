using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System.Collections.Generic;

namespace ArmysalgService.ModelConversion
{
    public class ProductDataReadDtoConvert
    {
        public static List<ProductDataReadDto> FromProductCollection(List<Product> inProducts)
        {
            List<ProductDataReadDto> aProductReadDtoList = null;
            if (inProducts != null)
            {
                aProductReadDtoList = new List<ProductDataReadDto>();
                ProductDataReadDto tempDto;
                foreach (Product aProduct in inProducts)
                {
                    tempDto = FromProduct(aProduct);
                    aProductReadDtoList.Add(tempDto);
                }
            }
            return aProductReadDtoList;
        }

        public static ProductDataReadDto FromProduct(Product inProduct)
        {
            ProductDataReadDto aProductReadDto = null;
            if (inProduct != null)
            {
                aProductReadDto = new ProductDataReadDto(inProduct.Id, inProduct.Name, inProduct.Description, inProduct.PurchasePrice, inProduct.Stock, inProduct.MinStock, inProduct.MaxStock, inProduct.IsDeleted, inProduct.Price, inProduct.Category);
            }
            return aProductReadDto;
        }
    }
}
