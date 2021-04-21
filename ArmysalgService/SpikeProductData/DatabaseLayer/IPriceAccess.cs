using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public  interface IPriceAccess
    {
        int CreatePrice(Price aPrice);
        int CreatePriceWithOutEndDate(Price aPrice);
        List<Price> GetPriceAll();
        List<Price> GetPriceByProductNo(int productNo);
        bool UpdateEndDatePrice(Price priceToUpdate);
        Price GetPriceByProductNoAndNoEndDate(int productNo);
    }
}
