using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Business_logic_Layer
{
    public class StockBLL
    {
        private readonly StockDAL _DAL;

        public StockBLL()
        {
            _DAL = new StockDAL();

        }


        public List<Stock> GetAllStocks()
        {
            List<Stock> StocksFromDb = _DAL.GetAllStocks();


            return StocksFromDb;
        }


        public Stock GetStockById(int id)
        {
            var StockEntity = _DAL.GetStockById(id);

            return StockEntity;

        }


        public List<Stock> PostStock(Stock stock)
        {


            var p = _DAL.PostStock(stock);
            return p;
        }

        public List<Stock> DeleteStockById(int id)
        {

            var p = _DAL.DeleteStockById(id);
            return p;
        }

        public List<Stock> PutStock(Stock stock)
        {
            var p = _DAL.PutStock(stock);
            return p;
        }
    }
}
