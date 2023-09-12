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

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Products = (await _productService.GetAllAsync()).Data
            };
            return View(model);
        }

  
    }
}