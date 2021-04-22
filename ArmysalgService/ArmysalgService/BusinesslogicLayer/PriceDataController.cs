using ArmysalgDataAccess.DatabaseLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class PriceDataController
    {
        IPriceAccess _PriceAccess;

        public PriceDataController(IConfiguration inConfiguration)
        {
            _PriceAccess = new PriceDatabaseAccess(inConfiguration);
        }
    }
}
