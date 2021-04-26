using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> ProductCategory { get; set; }
        public Category()
        {

        }
        public Category(string name , string description)
        {
            Name = name;
            Description = description;
        }
        public Category( int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Category(int id, string name, string description, List<Product> productCateGory)
        {
            Id = id;
            Name = name;
            Description = description;
            ProductCategory = productCateGory;
        }
    }
}
