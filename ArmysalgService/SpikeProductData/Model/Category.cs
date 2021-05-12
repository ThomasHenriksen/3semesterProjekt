using System.Collections.Generic;

namespace ArmysalgDataAccess.Model
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

        // Construct a category object.
        /// <summary>
        /// Construct a category object.
        /// </summary>
        /// <param name="id">Category id of category</param>
        /// <param name="name">Name of category</param>
        /// <param name="description">Description of category</param>
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        // Contruct a category object.
        /// <summary>
        /// Contruct a category object.
        /// </summary>
        /// <param name="name">Name of category</param>
        /// <param name="description">Description of category</param>
        /// <param name="productCategory">List of products</param>
        public Category(string name, string description, List<Product> productCategory)
        {
            Name = name;
            Description = description;
            ProductCategory = productCategory;
        }

        // Contruct a category object.
        /// <summary>
        /// Contruct a category object.
        /// </summary>
        /// <param name="id">Category id of category</param>
        /// <param name="name">Name of category</param>
        /// <param name="description">Description of category</param>
        /// <param name="productCategory">List of products</param>
        public Category(int id, string name, string description, List<Product> productCategory)
        {
            Id = id;
            Name = name;
            Description = description;
            ProductCategory = productCategory;
        }
    }
}
