using System;
using System.Collections.Generic;
using WebApi.Repository.Entities;
using AutoMapper;

using Data_Access_Layer;

namespace Business_logic_Layer
{
    public class ProductBLL
    {

        private readonly ProductDAL _DAL;

        public ProductBLL()
        {
            _DAL = new ProductDAL();
     
        }


        public List<Product> GetAllProducts()
        {
            List<Product> productsFromDb = _DAL.GetAllProducts();
            
            return productsFromDb;
        }


        public Product GetProductById(int id)
        {
            var ProductEntity = _DAL.GetProductById(id);

            return ProductEntity;

        }

        public List<Product> PostProduct(Product product)
        {
            
            var q = _DAL.PostProduct(product);
            return q;
        }


        public List<Product> DeleteProductById(int id)
        {
           
            var p = _DAL.DeleteProductById(id);
            return p;
        }

        public List<Product> PutProduct(Product product)
        {
            var p = _DAL.PutProduct(product);
            return p;
        }
    }
}
