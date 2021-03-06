using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.DTOs
{
    public class ProductDataWriteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }

        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public bool IsDeleted { get; set; }
        public Price price { get; set; }
        public List<Category> Categories { get; set; }
        public ProductDataWriteDto()
        {
        }

        public ProductDataWriteDto(string name, string description, decimal purchasePrice, int stock, int minStock, int maxStock, bool isDeleted, Price price, List<Category> categories)
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
    }
}
