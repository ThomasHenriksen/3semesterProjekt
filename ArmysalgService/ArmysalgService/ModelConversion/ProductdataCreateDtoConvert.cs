using ArmysalgService.DTOs;
using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class ProductdataCreateDtoConvert
    {
        public static Product ToProduct(ProductdataCreateDto inDto)
        {
            Product aProduct = null;
            if (inDto != null)
            {
                aProduct = new Product(inDto.Name, inDto.Description, inDto.PurchasePrice, inDto.Status, inDto.Stock, inDto.MinStock, inDto.MaxStock, inDto.IsDeleted);
            }
            return aProduct;
        }
    }
}
