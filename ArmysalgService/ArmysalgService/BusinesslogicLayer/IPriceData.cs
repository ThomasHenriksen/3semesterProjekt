using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public interface IPriceData
    {
        int Add(Price newPrice, Product product);
        Price Get(int idToMatch);
        List<Price> GetAll(int idToMatch);
        bool Put(Price PriceToUpdate, int id);
    }
}
