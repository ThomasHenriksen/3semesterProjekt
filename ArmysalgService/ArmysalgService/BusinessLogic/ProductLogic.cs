﻿using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        IProductDatabaseAccess _productAccess;
        IPriceLogic _priceData;
        public ProductLogic(IConfiguration inConfiguration)
        {
            _productAccess = new ProductDatabaseAccess(inConfiguration);
            _priceData = new PriceLogic(inConfiguration);
        }
        /*
           *  this method is use to create a new product in the database
           *  @param newProduct
           *  
           *  @return insertedId
         */
        public int Add(Product newProduct)
        {
            int insertedId;
            try
            {
                insertedId = _productAccess.CreateProduct(newProduct);
                newProduct.Id = insertedId;
                _priceData.Add(newProduct.Price, newProduct);
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int idToMatch)
        {
            return _productAccess.DeleteProductById(idToMatch);
        }
        /*
           *  this method is use to find a product in the database by id
           *  @param idToMatch
           *  
           *  @return Product
         */
        public Product Get(int idToMatch)
        {
            Product foundProduct;
            try
            {
                foundProduct = _productAccess.GetProductById(idToMatch);
                foundProduct.Price = _priceData.Get(idToMatch);
            }
            catch
            {
                foundProduct = null;
            }
            return foundProduct;
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Product> Get()
        {
            List<Product> foundProducts;

            foundProducts = _productAccess.GetProductAll();
            foreach (Product product in foundProducts)
            {
                if (_priceData.Get(product.Id) != null)
                {
                    product.Price = _priceData.Get(product.Id);
                }
                else
                {
                    product.Price = null;
                }
            }


            return foundProducts;
        }
        /*
           *  this method is use to update a product where ID is use to find product 
           *  @param productToUpdate
           *  @param id 
           *  @return bool
         */
        public bool Put(Product productToUpdate, int id)
        {
            productToUpdate.Id = id;

           Price checkPrice = _priceData.Get(productToUpdate.Id);
            if (checkPrice == null)
            {
                _priceData.Add(productToUpdate.Price, productToUpdate);

            }
            else {
                if (checkPrice.Id != productToUpdate.Id ) {
                    _priceData.Add(productToUpdate.Price, productToUpdate);
                }
            }



            return _productAccess.UpdateProduct(productToUpdate);
        }
    }
}