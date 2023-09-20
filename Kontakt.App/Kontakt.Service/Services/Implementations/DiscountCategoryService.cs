using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
using Kontakt.Service.Extentions;
using Kontakt.Service.Helpers;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Implementations
{
    public class DiscountCategoryService : IDiscountCategoryService
    {
        private readonly IDiscountCategoryRepository _repository;
        private readonly IWebHostEnvironment _env;

        public DiscountCategoryService(IDiscountCategoryRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task<MvcResponse<DiscountCategory>> CreateAsync(DiscountCategory discountCategory)
        {
            await _repository.AddAsync(discountCategory);
            await _repository.SaveAsync();
            return new MvcResponse<DiscountCategory> { IsSuccess = true, Message = $"DiscountCategory(id:{discountCategory.Id}) is created successfully", Data = discountCategory };
        }

        public async Task<MvcResponse<DiscountCategory>> DeleteAsync(int id)
        {
                DiscountCategory? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return new MvcResponse<DiscountCategory> { IsSuccess = false, Message = "Bu kateqoriya mövcud deyil" };
            }

            category.IsDeleted = true;
            await _repository.Update(category);
            await _repository.SaveAsync();
            return new MvcResponse<DiscountCategory> { IsSuccess = true, Message = $"{category.Category.Name} kateqoriyalı endirim uğurla silindi" };
        }

        public async Task<MvcResponse<List<DiscountCategory>>> GetAllAsync(int id)
        {
            IQueryable<DiscountCategory> query = await _repository.GetAllAsync(x => !x.IsDeleted && x.DiscountId==id, "Discount", "Category", "DiscountofProducts","Images");
            List<DiscountCategory> discountCategories = new List<DiscountCategory>();
            discountCategories = await query.Select(x => new DiscountCategory { Id = x.Id, CreatedAt = x.CreatedAt, DiscountId=x.DiscountId,CategoryId=x.CategoryId,Images=x.Images,Category=x.Category,Discount=x.Discount}).ToListAsync();

            return new MvcResponse<List<DiscountCategory>> { IsSuccess = true, Data = discountCategories };
        }

        public async Task<MvcResponse<List<DiscountCategory>>> GetAllAsync()
        { 
            IQueryable<DiscountCategory> query = await _repository.GetAllAsync(x => !x.IsDeleted, "Discount", "Category", "DiscountofProducts", "Images");
            List<DiscountCategory> discountCategories = new List<DiscountCategory>();
            discountCategories = await query.Select(x => new DiscountCategory { Id = x.Id, CreatedAt = x.CreatedAt, DiscountId = x.DiscountId, CategoryId = x.CategoryId, Images = x.Images, Category = x.Category, Discount = x.Discount }).ToListAsync();
          
            return new MvcResponse<List<DiscountCategory>> { IsSuccess = true, Data = discountCategories };
        }



        public async Task<MvcResponse<DiscountCategory>> GetAsync(int? id)
        {
            DiscountCategory? discount = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "Discount", "Category", "DiscountofProducts", "Images");
            if (discount == null)
            {
                return new MvcResponse<DiscountCategory> { IsSuccess = false, Message = "This DiscountCategory doesnt exist" };
            }


            return new MvcResponse<DiscountCategory> { IsSuccess = true, Data = discount };
        }

        public Task<MvcResponse<DiscountCategory>> UpdateAsync(int id, DiscountCategory discountCategory)
        {
            throw new NotImplementedException();
        }
    }
}
