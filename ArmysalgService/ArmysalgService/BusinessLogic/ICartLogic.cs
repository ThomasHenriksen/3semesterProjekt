using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public interface ICartLogic
    {
        Cart GetCart(int id);
        int AddCart(Cart cartToAdd, Customer customer);
        bool DeleteCart(int id);
    }
}
