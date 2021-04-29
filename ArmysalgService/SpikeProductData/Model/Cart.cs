using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<SalesLineItem> SalesLineItems { get; set; }

        public Cart()
        {
        }

        public Cart(DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }

        public Cart(int id, DateTime lastUpdated)
        {
            Id = id;
            LastUpdated = lastUpdated;
        }
    }
}
