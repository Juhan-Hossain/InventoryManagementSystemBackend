using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Repository.Entities;

namespace Data_Access_Layer
{
    public class CategoryDAL
    {
        public List<Category> GetAllCategories()
        {
            var db = new InventoryDbContext();
            try
            {
                return db.Categories.ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //use meaningfull name
        public Category GetCategoryById(int id)
        {
            var db = new InventoryDbContext();


            try
            {
                //use find
                var p = db.Categories.Find(id);
                if (p == null)
                    throw new Exception("Not-found");
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Category> PostCategory(Category category)
        {
            var db = new InventoryDbContext();
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return db.Categories.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public List<Category> DeleteCategoryById(int id)
        {
            var db = new InventoryDbContext();
            var p = new Category();

            try
            {
                p = db.Categories.FirstOrDefault(e => e.Id == id);
                if (p != null)
                {
                    db.Categories.Remove(p);
                    db.SaveChanges();
                }
                return db.Categories.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Category> PutCategory(Category category)
        {
            var db = new InventoryDbContext();

            try
            {
                db.Update(category);
                db.SaveChanges();
                return db.Categories.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
