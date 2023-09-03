using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountCategoryController : Controller
    {
        private readonly IDiscountCategoryService _discountCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IDiscountService _discountService;
        private readonly ITagService _tagService;
        private readonly IWebHostEnvironment _env;
        public DiscountCategoryController(IDiscountCategoryService discountCategoryService, ICategoryService categoryService, IDiscountService discountService, ITagService tagService, IWebHostEnvironment env)
        {
            _discountCategoryService = discountCategoryService;
            _categoryService = categoryService;
            _discountService = discountService;
            _tagService = tagService;
            _env = env;
        }


        public async Task< IActionResult> Index(Discount discount)
        {
            TempData["TempId"] = discount.Id;
            ViewBag.Temp = discount.Id;
            var resp= await _discountCategoryService.GetAllAsync(discount.Id);
            return View(resp);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Temp = TempData["TempId"];
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiscountCategory discountCategory)
        {
            ViewBag.Categories = await  _categoryService.GetAllAsync();
            var resp = await _categoryService.GetAsync(discountCategory.CategoryId);
            discountCategory.Category = resp.Data;
            var respp = await _discountService.GetAsync(discountCategory.DiscountId);
            discountCategory.Discount = respp.Data;

            discountCategory.Images = new List<DiscountImage>();
           

            if (!ModelState.IsValid)
                return View(discountCategory);

            if (discountCategory.FormFiles == null || discountCategory.FormFiles.Count == 0)
            {
                ModelState.AddModelError("", "min image count 1");
                return View(discountCategory);
            }
            
            foreach (var item in discountCategory.FormFiles)
            {
                if (!Helper.IsImage(item))
                {
                    ModelState.AddModelError("", "it is not image");
                    return View(discountCategory);
                }
                if (!Helper.IsSizeOk(item, 1))
                {
                    ModelState.AddModelError("", "image size must be less 1");
                    return View(discountCategory);
                }



                //product.ProductImages.Add(productImage); buda olar
                 discountCategory.Images.Add(new DiscountImage
                 {
                     CreatedAt = DateTime.Now,
                     Image = item.CreateImage(_env.WebRootPath, "Assets/assets/images/DiscountCategory/"),
                     DiscountCategory=discountCategory
                 });
            }
            
           await _discountCategoryService.CreateAsync(discountCategory);
            return RedirectToAction(nameof(Index),discountCategory.Discount);
        }
    }
}
