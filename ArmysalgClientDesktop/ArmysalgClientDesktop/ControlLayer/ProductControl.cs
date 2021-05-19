using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.Security;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
    public class ProductControl
    {
        ProductServiceAccess _pAccess;

        public ProductControl()
        {
            _pAccess = new ProductServiceAccess();
        }

        //  Find and return products.
        /// <summary>
        /// Find and return products.
        /// </summary>
        /// <returns>
        /// List of product.
        /// </returns>
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> foundProducts = null; // await _pAccess.GetProducts();

            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                foundProducts = await _pAccess.GetProducts(tokenValue);
                if (_pAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    foundProducts = await _pAccess.GetProducts(tokenValue);
                }
            }
            return foundProducts;
        }

        //  Save a new product object.
        /// <summary>
        /// Save a new product object.
        /// </summary>
        /// <returns>
        /// Employee number of saved employee object.
        /// </returns>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="purchasePrice"></param>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        /// <param name="maxStock"></param>
        /// <param name="isDeleted"></param>
        /// <param name="value"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="categories"></param>
        public async Task<int> SaveProduct(string name, string description, decimal purchasePrice, 
            int stock, int minStock, int maxStock, bool isDeleted, decimal value, DateTime startDate, DateTime? endDate, List<Category> categories)
        {
            Price price = null;
            Product newProduct = null;
            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                price = new Price( value,  startDate, endDate);
                newProduct = new Product(name, description, purchasePrice,  stock, minStock, maxStock, isDeleted, price, categories);
                newProduct.price = price;
                if (_pAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    price = new Price(value, startDate, endDate);
                    newProduct = new Product(name, description, purchasePrice,  stock, minStock, maxStock, isDeleted, price, categories);
                    newProduct.price = price;
                }
            }
            return await _pAccess.SaveProduct(newProduct, tokenValue);
        }

        //  Find and return Jwt token.
        /// <summary>
        /// Find and return Jwt token.
        /// </summary>
        /// <returns>
        /// A Jwt token objekt.
        /// </returns>
        /// <param name="useState">Jwt token objekt</param>
        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;
        }
    }
}
