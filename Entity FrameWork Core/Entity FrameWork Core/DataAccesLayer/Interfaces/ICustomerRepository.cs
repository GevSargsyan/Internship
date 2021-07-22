using Entity_FrameWork_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.Interfaces
{
  public  interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomer(int id,Customer customer);
        Task DeleteCustomer(int id);

    }
}
