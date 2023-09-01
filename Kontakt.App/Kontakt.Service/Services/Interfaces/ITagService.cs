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
    public interface ITagService
    {
        public Task<MvcResponse<Tag>> CreateAsync(Tag tag);
        public Task<MvcResponse<Tag>> UpdateAsync(int id, Tag tag);
        public Task<MvcResponse<Tag>> GetAsync(int? id);
        public Task<MvcResponse<List<Tag>>> GetAllAsync();
        public Task<MvcResponse<Tag>> DeleteAsync(int id);
    }
}
