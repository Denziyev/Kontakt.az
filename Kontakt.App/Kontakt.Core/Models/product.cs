using Kontakt.Core.Models;

namespace Kontakt.App.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
