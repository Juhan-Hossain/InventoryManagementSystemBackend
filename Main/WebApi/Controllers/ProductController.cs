using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Repository.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ProductController : ControllerBase
    {
        //Initializing Business Logic layer to Api Controller
        private readonly Business_logic_Layer.ProductBLL _BLL;
        public ProductController()
        {
            _BLL = new Business_logic_Layer.ProductBLL();

        }

        [HttpGet]

    
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _BLL.GetAllProducts();
            if(products==null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Product> GetProductById(int id)
        {
            var product = _BLL.GetProductById(id);
            if(product == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(product);
        }

        [HttpPost]
   
        
        public ActionResult<List<Product>> PostProduct(Product product)
        {
           var products = _BLL.PostProduct(product);
            if (products == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(products);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public ActionResult<List<Product>> DeleteProductById(int id)
        {
           var products = _BLL.DeleteProductById(id);
            if (products == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(products);
        }

        [HttpPut]
        

        public ActionResult<List<Product>> PutProduct(Product product)
        {
            var products = _BLL.PutProduct(product);
            if (products == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(products);
        }
    }
}
