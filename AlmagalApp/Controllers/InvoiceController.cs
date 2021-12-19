using AlmagalApp.Models.DTO;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _invoice;
        public InvoiceController(IInvoiceServices invoice)
        {
            _invoice = invoice;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inv =await _invoice.Get();
            if (inv.response.Status)
                return Ok(inv);
            if (inv.response.Message.Equals("NotFound"))
                return NotFound(inv);
            return BadRequest(inv);

        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var inv = await _invoice.Get(id);
            if (inv.response.Status)
                return Ok(inv);
            if (inv.response.Message.Equals("NotFound"))
                return NotFound(inv);
            return BadRequest(inv);
        }
        // GET api/<InvoiceController>/5
        [HttpGet("{invoicecode}")]
        public async Task<IActionResult> Get(int invoicecode)
        {
            var inv = await _invoice.Get(invoicecode);
            if (inv.response.Status)
                return Ok(inv);
            if (inv.response.Message.Equals("NotFound"))
                return NotFound(inv);
            return BadRequest(inv);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInvoiceVModel model)
        {
            var inv = await _invoice.Create(model);
            if (inv.Status)
                return Ok(inv);
            if (inv.Message=="Check CustomerId")
                return NotFound(inv);
            return BadRequest(inv);
        }

       
    }
}
