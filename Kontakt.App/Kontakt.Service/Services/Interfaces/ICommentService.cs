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
    public interface ICommentService
    {
        public Task<MvcResponse<Comment>> CreateAsync(Comment comment);
        public Task<MvcResponse<Comment>> VisibleAsync(int id);
        public Task<MvcResponse<Comment>> GetAsync(int? id);
        public Task<MvcResponse<List<Comment>>> GetAllAsync();
        public Task<MvcResponse<Comment>> DeleteAsync(int id);
    }
}
