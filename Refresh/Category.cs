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
    [Table(name: "Categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string CategoryName { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }


    //Dependent or child
    [Table("Products")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string ProductName { get; set; }

        [Precision(precision: 7, scale: 3)]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; } = false;
        public int? CategoryId { get; set; } // optional foregin key


        // Navigation
        public Category? Category { get; set; }
    }

}
