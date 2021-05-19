using System.Collections.Generic;

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



        public override string ToString()
        {
            return Name;
        }
    }
}
