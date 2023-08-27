using Kontakt.App.Context;
using Kontakt.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly KontaktDbContext _context;
        public CategoryController(KontaktDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories= await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
