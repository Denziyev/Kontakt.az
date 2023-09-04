using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _env;

        public BrandController(IBrandService brandService, IWebHostEnvironment env)
        {
            _brandService = brandService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetAllAsync();


            return View(brands);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {

            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            if (brand.formFile == null)
            {
                ModelState.AddModelError("FormFile", "The filed image is required");
                return View(brand);
            }

            if (!Helper.IsImage(brand.formFile))
            {
                ModelState.AddModelError("FormFile", "The file type must be image");
                return View(brand);
            }
            if (!Helper.IsSizeOk(brand.formFile, 1))
            {
                ModelState.AddModelError("FormFile", "The file size can not than more 1 mb");
                return View(brand);
            }

            brand.Image = brand.formFile.CreateImage(_env.WebRootPath, "Assets/assets/images/Brands/");
            brand.CreatedAt = DateTime.Now;
            await _brandService.CreateAsync(brand);
            return RedirectToAction(nameof(Index));
        }
    }
}
