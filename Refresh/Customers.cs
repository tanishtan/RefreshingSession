using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresh
{
    [Table("Customers")]
    public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string CustomerId { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? ContactName { get; set; }
        
        [Column(TypeName = "varchar(15)")]
        public string? City { get; set; }
        
        [Column(TypeName = "varchar(15)")]
        public string? Country { get; set; }
        
        //public int? CategoryId { get; set; } // optional foregin key


        // Navigation
        public Orders Order { get; set; }
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
