using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Product
    {
        public Int64 ProductID { get; set; }
        public String Name { get; set; }
        [Column(TypeName = "Decimal(8,2)")]
        public Decimal Price { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }

    }
}
