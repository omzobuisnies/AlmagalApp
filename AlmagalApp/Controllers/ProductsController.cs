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
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _product;
        public ProductsController(IProductServices product)
        {
            _product = product;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product =await _product.Get();
            if (product.response.Status)
                return Ok(product);
            if (product.response.Message.Equals("NotFound"))
                return NotFound(product);
            return BadRequest(product);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _product.Get(id);
            if (product.response.Status)
                return Ok(product);
            if (product.response.Message.Equals("NotFound"))
                return NotFound(product);
            return BadRequest(product);
        }

    }
}
