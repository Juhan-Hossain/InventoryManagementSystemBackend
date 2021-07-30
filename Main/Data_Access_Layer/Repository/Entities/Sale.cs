using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Data_Access_Layer.Repository.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        public virtual Product Product { get; set; }
  
        public virtual Customer Customer { get; set; }
    }
}
