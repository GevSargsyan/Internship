using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<ProductList> ProductLists { get; set; }
    }
}
