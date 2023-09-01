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
    public class Brand:BaseModel
    {
        public string Name { get; set; }    
        public string Image { get; set; } 
        public List<Product> Products { get; set; } 
        [NotMapped] 
        public IFormFile formFile { get; set; } 
    }
}
