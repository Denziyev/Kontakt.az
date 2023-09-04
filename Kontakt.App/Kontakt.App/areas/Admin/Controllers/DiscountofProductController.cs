using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountofProductController : Controller
    {
        private readonly IDiscountofProductService _discountofProductService;
        private readonly IDiscountCategoryService _categoryService;
        public DiscountofProductController(IDiscountofProductService discountofProductService, IDiscountCategoryService categoryService)
        {
            _discountofProductService = discountofProductService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(DiscountCategory discountCategory)
        {
            TempData["TempIdCate"] = discountCategory.Id;
            ViewBag.Tempp = discountCategory.Id;
            var resp = await _discountofProductService.GetAllAsync(discountCategory.Id);
            return View(resp);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Tempp = TempData["TempIdCate"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiscountofProduct discountofProduct)
        
        
        
        {
            var respp = await _categoryService.GetAsync(discountofProduct.DiscountCategoryId);
            discountofProduct.DiscountCategory = respp.Data;

            if (!ModelState.IsValid)
                return View(discountofProduct);

            discountofProduct.CreatedAt = DateTime.Now;
            await _discountofProductService.CreateAsync(discountofProduct);
            return RedirectToAction(nameof(Index), discountofProduct.DiscountCategory);
        }
    }
}
