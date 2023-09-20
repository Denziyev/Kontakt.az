using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface IDiscountCategoryService
    {
        public Task<MvcResponse<DiscountCategory>> CreateAsync(DiscountCategory discountCategory);
        public Task<MvcResponse<DiscountCategory>> UpdateAsync(int id, DiscountCategory discountCategory);
        public Task<MvcResponse<DiscountCategory>> GetAsync(int? id);
        public Task<MvcResponse<List<DiscountCategory>>> GetAllAsync(int id);
        public Task<MvcResponse<List<DiscountCategory>>> GetAllAsync();

        public Task<MvcResponse<DiscountCategory>> DeleteAsync(int id);
    }
}
