using Kontakt.App.Context;
using Kontakt.App.ViewModels;
using Kontakt.Core.Models;
using Kontakt.Service.Services.Interfaces;
using Kontakt.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Kontakt.App.Controllers
{
    public class HomeController : Controller
    {
 
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IDiscountService _discountService;
        private readonly IDiscountCategoryService _discountCategoryService;

        public HomeController(IProductService productService, ICategoryService categoryService, IDiscountService discountService, IDiscountCategoryService discountCategoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _discountService = discountService;
            _discountCategoryService = discountCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Products = (await _productService.GetAllAsync()).Data,
                Categories = (await _categoryService.GetAllAsync()).Data,
                Discounts=(await _discountService.GetAllAsync()).Data,
                DiscountsCategories=(await _discountCategoryService.GetAllAsync()).Data
            };
            return View(model);
        }

  
    }
}