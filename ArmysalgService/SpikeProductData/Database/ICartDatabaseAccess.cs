using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public interface ICartDatabaseAccess
    {
        int CreateCart(Cart cartToAdd, Customer customer);
        bool DeleteCartByCartId(int cartId);
    }
}
