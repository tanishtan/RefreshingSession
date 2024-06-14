using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Refresh
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }


        /*public int OrderID { get; set; } // optional foregin key

        public int ProductID { get; set; }*/


        // Navigation
        public Orders Order { get; set; }
        public Product Product { get; set; }

    }
}
