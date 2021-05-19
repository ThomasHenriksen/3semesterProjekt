using System;

namespace ArmysalgClientWeb.Models
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        public override string ToString()
        {

            return Value.ToString();
        }
    }
}
