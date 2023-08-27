using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _services.GetCustomers());
        }
        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer c)
        { 
            var result = await _services.AddCustomer(c);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int Id)
        {
            var result = await _services.GetCustomerById(Id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer c)
        {
            var result = await _services.UpdateCustomer(c);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomer(Customer c)
        {
            var result = await _services.DeleteCustomer(c);
            return Ok(result);
        }
    }
}
