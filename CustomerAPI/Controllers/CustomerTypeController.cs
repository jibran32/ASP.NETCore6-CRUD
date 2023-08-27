using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeServices _serv;
        public CustomerTypeController(ICustomerTypeServices serv) 
        {
            _serv = serv;
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerType>>> GetCustomerTypes()
        {
            var result = await _serv.GetCustomerTypes();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerType>> AddCustomerType(CustomerType ct)
        {
            var result = await _serv.AddCustomerType(ct);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<CustomerType>> UpdateCustomerType(CustomerType ct)
        {
            var result = await _serv.UpdateCustomerType(ct);
            return Ok(ct);
        }
        [HttpDelete]
        public async Task<ActionResult<CustomerType>> DeleteCustomerType(CustomerType ct)
        {
            var result = await _serv.DeleteCustomerType(ct);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerType>> GetCustomerType(int Id)
        {
            var result = await _serv.GetCustomerTypeById(Id); 
            return Ok(result);
        }
    }
}
