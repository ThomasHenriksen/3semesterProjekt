using System;
using System.Collections.Generic;

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

        public Cart(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }

        public Cart(DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }

        public Cart(int id, DateTime lastUpdated, List<SalesLineItem> salesLineItem)
        {
            Id = id;
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItem;
        }
    }
}
