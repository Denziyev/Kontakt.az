using Kontakt.App.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class Discount:BaseModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public List<DiscountCategory>? DiscountCategories { get; set; }

    }

    public class DiscountCategory : BaseModel
    {
        public List<DiscountImage>? Images { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public List<DiscountofProduct>? DiscountofProducts { get; set; }

        public Discount? Discount { get; set; }
        public int DiscountId { get; set; }

        [NotMapped]
        public List<IFormFile>? FormFiles { get; set; }
    }

    public class DiscountofProduct : BaseModel
    {
        public List<Product>? Products { get; set; }
        public double Percent { get; set; }

        public DiscountCategory DiscountCategory { get; set; }
        public int DiscountCategoryId { get; set; }
    }
}
