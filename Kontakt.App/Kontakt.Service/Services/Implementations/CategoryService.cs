using Azure;
using Kontakt.App.Models;
using Kontakt.Core.Repositories;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Interfaces;
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
  

        public CategoryService( ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<MvcResponse<Category>> CreateAsync(Category cateegory)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == cateegory.Name.Trim().ToLower()))
            {
                return new MvcResponse<Category> { IsSuccess=false, Message = $"{cateegory.Name} already exsist" };
            }

            
            await _repository.AddAsync(cateegory);
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess=true, Message = $"{cateegory.Name} is created successfully", Data = cateegory };
        }


        public async Task<MvcResponse<Category>> DeleteAsync(int id)
        {
            Category? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "This category doesnt exist" };
            }

            foreach (var item in category.Subcategories)
            {
                item.IsDeleted = true;
            }
            category.IsDeleted = true;
            await _repository.Update(category);
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess = true, Message = $"{category.Name} is deleted successfully" };
        }

        public async Task<MvcResponse<List<Category>>> GetAllAsync()
        {
            IQueryable<Category> query = await _repository.GetAllAsync(x => !x.IsDeleted, "Subcategories");
            List<Category> categories = new List<Category>();
            categories = await query.Select(x => new Category { Name = x.Name, Id = x.Id, CreatedAt=x.CreatedAt, ParentCategoryId=x.ParentCategoryId,ParentCategory=x.ParentCategory, Subcategories=x.Subcategories,Products=x.Products}).ToListAsync();

            return new MvcResponse<List<Category>> { IsSuccess=true, Data = categories };
        }

        public async Task<MvcResponse<Category>> GetAsync(int? id)
        {
            Category? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "Subcategories");
            if (category == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "This category doesnt exist" };
            }
       

            return new MvcResponse<Category> { IsSuccess = true, Data = category };
        }



        public async Task<MvcResponse<Category>> UpdateAsync(int id, Category category)
        {

            if (await _repository.isExist(x => x.Name.Trim().ToLower() == category.Name.Trim().ToLower() && x.Id == id))
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = $"{category.Name} already exsist" };
            }
            Category? updatecategory = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (updatecategory == null)
            {
                return new MvcResponse<Category> { IsSuccess = false, Message = "This category doesnt exist" };
            }
            updatecategory.Name = category.Name;
            updatecategory.ParentCategoryId = category.ParentCategoryId;
            updatecategory.ParentCategoryId = category.ParentCategoryId;
            updatecategory.UpdatedAt = DateTime.Now;
            await _repository.SaveAsync();
            return new MvcResponse<Category> { IsSuccess = true, Data = updatecategory };
        }


    }
}
