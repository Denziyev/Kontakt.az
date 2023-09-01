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
        public int SellCount { get; set; }
        public double BuyPrice { get; set; }
        public double DiscountinCash { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Category? Category { get; set; }
        public Dictionary<string,string> MainProperties { get; set; }
        public Dictionary<string, string> OtherProperties { get; set; }
        public int StockNumber { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public DiscountofProduct? Discount { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        public List<ProductCredit>? ProductCredits { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public   List<int> CreditIds { get; set; }
        [NotMapped]
        public List<IFormFile>? FormFiles { get; set; }
    }
}
