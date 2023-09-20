using Kontakt.App.Models;
using Kontakt.App.ViewModels;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        private readonly IProductService _productservice;
        public CategoryController(ICategoryService categoryservice, IProductService productservice)
        {
            _categoryservice = categoryservice;
            _productservice = productservice;
        }

        public async Task<IActionResult> Index(int id)
        {
            List<Category> categories = (await _categoryservice.GetAllAsync()).Data.Where(x => x.ParentCategoryId == id).ToList();

            if (categories.Count != 0)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel
                {
                    Categories = categories,
                    Products = (await _productservice.GetAllAsync()).Data,
                    Category = (await _categoryservice.GetAsync(id)).Data,
                };
                return View(categoryViewModel);
            }
            else
            {

                return RedirectToAction("index", "Product", new {Id=id});
            }
 

        }
    }
}
