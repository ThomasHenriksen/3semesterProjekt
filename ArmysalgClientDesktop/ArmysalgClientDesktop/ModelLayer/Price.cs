using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ModelLayer
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Price() { }

        // Constuct a price object.
        /// <summary>
        /// Constuct a price object.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Price(decimal value, DateTime startDate, DateTime? endDate)
        {
            Value = value;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
