using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
