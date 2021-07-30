using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        //Initializing Business Logic layer to Api Controller
        private readonly Business_logic_Layer.SaleBLL _BLL;
        public SaleController()
        {
            _BLL = new Business_logic_Layer.SaleBLL();

        }

        [HttpGet]


        public ActionResult<List<Sale>> GetAllSales()
        {
            var products = _BLL.GetAllSales();
            if (products == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Sale> GetSaleById(int id)
        {
            var sale = _BLL.GetSaleById(id);
            if (sale == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(sale);
        }

        [HttpPost]


        public ActionResult<List<Sale>> PostSale(Sale sale)
        {
            var sales = _BLL.PostSale(sale);
            if (sales == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(sales);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public ActionResult<List<Sale>> DeleteSaleById(int id)
        {
            var Sales = _BLL.DeleteSaleById(id);
            if (Sales == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(Sales);
        }

        [HttpPut]


        public ActionResult<List<Sale>> PutSale(Sale sale)
        {
            var Sales = _BLL.PutSale(sale);
            if (Sales == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(Sales);
        }
    }
}
