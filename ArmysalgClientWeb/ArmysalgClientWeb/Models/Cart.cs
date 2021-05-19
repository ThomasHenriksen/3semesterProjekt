using System;
using System.Collections.Generic;

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
        //Method to calculate a total value of cart.
        /// <summary>
        /// Method to calculate a total value of cart.
        /// </summary>
        /// <returns>
        /// decimal
        /// </returns>
        private decimal CalcTotalValueOfCart()
        {
            decimal totalValue = 0;
            if (SalesLineItems != null)
            {
                foreach (SalesLineItem salesLineItem in SalesLineItems)
                {
                    totalValue += salesLineItem.TotalPrice;
                }
            }

            return totalValue;
        }

    }
}
