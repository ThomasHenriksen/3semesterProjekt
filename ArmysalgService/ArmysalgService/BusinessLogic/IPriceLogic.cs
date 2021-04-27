using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public interface IPriceLogic
    {
        int Add(Price newPrice, Product product);
        Price Get(int idToMatch);
        List<Price> GetAll(int idToMatch);
        bool Put(Price PriceToUpdate);
    }
}
