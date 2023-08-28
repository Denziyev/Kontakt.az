using Kontakt.App.Context;
using Kontakt.App.Models;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController( ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
           

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            MvcResponse<Category> resp =await _categoryService.GetAsync(category.ParentCategoryId);
            category.ParentCategory = (Category) resp.Data;

            if (!ModelState.IsValid)
            {
                return View();
            }
            category.CreatedAt = DateTime.Now;
            category.Subcategories = new List<Category>();
            category.ParentCategory?.Subcategories.Add(category);
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            MvcResponse<Category> resp = await _categoryService.GetAsync(id);
            Category? category = resp.Data;
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
            ViewBag.Categories = await _categoryService.GetAllAsync();


            if (!ModelState.IsValid)
            {
                return View();
            }
            await _categoryService.UpdateAsync(id, postcategory);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            MvcResponse<Category> resp = await _categoryService.GetAsync(id);
            Category? category = resp.Data;

            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index", "Category");
        }
    }
}
