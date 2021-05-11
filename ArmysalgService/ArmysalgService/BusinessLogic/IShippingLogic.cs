using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface IShippingLogic
    {
        Shipping AddShipping(Shipping shippingToAdd);
        Shipping GetShippingByID(int shippingToFind);
    }
}