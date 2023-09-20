using Azure;
using Kontakt.App.Context;
using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
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
        private readonly IWebHostEnvironment _env;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _env = env;
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
            if (category.formFile == null)
            {
                ModelState.AddModelError("FormFile", "The filed image is required");
                return View(category);
            }

            if (!Helper.IsImage(category.formFile))
            {
                ModelState.AddModelError("FormFile", "The file type must be image");
                return View(category);
            }
            if (!Helper.IsSizeOk(category.formFile, 1))
            {
                ModelState.AddModelError("FormFile", "The file size can not than more 1 mb");
                return View(category);
            }

            category.Image = category.formFile.CreateImage(_env.WebRootPath, "Assets/assets/images/Categories/");
            category.CreatedAt = DateTime.Now;
            category.Subcategories = new List<Category>();
            category.ParentCategory?.Subcategories.Add(category);
            MvcResponse<Category> response= await _categoryService.CreateAsync(category);
            TempData["category_contoller_response"] = response.Message;
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
            if (postcategory.formFile == null)
            {
                ModelState.AddModelError("FormFile", "The filed image is required");
                return View(postcategory);
            }

            if (!Helper.IsImage(postcategory.formFile))
            {
                ModelState.AddModelError("FormFile", "The file type must be image");
                return View(postcategory);
            }
            if (!Helper.IsSizeOk(postcategory.formFile, 1))
            {
                ModelState.AddModelError("FormFile", "The file size can not than more 1 mb");
                return View(postcategory);
            }

            MvcResponse<Category> response = await _categoryService.UpdateAsync(id, postcategory);
            TempData["category_contoller_response_update"] = response.Message;
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

           MvcResponse<Category> response= await _categoryService.DeleteAsync(id);
            TempData["category_contoller_response_delete"] = response.Message;
            return RedirectToAction("Index", "Category");
        }
    }
}
