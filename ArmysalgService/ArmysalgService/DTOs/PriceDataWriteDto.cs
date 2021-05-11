using System;

namespace ArmysalgService.DTOs
{
    public class PriceDataWriteDto
    {
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public PriceDataWriteDto(decimal value, DateTime startDate, DateTime? endDate)
        {
            Value = value;
            StartDate = startDate;
            if (endDate != null)
            {
                EndDate = endDate;
            }

        }
    }
}
