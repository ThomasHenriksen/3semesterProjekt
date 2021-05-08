using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class SalesLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }
        public decimal TotalPrice
        {
            get { return Products.price.Value * Quantity; }
        }


        public SalesLineItem()
        {
        }

        public SalesLineItem(int quantity, Product products)
        {
            Quantity = quantity;
            Products = products;
        }

        public SalesLineItem(Product products)
        {
            Quantity = 1;
            Products = products;
        }
        public SalesLineItem(int id, int quantity, Product products)
        {
            Id = id;
            Quantity = quantity;
            Products = products;
        }
    }
}
