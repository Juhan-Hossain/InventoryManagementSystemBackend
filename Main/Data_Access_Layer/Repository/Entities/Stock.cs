using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Entities
{
    public partial class Stock
    {
        
        public int Id { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }

        public int ProductId { get; set; }

        public DateTime Date { get; set; }
        public virtual Product Product { get; set; }
    }
}
