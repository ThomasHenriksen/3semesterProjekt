using ArmysalgDataAccess.Model;
using System.Collections.Generic;

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

        public CategoryDataWriteDto(string name, string description, List<Product> productCateGory)
        {

            Name = name;
            Description = description;
            ProductCategory = productCateGory;
        }
    }
}
