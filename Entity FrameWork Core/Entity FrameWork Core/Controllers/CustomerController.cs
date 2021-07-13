using Entity_FrameWork_Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Controllers
{

   public class Cust
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int OrderHistoryId { get; set; }

    }

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CustomerController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomersAsync()
        {
            return await _db.Customers.ToListAsync();


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerIdAsync([FromRoute] int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
            if (customer != null) return customer;
            return NotFound();


        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomerAsync([FromBody] Cust cust)
        {
            if (cust!=null)
            {
                await _db.Customers.AddAsync(new Customer { Name = cust.Name, Address = cust.Address, OrderHistoryId = cust.OrderHistoryId });
                await _db.SaveChangesAsync();
                return Ok(cust);

            }
            return BadRequest();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync([FromRoute] int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
            if (customer!=null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put([FromRoute] int id,[FromBody] Cust cust)
        {

            var customer =await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Name = cust.Name;
            customer.Address = cust.Address;
            customer.OrderHistoryId = cust.OrderHistoryId;
            _db.Update(customer);
            await _db.SaveChangesAsync();
            return Ok(customer);
        }


    }
}
