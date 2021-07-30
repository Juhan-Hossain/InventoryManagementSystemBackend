using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Business_logic_Layer
{
    public class CustomerBLL
    {


        private readonly CustomerDAL _DAL;

        public CustomerBLL()
        {
            _DAL = new CustomerDAL();

        }


        public List<Customer> GetAllCustomers()
        {
            List<Customer> CustomersFromDb = _DAL.GetAllCustomers();
         

            return CustomersFromDb;
        }


        public Customer GetCustomerById(int id)
        {
            var CustomerEntity = _DAL.GetCustomerById(id);
        
            return CustomerEntity;

        }


        public List<Customer> PostCustomer(Customer customer)
        {


            var p = _DAL.PostCustomer(customer);
            return p;
        }

        public List<Customer> DeleteCustomerById(int id)
        {

            var p = _DAL.DeleteCustomerById(id);
            return p;
        }

        public List<Customer> PutCustomer(Customer customer)
        {
            var p = _DAL.PutCustomer(customer);
            return p;
        }
    }
}
