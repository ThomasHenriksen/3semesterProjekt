using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface ICartLogic
    {
        Cart Get(Customer customer);
        int AddCart(Cart cartToAdd, Customer customer);
        Cart UpdateCart(Cart aCurrCart);
        bool DeleteCart(int id);
    }
}
