using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ICartDatabaseAccess
    {
        int CreateCart(Cart cartToAdd, Customer customer);
        Cart GetCartByCustomerNo(int CustomerNo);
        Cart GetCartById(int id);
        bool UpdateCart(Cart aCart);
        bool DeleteCartByCartId(int cartId);
    }
}
