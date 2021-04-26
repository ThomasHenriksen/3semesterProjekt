using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class Cart
    {
        public DateTime LastUpdated { get; set; }

        public Cart()
        {
            LastUpdated = DateTime.Now;
        }

        public Cart(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }
    }
}
