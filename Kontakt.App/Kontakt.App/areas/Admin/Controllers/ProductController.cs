using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _env;
        private readonly IDiscountofProductService _discountService;
        private readonly ITagService _tagService;
        private readonly ICreditService _creditService;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService, IWebHostEnvironment env, IDiscountofProductService discountService, ITagService tagService, ICreditService creditService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _env = env;
            _discountService = discountService;
            _tagService = tagService;
            _creditService = creditService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();


            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.Brands=await _brandService.GetAllAsync();
            ViewBag.Discounts=await _discountService.GetAllWithoutIdAsync();
            ViewBag.Tags = await _tagService.GetAllAsync();
            ViewBag.Credits=await _creditService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.Brands = await _brandService.GetAllAsync();
            ViewBag.Discounts = await _discountService.GetAllWithoutIdAsync();
            ViewBag.Tags = await _tagService.GetAllAsync();
            ViewBag.Credits = await _creditService.GetAllAsync();

            product.ProductImages = new List<ProductImage>();
            product.ProductTags = new List<ProductTag>();
            product.ProductCredits = new List<ProductCredit>();

            if (!ModelState.IsValid)
                return View(product);
            if (product.FormFiles == null || product.FormFiles.Count == 0)
            {
                ModelState.AddModelError("", "min image count 1");
                return View(product);
            }
            int i = 0;
            foreach (var item in product.FormFiles)
            {
                if (!Helper.IsImage(item))
                {
                    ModelState.AddModelError("", "it is not image");
                    return View(product);
                }
                if (!Helper.IsSizeOk(item, 1))
                {
                    ModelState.AddModelError("", "image size must be less 1");
                    return View(product);
                }
   
                //product.ProductImages.Add(productImage); buda olar
                 product.ProductImages.Add(new ProductImage
                 {
                     CreatedAt = DateTime.Now,
                     Image = item.CreateImage(_env.WebRootPath, "Assets/assets/images/Products/"),
                     Product = product,
                     IsMain = i == 0 ? true : false
                 });
                i++;
            }

            foreach (var item in product.TagIds)
            {
                var resp = await _tagService.GetAsync(item);
                if (resp.Data==null)
                {
                    ModelState.AddModelError("", "agilli ol");
                    return View(product);
                }
                ProductTag productTag = new ProductTag
                {
                    TagId = item,
                    Product = product,
                    CreatedAt = DateTime.Now
                };
                 product.ProductTags.Add(productTag);
            }


            foreach (var item in product.ProductCreditIds)
            {
                var resp = await _creditService.GetAsync(item);
                if (resp.Data == null)
                {
                    ModelState.AddModelError("", "agilli ol");
                    return View(product);
                }
                ProductCredit credit = new ProductCredit
                {
                    CreditId = item,
                    Product = product,
                    CreatedAt = DateTime.Now
                };
                product.ProductCredits.Add(credit);
            }

            await _productService.CreateAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
