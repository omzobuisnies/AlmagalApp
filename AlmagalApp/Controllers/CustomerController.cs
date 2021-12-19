using AlmagalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmagalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customer;
        public CustomerController(ICustomerServices customer)
        {
            _customer = customer;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer =await _customer.Get();
            if (customer.response.Status)
                return Ok(customer);
            if (customer.response.Message.Equals("NotFound"))
                return NotFound(customer);
            return BadRequest(customer);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customer.Get(id);
            if (customer.response.Status)
                return Ok(customer);
            if (customer.response.Message.Equals("NotFound"))
                return NotFound(customer);
            return BadRequest(customer);
        }

    }
}
