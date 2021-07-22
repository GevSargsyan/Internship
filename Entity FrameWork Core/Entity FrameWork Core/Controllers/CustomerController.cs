using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
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

 

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
             _customerRepository = customerRepository;

           
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomersAsync()
        {
           return await _customerRepository.GetCustomersAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerIdAsync([FromRoute] int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer != null) return customer;
            return NotFound();


        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomerAsync([FromBody] Customer cust)
        {
            if (cust!=null)
            {
               await _customerRepository.CreateCustomerAsync(cust);
                return Ok(cust);

            }
            return BadRequest();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync([FromRoute] int id)
        {
             await _customerRepository.DeleteCustomer(id);
            return Ok();
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomerAsync([FromRoute] int id,[FromBody] Customer customer)
        {

            await _customerRepository.UpdateCustomer(id, customer);
            return Ok(customer);
        }


    }
}
