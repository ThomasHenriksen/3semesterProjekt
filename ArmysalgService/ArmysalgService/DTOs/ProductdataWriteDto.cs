using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.DTOs
{
    public class ProductdataWriteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public bool IsDeleted { get; set; }
        public Price? price { get; set; }
        public ProductdataWriteDto()
        {
        }

        public ProductdataWriteDto(string name, string description, decimal purchasePrice, string status, int stock, int minStock, int maxStock, bool isDeleted, Price price)
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            Status = status;
            Stock = stock;
            MinStock = minStock;
            MaxStock = maxStock;
            IsDeleted = isDeleted;
            this.price = price;
        }
    }
}
