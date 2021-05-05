using ArmysalgClientWeb.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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