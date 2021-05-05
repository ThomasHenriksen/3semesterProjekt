using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.Database
{
    public interface IProductDatabaseAccess
    {
        Product GetProductById(int findId);
        List<Product> GetProductAll();
        int CreateProduct(Product aProduct);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProductById(int id);


    }
}
