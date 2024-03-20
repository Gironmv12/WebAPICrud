using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Core.BL.Interfaces;

namespace WebAPICrud.Controllers
{
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
