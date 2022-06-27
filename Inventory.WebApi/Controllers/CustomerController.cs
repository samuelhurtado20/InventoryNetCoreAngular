using Inventory.Models;
using Inventory.UnitOfWork;
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
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_uow.Customer.Insert(customer));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_uow.Customer.GetById(id));
        }

        [HttpGet]
        [Route("{page:int}/{rows:int}")]
        public IActionResult GetPagedList(int page, int rows)
        {
            return Ok(_uow.Customer.GetCustomerPagedList(page, rows));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _uow.Customer.Update(customer)) return Ok(new { Message = "The customer is updated."});
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0) return Ok(_uow.Customer.Delete(customer));
            return BadRequest();
        }
    }
}
