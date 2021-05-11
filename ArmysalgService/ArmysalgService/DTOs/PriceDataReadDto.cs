using System;

namespace ArmysalgService.DTOs
{
    public class PriceDataReadDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        public PriceDataReadDto(int id, decimal value, DateTime startDate, DateTime? endDate)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            if (endDate != null)
            {
                EndDate = endDate;
            }

        }
    }
}
