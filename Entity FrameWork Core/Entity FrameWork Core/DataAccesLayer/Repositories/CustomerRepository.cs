using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext _db;
        public CustomerRepository()
        {
            _db = new AppDbContext();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null) { throw new Exception("Not Found"); }
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customerlist = await _db.Customers.ToListAsync();

            return customerlist;

        }

        public async Task CreateCustomerAsync(Customer customer)
        {

            if (customer != null)
            {
                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();

            }
            return;

        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            var customerforupdate = await GetCustomerByIdAsync(id);
            if (customerforupdate == null)
            {
                return;
            }

            customerforupdate.Name = customer.Name;

            _db.Customers.Update(customerforupdate);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await GetCustomerByIdAsync(id);
            if (customer==null)
            {
                return;
            }

           
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
        }

      

    }
}
