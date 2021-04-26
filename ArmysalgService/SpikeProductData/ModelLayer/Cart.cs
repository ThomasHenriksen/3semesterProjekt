using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public Customer Customer { get; set; }

        public Cart()
        {
        }

        public Cart(Customer customer)
        {
            LastUpdated = DateTime.Now;
            Customer = customer;
        }

        public Cart(DateTime lastUpdated)
        {
            LastUpdated = lastUpdated;
        }

        public Cart(int id, DateTime lastUpdated)
        {
            Id = id;
            LastUpdated = lastUpdated;
        }
    }
}
