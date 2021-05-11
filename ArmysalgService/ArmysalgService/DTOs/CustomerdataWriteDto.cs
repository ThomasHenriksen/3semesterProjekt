using ArmysalgDataAccess.Model;

namespace ArmysalgService.DTOs
{
    public class CustomerdataWriteDto : PersondataWriteDto
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        public CustomerdataWriteDto()
        {
        }

    }
}
