using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer
{
    public class CustomerService
    {
        private readonly AppDbContext _db;
        public CustomerService()
        {
            _db = new AppDbContext();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var query = from c in _db.Customers
                        join o in _db.Orders on c.CustomerID equals o.CustomerID
                        where c.Name == "Gev" && c.Address == "Erevan"
                        select c;


            var customerlist = await query.ToListAsync();

            return customerlist;

        }

        public async Task CreateCustomer()
        {
            var customer = new Customer
            {
                Name = "Gev",
                Address = "Erevan"
            
            };

         await   _db.Customers.AddAsync(customer);
         await   _db.SaveChangesAsync();


        }

        public async Task UpdateCustomer(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
            if (customer==null)
            {
                return;
            }

            customer.Name = "GevChanged";
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
            if (customer==null)
            {
                return;
            }

           
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
        }



    }
}
