using Azure;
using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Responses;
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

            if((await _discountofProductService.GetAllAsync(discountofProduct.DiscountCategoryId)).Data.Where(x => x.Percent == discountofProduct.Percent).ToList().Count != 0)
            {
                TempData["discountofproduct_contoller_response"] = "Eyni dəyərə malik endirim artıq mövcuddur";
                return View(discountofProduct);
            }
         

            if (!ModelState.IsValid)
                return View(discountofProduct);

            discountofProduct.CreatedAt = DateTime.Now;
            MvcResponse<DiscountofProduct> response = await _discountofProductService.CreateAsync(discountofProduct);
            TempData["discountofproduct_contoller_response_create"] = response.Message;
            return RedirectToAction(nameof(Index), discountofProduct.DiscountCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Tempp = TempData["TempIdCate"];
            MvcResponse<DiscountofProduct> resp = await _discountofProductService.GetAsync(id);
            DiscountofProduct? discountofProduct = resp.Data;
            if (discountofProduct == null)
            {
                return NotFound();
            }
            return View(discountofProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DiscountofProduct postdiscount,int id)
        {


            if (!ModelState.IsValid)
            {
                return View(postdiscount);
            }
      

            MvcResponse<DiscountofProduct> response = await _discountofProductService.UpdateAsync(id, postdiscount);
            TempData["discountofproduct_contoller_response_update"] = response.Message;
            return RedirectToAction(nameof(Index),(await _categoryService.GetAsync(postdiscount.DiscountCategoryId)).Data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            MvcResponse<DiscountofProduct> resp = await _discountofProductService.GetAsync(id);
            DiscountofProduct? product = resp.Data;

            if (product == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            MvcResponse<DiscountofProduct> response = await _discountofProductService.DeleteAsync(id);
            TempData["discountofproduct_contoller_response_delete"] = response.Message;
            return RedirectToAction("Index", "DiscountofProduct",response.Data.DiscountCategory);
        }
    }
}
