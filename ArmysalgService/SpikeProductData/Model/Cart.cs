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

        // Constuct a cart object.
        /// <summary>
        /// Constuct a cart object.
        /// </summary>
        /// <param name="lastUpdated">Time of last update of cart.</param>
        public Cart(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }

        // Constuct a cart object.
        /// <summary>
        /// Constuct a cart object.
        /// </summary>
        /// <param name="lastUpdated">Time of last update of cart.</param>
        /// <param name="salesLineItems">Salesline items on cart.</param>
        public Cart(DateTime lastUpdated, List<SalesLineItem> salesLineItems)
        {
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItems;
        }

        // Constuct a cart object.
        /// <summary>
        /// Constuct a cart object.
        /// </summary>
        /// <param name="id">ID of cart.</param>
        /// <param name="lastUpdated">Time of last update of cart.</param>
        /// <param name="salesLineItem">Salesline items on cart.</param>
        public Cart(int id, DateTime lastUpdated, List<SalesLineItem> salesLineItem)
        {
            Id = id;
            LastUpdated = lastUpdated;
            SalesLineItems = salesLineItem;
        }
    }
}
