using Inventory.Business.Interfaces;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventory.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBUS;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerBusiness customerBUS)
        {
            _logger = logger;
            _customerBUS = customerBUS;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_customerBUS.Insert(customer));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_customerBUS.GetById(id));
        }

        [HttpGet]
        [Route("{page:int}/{rows:int}")]
        public IActionResult GetPagedList(int page, int rows)
        {
            return Ok(_customerBUS.PagedList(page, rows));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _customerBUS.Update(customer)) return Ok(new { Message = "The customer is updated."});
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0) return Ok(_customerBUS.Delete(customer));
            return BadRequest();
        }
    }
}
