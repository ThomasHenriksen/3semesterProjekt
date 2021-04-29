using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Model
{
    public class SalesLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public List<Product> Products { get; set; }

        public SalesLineItem()
        {
        }

        public SalesLineItem(int quantity, List<Product> products)
        {
            Quantity = quantity;
            Products = products;
        }
    }
}
