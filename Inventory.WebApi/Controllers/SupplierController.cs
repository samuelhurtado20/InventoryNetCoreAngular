using Inventory.Business.Interfaces;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.WebApi.Controllers
{
    [Route("api/Supplier")]
    [ApiController]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierBusiness _supplierBUS;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger, ISupplierBusiness supplierBUS)
        {
            _supplierBUS = supplierBUS;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_supplierBUS.Insert(supplier));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_supplierBUS.GetById(id));
        }

        [HttpGet]
        [Route("{page:int}/{rows:int}")]
        public IActionResult GetPagedList(int page, int rows)
        {
            return Ok(_supplierBUS.PagedList(page, rows));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid && _supplierBUS.Update(supplier)) return Ok(new { Message = "The supplier is updated." });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier supplier)
        {
            if (supplier.Id > 0) return Ok(_supplierBUS.Delete(supplier));
            return BadRequest();
        }
    }
}
