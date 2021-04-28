using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDatabaseAccess _CategoryAccess;
        private IProductLogic _productAccess;

        public CategoryLogic(IConfiguration inConfiguration)
        {
            _CategoryAccess = new CategoryDatabaseAccess(inConfiguration);

            _productAccess = new ProductLogic(inConfiguration);

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
            Category foundCategory = null;
            foundCategory = _CategoryAccess.GetCategoryById(idToMatch);
            
            List<Product> foundtProducts = new List<Product>();
            
            foreach (int productId in _CategoryAccess.GetAllProductsForACategory(foundCategory)) {
                foundtProducts.Add(_productAccess.Get(productId));
            }
            foundCategory.ProductCategory = foundtProducts;
            return foundCategory;
        }
        /*
           *  this method is use to find all products in the database where IsDelete is false 
           *  @return List<Product> 
         */
        public List<Category> GetAll()
        {
            List<Category> foundCategory;

            foundCategory = _CategoryAccess.GetCategorysAll();

            foreach (Category category in foundCategory) {
                List<Product> foundtProducts = new List<Product>();
                foreach (int productId in _CategoryAccess.GetAllProductsForACategory(category))
                {
                    foundtProducts.Add(_productAccess.Get(productId));
                }
                category.ProductCategory = foundtProducts;
            }

            return foundCategory;
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
