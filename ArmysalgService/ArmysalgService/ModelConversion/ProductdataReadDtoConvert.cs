using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System.Collections.Generic;

namespace ArmysalgService.ModelConversion
{
    public class ProductdataReadDtoConvert
    {
        public static List<ProductdataReadDto> FromProductCollection(List<Product> inProducts)
        {
            List<ProductdataReadDto> aProductReadDtoList = null;
            if (inProducts != null)
            {
                aProductReadDtoList = new List<ProductdataReadDto>();
                ProductdataReadDto tempDto;
                foreach (Product aProduct in inProducts)
                {
                    tempDto = FromProduct(aProduct);
                    aProductReadDtoList.Add(tempDto);
                }
            }
            return aProductReadDtoList;
        }

        public static ProductdataReadDto FromProduct(Product inProduct)
        {
            ProductdataReadDto aProductReadDto = null;
            if (inProduct != null)
            {
                aProductReadDto = new ProductdataReadDto(inProduct.Id, inProduct.Name, inProduct.Description, inProduct.PurchasePrice, inProduct.Stock, inProduct.MinStock, inProduct.MaxStock, inProduct.IsDeleted, inProduct.Price, inProduct.Category);
            }
            return aProductReadDto;
        }
    }
}
