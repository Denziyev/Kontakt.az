using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
