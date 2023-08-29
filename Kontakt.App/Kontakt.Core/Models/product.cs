using Kontakt.Core.Models;

namespace Kontakt.App.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public int StockNumber { get; set; }
        public string Image { get; set; }
    }
}
