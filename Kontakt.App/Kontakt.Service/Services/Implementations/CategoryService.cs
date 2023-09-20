using Azure;
using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
using Kontakt.Service.Extentions;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IWebHostEnvironment _env;


        public CategoryService(ICategoryRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }
        public async Task<MvcResponse<Category>> CreateAsync(Category cateegory)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == cateegory.Name.Trim().ToLower() && !x.IsDeleted))
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = $"{cateegory.Name} artıq mövcuddur" };
            }


            await _repository.AddAsync(cateegory);
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess=true, Message = $"{cateegory.Name} uğurla əlavə olundu", Data = cateegory };
        }


        public async Task<MvcResponse<Category>> DeleteAsync(int id)
        {
            Category? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "Bu kateqoriya mövcud deyil" };
            }

            foreach (var item in category.Subcategories)
            {
                item.IsDeleted = true;
            }
            category.IsDeleted = true;
            await _repository.Update(category);
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess = true, Message = $"{category.Name} uğurla silindi" };
        }

        public async Task<MvcResponse<List<Category>>> GetAllAsync()
        {
            IQueryable<Category> query = await _repository.GetAllAsync(x => !x.IsDeleted, "Subcategories");
            List<Category> categories = new List<Category>();
            categories = await query.Select(x => new Category { Name = x.Name,Image=x.Image, Id = x.Id, CreatedAt=x.CreatedAt, ParentCategoryId=x.ParentCategoryId,ParentCategory=x.ParentCategory, Subcategories=x.Subcategories,Products=x.Products,CategoryBrands=x.CategoryBrands}).ToListAsync();

            return new MvcResponse<List<Category>> { IsSuccess=true, Data = categories };
        }

        public async Task<MvcResponse<Category>> GetAsync(int? id)
        {
            Category? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id , "Subcategories");
            if (category == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "Bu kateqoriya mövcud deyil" };
            }
       

            return new MvcResponse<Category> { IsSuccess = true, Data = category };
        }



        public async Task<MvcResponse<Category>> UpdateAsync(int id, Category category)
        {

            if (await _repository.isExist(x => x.Name.Trim().ToLower() == category.Name.Trim().ToLower() && x.Id != id && !x.IsDeleted))
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = $"{category.Name} artıq mövcuddur" };
            }
            Category? updatecategory = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (updatecategory == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "Bu kateqoriya mövcud deyil" };
            }

            updatecategory.Name = category.Name;
            updatecategory.ParentCategoryId = category.ParentCategoryId;
            updatecategory.ParentCategoryId = category.ParentCategoryId;
            updatecategory.Image= category.formFile.CreateImage(_env.WebRootPath, "Assets/assets/images/Categories/");
            updatecategory.UpdatedAt = DateTime.Now;
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess = true, Data = updatecategory };
        }


    }
}
