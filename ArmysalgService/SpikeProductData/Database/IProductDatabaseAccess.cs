using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface IProductDatabaseAccess

    {
        // Add product to the database.
        /// <summary>
        /// Add product to the database.
        /// </summary>
        /// <returns>
        /// Product number of inserted product object.
        /// </returns>
        /// <param name="aProduct">product object.</param>
        int AddProduct(Product aProduct);

        // Find and return product from database by product number.
        /// <summary>
        /// Find and return product from database by product number.
        /// </summary>
        /// <returns>
        /// product object.
        /// </returns>
        /// <param name="ProductNo">product number.</param>
        Product GetProductByProductNo(int ProductNo);

        // Find and return all product from database.
        /// <summary>
        /// Find and return all product from database.
        /// </summary>
        /// <returns>
        /// product object.
        /// </returns>
        List<Product> GetProductAll();

        // Update a product to the database.
        /// <summary>
        /// Update a product to the database.
        /// </summary>
        /// <returns>
        ///  Bool statement whether product has be updated or not.
        /// </returns>
        /// <param name="aProduct">product object.</param>
        bool UpdateProduct(Product aProduct);

        // Delete product from database based on product object.
        /// <summary>
        /// Delete product from database based on product object.
        /// </summary>
        /// <returns>
        /// Bool statement whether product was deleted or not.
        /// </returns>
        /// <param name="productNo">product number.</param>
        bool DeleteProductByProductNo(int productNo);


    }
}
