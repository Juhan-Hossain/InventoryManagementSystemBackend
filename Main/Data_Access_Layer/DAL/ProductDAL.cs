using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Repository;
using WebApi.Repository.Entities;

namespace Data_Access_Layer
{
    //Providing database connection with api
    public class ProductDAL
    {
        public List<Product> GetAllProducts()
        {
            var db = new InventoryDbContext();
            try
            {
                return db.Products.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        //use meaningfull name
        public Product GetProductById(int id)
        {
            var db = new InventoryDbContext();
            

            try
            {
                //use find
                var p = db.Products.Find(id);
                if (p == null)
                    throw new Exception("Not-found");
                return p;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Product> PostProduct(Product product)
        {
            var db = new InventoryDbContext();
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return db.Products.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
            
            
        }

        public List<Product> DeleteProductById(int id)
        {
            var db = new InventoryDbContext();
            var p = new Product();
            
            try
            {
                p = db.Products.FirstOrDefault(e => e.Id == id);
                if (p != null)
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                }
                return db.Products.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public List<Product> PutProduct(Product product)
        {
            var db = new InventoryDbContext();
            
            try
            {
                db.Update(product);
                db.SaveChanges();
                return db.Products.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
