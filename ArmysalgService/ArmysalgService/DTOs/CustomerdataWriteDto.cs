using ArmysalgDataAccess.Model;

namespace ArmysalgService.DTOs
{
    public class CustomerDataWriteDto : PersonDataWriteDto
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        public CustomerDataWriteDto()
        {
        }

    }
}
