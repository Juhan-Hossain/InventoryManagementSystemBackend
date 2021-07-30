using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Repository.Entities;

namespace Data_Access_Layer
{
    public class StockDAL
    {
        public List<Stock> GetAllStocks()
        {
            var db = new InventoryDbContext();
            try
            {
                return db.Stocks.ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //use meaningfull name
        public Stock GetStockById(int id)
        {
            var db = new InventoryDbContext();


            try
            {
                //use find
                var p = db.Stocks.Find(id);
                if (p == null)
                    throw new Exception("Not-found");
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Stock> PostStock(Stock stock)
        {
            var db = new InventoryDbContext();
            try
            {
                db.Stocks.Add(stock);
                var product = db.Products.Find(stock.ProductId);
                product.AvailableQuantity += stock.Quantity;
                db.Products.Update(product);
                db.SaveChanges();
                return db.Stocks.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public List<Stock> DeleteStockById(int id)
        {
            var db = new InventoryDbContext();
            var p = new Stock();

            try
            {
                p = db.Stocks.FirstOrDefault(e => e.Id == id);
                if (p != null)
                {
                    db.Stocks.Remove(p);
                    db.SaveChanges();
                }
                return db.Stocks.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Stock> PutStock(Stock stock)
        {
            var db = new InventoryDbContext();

            try
            {
                db.Update(stock);
                db.SaveChanges();
                return db.Stocks.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
