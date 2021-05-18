using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ModelLayer
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category()
        {

        }
        // Construct a category object.
        /// <summary>
        /// Construct a category object.
        /// </summary>
        /// <param name="name">Name of category</param>
        /// <param name="description">Description of category</param>
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
