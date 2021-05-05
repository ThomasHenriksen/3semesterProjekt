using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        public Price() { }

        public Price(decimal value, DateTime startDate, DateTime? endDate)
        {
            Value = value;
            StartDate = startDate;
            EndDate = endDate;

        }
        public Price(int id, decimal value, DateTime startDate)
        {
            Id = id;
            Value = value;
            StartDate = startDate;

        }
        public Price(int id, decimal value, DateTime startDate, DateTime? endDate)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            if (endDate != null)
            {
                EndDate = endDate;
            }

        }
        public override string ToString()
        {

            return Value.ToString();
        }
    }
}
