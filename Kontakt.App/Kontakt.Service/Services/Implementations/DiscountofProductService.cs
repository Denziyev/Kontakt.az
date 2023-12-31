﻿using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
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
    public class DiscountofProductService : IDiscountofProductService
    {
        private readonly IDiscountofProductRepository   _repository;

        public DiscountofProductService(IDiscountofProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<MvcResponse<DiscountofProduct>> CreateAsync(DiscountofProduct discountofproduct)
        {
            await _repository.AddAsync(discountofproduct);
            await _repository.SaveAsync();
            return new MvcResponse<DiscountofProduct> { IsSuccess = true, Message = $"DiscountofProduct(id:{discountofproduct.Id}) is created successfully", Data = discountofproduct };
        }

        public async Task<MvcResponse<DiscountofProduct>> DeleteAsync(int id)
        {
            DiscountofProduct? category = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return new MvcResponse<DiscountofProduct> { IsSuccess = false, Message = "Bu endirim növü mövcud deyil" };
            }

            category.IsDeleted = true;
            await _repository.Update(category);
            await _repository.SaveAsync();
            return new MvcResponse<DiscountofProduct> { IsSuccess = true, Message = $"{category.Percent} faizli endirim uğurla silindi",Data=category };
        }

        public async Task<MvcResponse<List<DiscountofProduct>>> GetAllAsync(int id)
        {
            IQueryable<DiscountofProduct> query = await _repository.GetAllAsync(x => !x.IsDeleted && x.DiscountCategoryId == id, "DiscountCategory", "Products");
            List<DiscountofProduct> discountofproducts = new List<DiscountofProduct>();
            discountofproducts = await query.Select(x => new DiscountofProduct { Id = x.Id, CreatedAt = x.CreatedAt, Percent = x.Percent, DiscountCategoryId = x.DiscountCategoryId, DiscountCategory = x.DiscountCategory, Products = x.Products }).ToListAsync();

            return new MvcResponse<List<DiscountofProduct>> { IsSuccess = true, Data = discountofproducts };
        }
        public async Task<MvcResponse<List<DiscountofProduct>>> GetAllWithoutIdAsync()
        {
            IQueryable<DiscountofProduct> query = await _repository.GetAllAsync(x => !x.IsDeleted , "DiscountCategory", "Products");
            List<DiscountofProduct> discountofproducts = new List<DiscountofProduct>();
            discountofproducts = await query.Select(x => new DiscountofProduct { Id = x.Id, CreatedAt = x.CreatedAt, Percent = x.Percent, DiscountCategoryId = x.DiscountCategoryId, DiscountCategory = x.DiscountCategory, Products = x.Products }).ToListAsync();

            return new MvcResponse<List<DiscountofProduct>> { IsSuccess = true, Data = discountofproducts };
        }

        public async Task<MvcResponse<DiscountofProduct>> GetAsync(int? id)
        {
            DiscountofProduct? discount = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "DiscountCategory", "Products");
            if (discount == null)
            {
                return new MvcResponse<DiscountofProduct> { IsSuccess = false, Message = "This DiscountofProduct doesnt exist" };
            }


            return new MvcResponse<DiscountofProduct> { IsSuccess = true, Data = discount };
        }

        public async Task<MvcResponse<DiscountofProduct>> UpdateAsync(int id, DiscountofProduct discountofproduct)
        {
            DiscountofProduct? discount = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "DiscountCategory", "Products");
            if (discount == null)
            {
                return new MvcResponse<DiscountofProduct> { IsSuccess = false, Message = "This DiscountofProduct doesnt exist" };
            }

            discount.Percent = discountofproduct.Percent;
            await _repository.Update(discount);
            await _repository.SaveAsync();
            return new MvcResponse<DiscountofProduct> { IsSuccess = true, Message = $"{discount.Percent} faizli endirim uğurla yeniləndi", Data = discount };

        }
    }
}
