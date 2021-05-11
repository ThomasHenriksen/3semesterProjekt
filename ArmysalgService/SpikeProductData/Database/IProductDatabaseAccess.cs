using ArmysalgDataAccess.Model;
using System.Collections.Generic;

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
