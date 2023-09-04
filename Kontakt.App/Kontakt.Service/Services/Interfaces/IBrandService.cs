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
        public Task<MvcResponse<Brand>> CreateAsync(Brand brand);
        public Task<MvcResponse<Brand>> UpdateAsync(int id, Brand brand);
        public Task<MvcResponse<Brand>> GetAsync(int? id);
        public Task<MvcResponse<List<Brand>>> GetAllAsync();
        public Task<MvcResponse<Brand>> DeleteAsync(int id);
    }
}
