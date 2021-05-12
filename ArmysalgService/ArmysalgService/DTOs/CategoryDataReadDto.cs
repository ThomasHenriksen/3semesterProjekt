using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.DTOs
{
    public class CategoryDataReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> ProductCategory { get; set; }
        
        public CategoryDataReadDto()
        {
        }

        public CategoryDataReadDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public CategoryDataReadDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public CategoryDataReadDto(int id, string name, string description, List<Product> productCateGory)
        {
            Id = id;
            Name = name;
            Description = description;
            ProductCategory = productCateGory;
        }
    }
}
