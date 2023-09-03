using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface IDiscountofProductService
    {
        public Task<MvcResponse<DiscountofProduct>> CreateAsync(DiscountofProduct discountofproduct);
        public Task<MvcResponse<DiscountofProduct>> UpdateAsync(int id, DiscountofProduct discountofproduct);
        public Task<MvcResponse<DiscountofProduct>> GetAsync(int? id);
        public Task<MvcResponse<List<DiscountofProduct>>> GetAllAsync(int id);
        public Task<MvcResponse<DiscountofProduct>> DeleteAsync(int id);
    }
}
