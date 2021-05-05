using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public interface IShippingLogic
    {
        Shipping AddShipping(Shipping shippingToAdd);
        Shipping GetShippingByID(int shippingToFind);
    }
}