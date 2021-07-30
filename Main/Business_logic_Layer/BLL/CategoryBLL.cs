using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Business_logic_Layer
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _DAL;

        public CategoryBLL()
        {
            _DAL = new CategoryDAL();
            

        }


        public List<Category> GetAllCategories()
        {
            List<Category> CategorysFromDb = _DAL.GetAllCategories();

            return CategorysFromDb;
        }


        public Category GetCategoryById(int id)
        {
            var CategoryEntity = _DAL.GetCategoryById(id);
            
            return CategoryEntity;

        }

    
        public List<Category> PostCategory(Category category)
        {
           
            var p = _DAL.PostCategory(category);
            return p;
        }


  
        public List<Category> DeleteCategoryById(int id)
        {

            var p = _DAL.DeleteCategoryById(id);
            return p;
        }

        public List<Category> PutCategory(Category product)
        {
            var p = _DAL.PutCategory(product);
            return p;
        }
    }
}
