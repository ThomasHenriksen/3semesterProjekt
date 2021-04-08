using ArmysalgService.DTOs;
using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        private static ProductdataReadDto FromProduct(Product inProduct)
        {
            ProductdataReadDto aProductReadDto = null;
            if (inProduct != null)
            {
                aProductReadDto = new ProductdataReadDto(inProduct.Name, inProduct.Description, inProduct.PurchasePrice, inProduct.Status, inProduct.Stock, inProduct.MinStock, inProduct.MaxStock, inProduct.IsDeleted);
            }
            return aProductReadDto;
        }
    }
}
