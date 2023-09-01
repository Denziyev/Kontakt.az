using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
using Kontakt.Data.Repositories;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<MvcResponse<Tag>> CreateAsync(Tag tag)
        {
            tag.CreatedAt = DateTime.Now;
            await _tagRepository.AddAsync(tag);
            await _tagRepository.SaveAsync();
            return new MvcResponse<Tag> { IsSuccess = true, Message = $"{tag.Name} is created successfully", Data = tag };
        }

        public Task<MvcResponse<Tag>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvcResponse<List<Tag>>> GetAllAsync()
        {
            IQueryable<Tag> query = await _tagRepository.GetAllAsync(x => !x.IsDeleted);
            List<Tag> tags = new List<Tag>();
            tags = await query.Select(x => new Tag { Name = x.Name, Id = x.Id, CreatedAt = x.CreatedAt }).ToListAsync();

            return new MvcResponse<List<Tag>> { IsSuccess = true, Data = tags };
        }

        public async Task<MvcResponse<Tag>> GetAsync(int? id)
        {
            Tag? tag = await _tagRepository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (tag == null)
            {
                return new MvcResponse<Tag> { IsSuccess = false, Message = "This tag doesnt exist" };
            }


            return new MvcResponse<Tag> { IsSuccess = true, Data = tag };
        }

        public Task<MvcResponse<Tag>> UpdateAsync(int id, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
