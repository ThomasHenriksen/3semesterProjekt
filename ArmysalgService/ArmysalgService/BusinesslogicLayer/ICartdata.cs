using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public interface ICartdata
    {
        Cart GetCart(int id);
        int AddCart(Cart cartToAdd);
        bool DeleteCart(int id);
    }
}
