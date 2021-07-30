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
    public class CustomerController: ControllerBase
    {
        //Initializing Business Logic layer to Api Controller
        private readonly Business_logic_Layer.CustomerBLL _BLL;
        public CustomerController()
        {
            _BLL = new Business_logic_Layer.CustomerBLL();

        }

        [HttpGet]


        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _BLL.GetAllCustomers();
            if (customers == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _BLL.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(customer);
        }

        [HttpPost]


        public ActionResult<List<Customer>> PostCustomer(Customer customer)
        {
            var customers = _BLL.PostCustomer(customer);
            if (customers == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(customers);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public ActionResult<List<Customer>> DeleteCustomerById(int id)
        {
            var customers = _BLL.DeleteCustomerById(id);
            if (customers == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(customers);
        }

        [HttpPut]


        public ActionResult<List<Customer>> PutCustomer(Customer customer)
        {
            var customers = _BLL.PutCustomer(customer);
            if (customers == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(customers);
        }
    }
}
