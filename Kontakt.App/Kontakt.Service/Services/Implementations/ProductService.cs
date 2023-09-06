using Kontakt.App.Models;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<MvcResponse<Product>> CreateAsync(Product product)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == product.Name.Trim().ToLower()))
            {
                return new MvcResponse<Product> { IsSuccess = false, Message = $"{product.Name} already exsist" };
            }



            await _repository.AddAsync(product);
            await _repository.SaveAsync();
            return new MvcResponse<Product> { IsSuccess = true, Message = $"{product.Name} is created successfully", Data = product };
        }

        public Task<MvcResponse<Product>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvcResponse<List<Product>>> GetAllAsync()
        {
            IQueryable<Product> query = await _repository.GetAllAsync(x => !x.IsDeleted, "ProductTags", "ProductImages", "MainProperties", "OtherProperties", "Category","Brand","Comments","DiscountofProduct","ProductCredits");
            List<Product> products = new List<Product>();
            products = await query.Select(x => new Product { Name = x.Name, Id = x.Id, CreatedAt = x.CreatedAt, CategoryId = x.CategoryId,Category=x.Category,ProductCreditIds=x.ProductCreditIds,ProductCredits=x.ProductCredits, BrandId = x.BrandId,Brand=x.Brand,Comments=x.Comments,DiscountofProductId=x.DiscountofProductId,DiscountofProduct=x.DiscountofProduct,ProductImages=x.ProductImages }).ToListAsync();

            return new MvcResponse<List<Product>> { IsSuccess = true, Data = products };
        }

        public async Task<MvcResponse<Product>> GetAsync(int? id)
        {
            Product? product = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "ProductTags", "ProductImages", "MainProperties", "OtherProperties", "Category", "Brand", "Comments", "DiscountofProduct", "ProductCredits");
            if (product == null)
            {
                return new MvcResponse<Product> { IsSuccess = false, Message = "This product doesnt exist" };
            }


            return new MvcResponse<Product> { IsSuccess = true, Data = product };
        }

        public Task<MvcResponse<Product>> UpdateAsync(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
