using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
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

        public Product()
        {
        }

        public Product(string name, string description, decimal purchasePrice, int stock, int minStock, int maxStock, bool isDeleted)
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
        }

        public Product(string name, string description, decimal purchasePrice, int stock, int minStock, int maxStock, bool isDeleted, Price? price, List<Category> categories)
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
