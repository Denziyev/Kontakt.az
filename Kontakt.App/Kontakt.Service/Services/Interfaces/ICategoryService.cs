using Kontakt.App.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<MvcResponse<Category>> CreateAsync(Category category);
        public Task<MvcResponse<Category>> UpdateAsync(int id, Category category);
        public Task<MvcResponse<Category>> GetAsync(int? id);
        public Task<MvcResponse<List<Category>>> GetAllAsync();
        public Task<MvcResponse<Category>> DeleteAsync(int id);
    }
}
