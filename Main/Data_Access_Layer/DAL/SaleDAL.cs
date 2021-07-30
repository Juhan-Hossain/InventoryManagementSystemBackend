using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository;

namespace Data_Access_Layer
{
    public class SaleDAL
    {

        public List<Sale> GetAllSales()
        {
            var db = new InventoryDbContext();
            try
            {
                return db.Sales.ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //use meaningfull name
        public Sale GetSaleById(int id)
        {
            var db = new InventoryDbContext();


            try
            {
                //use find
                var p = db.Sales.Find(id);
                if (p == null)
                    throw new Exception("Not-found");
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Sale> PostSale(Sale sale)
        {
            var db = new InventoryDbContext();
            try
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return db.Sales.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public List<Sale> DeleteSaleById(int id)
        {
            var db = new InventoryDbContext();
            var p = new Sale();

            try
            {
                p = db.Sales.FirstOrDefault(e => e.Id == id);
                if (p != null)
                {
                    db.Sales.Remove(p);
                    db.SaveChanges();
                }
                return db.Sales.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Sale> PutSale(Sale sale)
        {
            var db = new InventoryDbContext();

            try
            {
                db.Update(sale);
                db.SaveChanges();
                return db.Sales.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
