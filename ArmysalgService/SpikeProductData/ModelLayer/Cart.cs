using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Cart
    {
        public DateTime LastUpdated { get; set; }

        public Cart()
        {
        }

        public Cart(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }
    }
}
