using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface IProductLogic
    {
        Product Get(int id);
        List<Product> Get();
        int Add(Product productToAdd);
        bool Put(Product productToUpdate, int id);
        bool Delete(int id);
    }
}
