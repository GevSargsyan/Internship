﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TrackingNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }

    }
}
