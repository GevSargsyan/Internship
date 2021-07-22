using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.UnitOfWork
{
   public interface IUnitOfWork
    {
        ICustomerRepository Customers {get;}
        IProductRepository Products {get;}
    }
}
