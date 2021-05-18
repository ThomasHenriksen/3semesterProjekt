using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ModelLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }

        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public bool IsDeleted { get; set; }
        public Price price { get; set; }
        public List<Category> Categories { get; set; }
        public Supplier Supplier { get; set; }

        // Constuct a product object.
        /// <summary>
        /// Constuct a product object.
        /// </summary>
        public Product()
        {
        }

        // Constuct a product object.
        /// <summary>
        /// Constuct a product object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="purchasePrice"></param>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        /// <param name="maxStock"></param>
        /// <param name="isDeleted"></param>
        /// <param name="price"></param>
        /// <param name="categories"></param>
        public Product(string name, string description, decimal purchasePrice,  int stock, int minStock, int maxStock, bool isDeleted, Price? price, List<Category> categories)
        {           
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            this.price = price;
            Categories = categories;            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
