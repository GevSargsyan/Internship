using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public DateTime OrderTime { get; set; }

        public Customer Customer { get; set; }




    }
}
