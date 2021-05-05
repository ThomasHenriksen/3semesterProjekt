using ArmysalgService.DTOs;
using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class ProductdataWriteDtoConvert
    {
        public static Product ToProduct(ProductdataWriteDto inDto)
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
