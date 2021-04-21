using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.ModelLayer
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Product Product { get; set; }

        public Price() { }

        public Price(decimal value, DateTime startDate, DateTime? endDate, Product product)
        {
            Value = value;
            StartDate = startDate;
            EndDate = endDate;
            Product = product;
        }
        public Price(int id, decimal value, DateTime startDate, Product product)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            Product = product;
        }
        public Price(int id, decimal value, DateTime startDate, DateTime? endDate, Product product)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            EndDate = endDate;
            Product = product;
        }
    }
}
