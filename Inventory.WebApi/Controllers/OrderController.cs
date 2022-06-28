using Inventory.Business.Interfaces;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventory.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _orderBUS;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderBusiness orderBUS)
        {
            _logger = logger;
            _orderBUS = orderBUS;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_orderBUS.Insert(order));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderBUS.GetById(id));
        }

        [HttpGet]
        [Route("{page:int}/{rows:int}")]
        public IActionResult GetPagedList(int page, int rows)
        {
            return Ok(_orderBUS.PagedList(page, rows));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (ModelState.IsValid && _orderBUS.Update(order)) return Ok(new { Message = "The order is updated." });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Order order)
        {
            if (order.Id > 0) return Ok(_orderBUS.Delete(order));
            return BadRequest();
        }
    }
}
