using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Core.BL.Interfaces;

namespace WebAPICrud.Controllers
{
    public class CatalogosController : Controller
    {

        private readonly ICatalogo _catalogoService;

        [HttpGet("ObtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            var resultado = await _catalogoService.ObtenerProductos();
            return Ok(resultado);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
