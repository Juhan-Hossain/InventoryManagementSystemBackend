using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class SaleBLL
    {
        private readonly SaleDAL _DAL;

        public SaleBLL()
        {
            _DAL = new SaleDAL();

        }


        public List<Sale> GetAllSales()
        {
            List<Sale> SalesFromDb = _DAL.GetAllSales();


            return SalesFromDb;
        }


        public Sale GetSaleById(int id)
        {
            var SaleEntity = _DAL.GetSaleById(id);

            return SaleEntity;

        }


        public List<Sale> PostSale(Sale sale)
        {


            var p = _DAL.PostSale(sale);
            return p;
        }

        public List<Sale> DeleteSaleById(int id)
        {

            var p = _DAL.DeleteSaleById(id);
            return p;
        }

        public List<Sale> PutSale(Sale sale)
        {
            var p = _DAL.PutSale(sale);
            return p;
        }
    }
}
