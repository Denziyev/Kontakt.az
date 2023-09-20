using Kontakt.App.Models;

namespace Kontakt.App.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}
