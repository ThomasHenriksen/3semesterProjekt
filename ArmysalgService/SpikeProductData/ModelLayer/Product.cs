using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public bool IsDeleted { get; set; }
        public Price? Price { get; set; }
        public List<Category> Category { get; set; }
        public Product()
        {
        }

        public Product(string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted)
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
        }

        public Product(int id, string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
          
        }
        public Product(string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted, Price? price) 
        {
          
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            Price = price;
        }
        public Product(int id, string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted, Price? price)
        {
            Id = id;
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            Price = price;
        }
        public Product(string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted, List<Category> category)
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            Category = category;
        }
        public Product(int id ,string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted,  List<Category> category)
        {
            Id = id;
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            Category = category;
        }
    }
}
