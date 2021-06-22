using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public OrderHistory OrderHistory { get; set; }
         [ForeignKey("OrderHistoryId")]
        public int OrderHistoryId { get; set; }

        public List<Order> Orders { get; set; }

    }
}
