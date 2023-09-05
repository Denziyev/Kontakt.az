using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
