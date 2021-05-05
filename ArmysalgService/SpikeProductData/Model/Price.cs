using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Model
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
            EndDate = endDate;

        }
    }
}
