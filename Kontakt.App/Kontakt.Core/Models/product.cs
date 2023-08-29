using Kontakt.Core.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kontakt.App.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsExist { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public Dictionary<string,string> MainProperties { get; set; }
        public Dictionary<string, string> OtherProperties { get; set; }
        public int StockNumber { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public DiscountofProduct? Discount { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public List<IFormFile>? FormFiles { get; set; }
    }
}
