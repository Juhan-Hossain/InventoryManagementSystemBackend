using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository;
using WebApi.Repository.Entities;

namespace Data_Access_Layer
{
    public class CustomerDAL
    {
        public List<Customer> GetAllCustomers()
        {
            var db = new InventoryDbContext();
            try
            {
                return db.Customers.ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //use meaningfull name
        public Customer GetCustomerById(int id)
        {
            var db = new InventoryDbContext();


            try
            {
                //use find
                var p = db.Customers.Find(id);
                if (p == null)
                    throw new Exception("Not-found");
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Customer> PostCustomer(Customer customer)
        {
            var db = new InventoryDbContext();
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return db.Customers.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public List<Customer> DeleteCustomerById(int id)
        {
            var db = new InventoryDbContext();
            var p = new Customer();

            try
            {
                p = db.Customers.FirstOrDefault(e => e.Id == id);
                if (p != null)
                {
                    db.Customers.Remove(p);
                    db.SaveChanges();
                }
                return db.Customers.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Customer> PutCustomer(Customer customer)
        {
            var db = new InventoryDbContext();

            try
            {
                db.Update(customer);
                db.SaveChanges();
                return db.Customers.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
