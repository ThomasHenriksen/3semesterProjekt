using ArmysalgClientWeb.ServiceLayer;

namespace ArmysalgClientWeb.BusinessLogic
{
    public class ShippingLogic
    {
        ShippingService _sAccess;
        public ShippingLogic()
        {
            _sAccess = new ShippingService();
        }
    }
}