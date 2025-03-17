using Microsoft.AspNetCore.Mvc;
using API.API.Services;

namespace ToDoList.WebHost.Controllers
{
    [Route("api/shopping")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraAppService _compraAppService;

        public CompraController(ICompraAppService compraAppService)
        {
            _compraAppService = compraAppService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(CreateCompraDto input)
        //{
        //    var compra = await _compraAppService.CreateAsync(input);
        //    if (compra == null) return NotFound();

        //    return Ok(compra);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllCompras()
        {
            var compras = await _compraAppService.GetAllComprasAsync();

            return Ok(compras);
        }

        //[HttpDelete("delete-all")]
        //public async Task<IActionResult> DeleteAllCompras()
        //{
        //    await _compraAppService.DeleteAllComprasAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompraById(Guid id)
        //{
        //    var deleted = await _compraAppService.DeleteByIdCompraAsync(id);

        //    return NoContent();
        //}
    }
}
