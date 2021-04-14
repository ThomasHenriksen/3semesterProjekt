using ArmysalgDataAccess.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public interface IProductdata
    {
        Product Get(int id);
        List<Product> Get();
        int Add(Product productToAdd);
        bool Put(Product productToUpdate, int id);
        bool Delete(int id);
    }
}
