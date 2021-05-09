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
        public decimal TotalValueOfCart
        {
            get { return CalcTotalValueOfCart(); }
        }


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

        private decimal CalcTotalValueOfCart()
        {
            decimal totalValue = 0;

            foreach (SalesLineItem salesLineItem in SalesLineItems)
            {
                totalValue += salesLineItem.TotalPrice;
            }

            return totalValue;
        }

    }
}
