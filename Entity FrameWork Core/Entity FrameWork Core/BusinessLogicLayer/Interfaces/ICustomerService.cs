using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.BusinessLogicLayer.Interfaces
{
   public interface ICustomerService
    {
        Task GetAndUpdate(int id);
    }
}
