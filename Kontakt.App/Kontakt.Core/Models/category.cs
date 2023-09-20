using Kontakt.Core.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kontakt.App.Models
{
    public class Category:BaseModel
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? Image { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? Subcategories { get; set; }
        public List<Product>? Products { get; set; }
        public List<DiscountCategory>? DiscountCategory { get; set; }

        public List<CategoryBrand>? CategoryBrands { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
    }
}
