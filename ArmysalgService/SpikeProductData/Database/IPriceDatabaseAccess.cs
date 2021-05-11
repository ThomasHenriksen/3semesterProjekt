using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface IPriceDatabaseAccess
    {
        int CreatePrice(Price aPrice, Product product);
        int CreatePriceWithOutEndDate(Price aPrice, Product product);
        List<Price> GetPriceAll();
        List<Price> GetPriceByProductNo(int productNo);
        bool UpdateEndDatePrice(Price priceToUpdate);
        Price GetPriceByProductNoAndNoEndDate(int productNo);
        Price GetPriceById(int priceId);
        bool DeletePriceById(int priceId);
    }
}
