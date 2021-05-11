using System;

namespace ArmysalgDataAccess.Model
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        // Constuct a price object.
        /// <summary>
        /// Constuct a price object.
        /// </summary>
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

        // Constuct a price object.
        /// <summary>
        /// Constuct a price object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Price(int id, decimal value, DateTime startDate, DateTime? endDate)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            EndDate = endDate;

        }
    }
}
