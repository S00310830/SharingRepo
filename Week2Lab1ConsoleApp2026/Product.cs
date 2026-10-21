using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab1ConsoleApp2026
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("associatedCategory")]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public DateTime DateFirstIssued { get; set; }
        public int QuantityInStock { get; set; }
        public virtual Category associatedCategory { get; set; }
    }
}
