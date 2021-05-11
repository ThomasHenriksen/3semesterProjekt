﻿using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDatabaseAccess _CategoryAccess;
        private IPriceLogic _priceData;

        public CategoryLogic(IConfiguration inConfiguration)
        {
            _CategoryAccess = new CategoryDatabaseAccess(inConfiguration);
            _priceData = new PriceLogic(inConfiguration);
        }

        public int Add(Category aCategory)
        {
            int insertedId;

            insertedId = _CategoryAccess.CreateCategory(aCategory);
            aCategory.Id = insertedId;


            return insertedId;
        }


        /*
           *  this method is use to find a product in the database by id
           *  @param idToMatch
           *  
           *  @return Product
         */
        public Category Get(int idToMatch)
        {

            return _CategoryAccess.GetCategoryById(idToMatch);
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Category> GetAll()
        {

            return _CategoryAccess.GetCategorysAll(); ;
        }

        /*
           *  this method is use to update a product where ID is use to find product 
           *  @param productToUpdate
           *  @param id 
           *  @return bool
         */
        public bool Put(Category categoryToUpdate)
        {
            return _CategoryAccess.UpdateCategory(categoryToUpdate);
        }
    }
}
