using ArmysalgDataAccess.Model;
using System.Collections.Generic;

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
