using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Entities
{
    public partial class Customer
    {
     
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public long Contact { get; set; }
    
        public string Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
