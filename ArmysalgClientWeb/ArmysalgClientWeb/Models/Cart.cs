using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }

        public Cart()
        {
            LastUpdated = DateTime.Now;
        }

        public Cart(int id, DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            Id = id;
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }
    }
}
