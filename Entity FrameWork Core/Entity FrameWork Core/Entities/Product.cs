using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }

        public DateTime DateSold { get; set; }
        public string Description { get; set; }


       // [ForeignKey("ProductListId")]
        public int ProductListId { get; set; }

        public ProductList ProductList { get; set; }
        public Sale Sale { get; set; }

        public Order Order { get; set; }




    }
}
