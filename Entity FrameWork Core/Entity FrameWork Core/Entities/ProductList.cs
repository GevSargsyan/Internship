using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class ProductList
    {
        public int ProductListId { get; set; }
        public string Name { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public List<Product> Products { get; set; }


    }
}
