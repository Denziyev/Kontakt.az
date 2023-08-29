using Kontakt.Core.Models;

namespace Kontakt.App.Models
{
    public class Category:BaseModel
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? Subcategories { get; set; }
        public List<Product>? Products { get; set; }
        public List<DiscountCategory> DiscountCategory { get; set; }
    }
}
