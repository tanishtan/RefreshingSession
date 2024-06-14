using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresh
{
    [Table("Products")]
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? ShipCity { get; set; }

        public string CustomerId { get; set; }// optional foregin key


        // Navigation
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public Customers Customer { get; set; }
    }
}
