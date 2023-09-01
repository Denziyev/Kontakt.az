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
    public interface IDiscountService
    {
        public Task<MvcResponse<Discount>> CreateAsync(Discount discount);
        public Task<MvcResponse<Discount>> UpdateAsync(int id, Discount discount);
        public Task<MvcResponse<Discount>> GetAsync(int? id);
        public Task<MvcResponse<List<Discount>>> GetAllAsync();
        public Task<MvcResponse<Discount>> DeleteAsync(int id);
    }
}
