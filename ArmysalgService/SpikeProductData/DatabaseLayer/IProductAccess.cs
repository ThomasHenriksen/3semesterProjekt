using SpikeProductData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public interface IProductAccess
    {
        Product GetProductById(int id);
        List<Product> GetProductAll();
        int CreateProduct(Product productToAdd);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProductById(int id);
    }
}
