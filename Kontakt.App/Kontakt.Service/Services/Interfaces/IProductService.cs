using Kontakt.App.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<MvcResponse<Product>> CreateAsync(Product product);
        public Task<MvcResponse<Product>> UpdateAsync(int id, Product product);
        public Task<MvcResponse<Product>> GetAsync(int? id);
        public Task<MvcResponse<List<Product>>> GetAllAsync();
        public Task<MvcResponse<Product>> DeleteAsync(int id);
    }
}
