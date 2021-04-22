﻿using ArmysalgClientDesktop.ModelLayer;
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



        public async Task<int> SaveProduct(string name, string description, decimal purchasePrice, string status,
            int stock, int minStock, int maxStock, bool isDeleted)
        {
            Product newProduct = null;
            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                newProduct = new Product(name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted);
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
                    newProduct = new Product(name, description, purchasePrice, status, stock, minStock, maxStock, isDeleted);
                }
            }
            return await _pAccess.SaveProduct(newProduct, tokenValue);
        }

        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;

        }
    }
}
