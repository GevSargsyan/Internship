using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
using Entity_FrameWork_Core.DataAccesLayer.Repositories;
using Entity_FrameWork_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private AppDbContext _db;
        public UnitOfWork()
        {
            _db = new AppDbContext();
        }
        public ICustomerRepository Customers {
            get 
            {
                return new CustomerRepository();
            } 
        } 
        
        public IProductRepository Products {
            get 
            {
                return new ProductRepository();
            } 
        }
     
    }
}
