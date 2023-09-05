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
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<MvcResponse<Comment>> CreateAsync(Comment comment)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == comment.Name.Trim().ToLower()))
            {
                return new MvcResponse<Comment> { IsSuccess = false, Message = $"{comment.Name} already exsist" };
            }


            await _repository.AddAsync(comment);
            await _repository.SaveAsync();
            return new MvcResponse<Comment> { IsSuccess = true, Message = $"{comment.Name} is created successfully", Data = comment };
        }

        public async Task<MvcResponse<Comment>> DeleteAsync(int id)
        {
            Comment? comment = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (comment == null)
            {
                return new MvcResponse<Comment> { IsSuccess = false, Message = "This category doesnt exist" };
            }

            comment.IsDeleted = true;
            await _repository.Update(comment);
            await _repository.SaveAsync();
            return new MvcResponse<Comment> { IsSuccess = true, Message = $"{comment.Name} is deleted successfully" };
        }

        public async Task<MvcResponse<List<Comment>>> GetAllAsync()
        {
            IQueryable<Comment> query = await _repository.GetAllAsync(x => !x.IsDeleted,"Product");
            List<Comment> comments = new List<Comment>();
            comments = await query.Select(x => new Comment {Id=x.Id,Name=x.Name,Email=x.Email,About=x.About,RatingLevel=x.RatingLevel,ProductId=x.ProductId,product=x.product}).ToListAsync();

            return new MvcResponse<List<Comment>> { IsSuccess = true, Data = comments };
        }

        public async Task<MvcResponse<Comment>> GetAsync(int? id)
        {
            Comment? comment = await _repository .GetByIdAsync(x => !x.IsDeleted && x.Id == id,"Product");
            if (comment == null)
            {
                return new MvcResponse<Comment> { IsSuccess = false, Message = $"This comment was not found" };
            }


            return new MvcResponse<Comment> { IsSuccess = true, Data = comment };
        }

        public async Task<MvcResponse<Comment>> VisibleAsync(int id)
        {
            Comment? comment = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (comment == null)
            {
                return new MvcResponse<Comment> { IsSuccess = false, Message = "This category doesnt exist" };
            }

            comment.IsVisible = true;
            await _repository.Update(comment);
            await _repository.SaveAsync();
            return new MvcResponse<Comment> { IsSuccess = true, Message = $"{comment.Name} is deleted successfully" };
        }
    }
}
