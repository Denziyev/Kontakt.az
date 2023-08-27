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
            IEnumerable<Category> categories = await _context.Categories.Where(x => !x.IsDeleted)
      .Include(x => x.Subcategories).ToListAsync();
           

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.Categories= await _context.Categories.Where(x=>!x.IsDeleted).ToListAsync();
            category.ParentCategory = await _context.Categories
      .Where(x => !x.IsDeleted && x.Id == category.ParentCategoryId)
      .Include(x => x.Subcategories)
      .FirstOrDefaultAsync();


            if (!ModelState.IsValid)
            {
                return View();
            }
            category.CreatedAt = DateTime.Now;
            category.Subcategories = new List<Category>();
            category.ParentCategory?.Subcategories.Add(category);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            Category? category = await _context.Categories.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category postcategory, int id)
        {
            ViewBag.Categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            Category? category = await _context.Categories.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            category.Name = postcategory.Name;
            category.ParentCategoryId = postcategory.ParentCategoryId;
            category.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Category? category = await _context.Categories.Where(x => !x.IsDeleted && x.Id == id).Include(x => x.Subcategories).FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
       
            foreach (var item in category.Subcategories)
            {
                item.IsDeleted = true;
            }

            
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }
    }
}
