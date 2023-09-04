using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Interfaces
{
    public interface ICreditService
    {
        public Task<MvcResponse<Credit>> CreateAsync(Credit credit);
        public Task<MvcResponse<Credit>> UpdateAsync(int id, Credit credit);
        public Task<MvcResponse<Credit>> GetAsync(int? id);
        public Task<MvcResponse<List<Credit>>> GetAllAsync();
        public Task<MvcResponse<Credit>> DeleteAsync(int id);
    }
}
