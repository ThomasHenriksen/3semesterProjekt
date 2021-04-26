using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class CategoryDataWriteDto
    {
       
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> ProductCategory { get; set; }
        public CategoryDataWriteDto()
        {

        }
        public CategoryDataWriteDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public CategoryDataWriteDto( string name, string description, List<Product> productCateGory)
        {
        
            Name = name;
            Description = description;
            ProductCategory = productCateGory;
        }
    }
}
