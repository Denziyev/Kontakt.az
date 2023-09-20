using Kontakt.App.Context;
using Kontakt.App.Models;
using Kontakt.App.ViewModels;
using Kontakt.Core.Models;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly KontaktDbContext _kontaktDbContext;
        private readonly IBasketService _basketService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICommentService commentService, IBasketService basketService, KontaktDbContext kontaktDbContext, ICategoryService categoryService)
        {
            _productService = productService;
            _commentService = commentService;
            _basketService = basketService;
            _kontaktDbContext = kontaktDbContext;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = (await _productService.GetAllAsync()).Data,
                Category = (await _categoryService.GetAsync(id)).Data,
            };
            return View(productViewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if((await _productService.GetAsync(id)).Data == null)
            {
                return NotFound();
            }
            ProductViewModel productVm = new ProductViewModel
            {
                Product = (await _productService.GetAsync(id)).Data,
                Products = (await _productService.GetAllAsync()).Data,

            };

            return View(productVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int? count)
        {
            await _basketService.AddBasket(id, count);
            TempData["AddBasket"] = "Məhsul səbətə əlavə edildi";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            return Json(await _basketService.GetAllBaskets());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBasket(int id)
        {
            await _basketService.Remove(id);
            TempData["RemoveBasket"] = "Məhsul səbətdən uğurla silindi";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Increase(int id)
        {
            await _basketService.Increase(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            await _basketService.Decrease(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Search(string search, int? take)
        {
   
            int TotalCount =  _kontaktDbContext.Products.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Category.Name.Trim().ToLower().Contains(search.Trim().ToLower()))).Count();


            List<Product> products = await _kontaktDbContext.Products.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Category.Name.Trim().ToLower().Contains(search.Trim().ToLower())))
             .Include(x => x.ProductImages).Where(x => !x.IsDeleted)
               .Include(x => x.Category).Where(x => !x.IsDeleted)
               .Include(x => x.DiscountofProduct).Where(x => !x.IsDeleted).Take((int)take)
             .ToListAsync();
     
         
            return Json(products);
        }

        public async Task<IActionResult> SearchbyTag(string search,int? take)
        {
    
         
            int TotalCount = _kontaktDbContext.Tags.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower()))).Count();


            List<Tag> tags = await _kontaktDbContext.Tags.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower())))
                .Include(x => x.ProductTags)
                .ThenInclude(x=>x.Product).Where(x => !x.IsDeleted).Take((int)take)
                .ToListAsync();
      
      
            
            return Json(tags);
        }

        public async Task<IActionResult> SearchbyCategory(string search, int? take)
        {
   

            int TotalCount = _kontaktDbContext.Tags.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower()))).Count();

            List<Category> categories = await _kontaktDbContext.Categories.Where(x => !x.IsDeleted && (x.Name.Trim().ToLower().Contains(search.Trim().ToLower())))
                .Include(x => x.Subcategories).Where(x => !x.IsDeleted)
                .Include(x => x.ParentCategory).Where(x => !x.IsDeleted).Take((int)take)
            .ToListAsync();

            return Json(categories);
        }


    }
}
