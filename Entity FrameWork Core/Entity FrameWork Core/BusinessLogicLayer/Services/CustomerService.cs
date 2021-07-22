using Entity_FrameWork_Core.BusinessLogicLayer.Interfaces;
using Entity_FrameWork_Core.DataAccesLayer.UnitOfWork;
using Entity_FrameWork_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.BusinessLogicLayer.Services
{
    public class CustomerService:ICustomerService
    {

        IUnitOfWork _unitofwork;
        public CustomerService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task GetAndUpdate(int id)
        {
            var customer = await _unitofwork.Customers.GetCustomerByIdAsync(id);

            await _unitofwork.Customers.UpdateCustomer(id,new Customer { Name="Updated"});
        }

    }
}
