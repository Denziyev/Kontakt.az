using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface IBrandService
    {
        public Task<MvcResponse<Brand>> CreateAsync(Category category);
        public Task<MvcResponse<Brand>> UpdateAsync(int id, Category category);
        public Task<MvcResponse<Category>> GetAsync(int? id);
        public Task<MvcResponse<List<Category>>> GetAllAsync();
        public Task<MvcResponse<Category>> DeleteAsync(int id);
    }
}
