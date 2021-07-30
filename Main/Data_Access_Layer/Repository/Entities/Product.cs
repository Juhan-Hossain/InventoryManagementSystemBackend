using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Entities
{

    public partial class Product
    {
        public Product()
        {
            // check it into database
             Stocks = new HashSet<Stock>();
        }


        public int Id { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public float AvailableQuantity { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
}

}
