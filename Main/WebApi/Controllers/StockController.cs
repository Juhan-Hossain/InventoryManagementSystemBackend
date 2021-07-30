using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        //Initializing Business Logic layer to Api Controller
        private readonly Business_logic_Layer.StockBLL _BLL;
        public StockController()
        {
            _BLL = new Business_logic_Layer.StockBLL();

        }

        [HttpGet]


        public ActionResult<List<Stock>> GetAllStocks()
        {
            var stocks = _BLL.GetAllStocks();
            if (stocks == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Stock> GetStockById(int idw)
        {
            var stock = _BLL.GetStockById(idw);
            if (stock == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(stock);
        }

        [HttpPost]


        public ActionResult<List<Stock>> PostStock(Stock stock)
        {
            var stocks = _BLL.PostStock(stock);
            if (stocks == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(stocks);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public ActionResult<List<Stock>> DeleteStockById(int id)
        {
            var stocks = _BLL.DeleteStockById(id);
            if (stocks == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(stocks);
        }

        [HttpPut]


        public ActionResult<List<Stock>> PutStock(Stock stock)
        {
            var stocks = _BLL.PutStock(stock);
            if (stocks == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(stocks);
        }
    }
}
