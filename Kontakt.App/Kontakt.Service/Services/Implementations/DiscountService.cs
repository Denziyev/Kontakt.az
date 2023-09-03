using Kontakt.App.Models;
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
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task<MvcResponse<Discount>> CreateAsync(Discount discount)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == discount.Name.Trim().ToLower()))
            {
                return new MvcResponse<Discount> { IsSuccess = false, Message = $"{discount.Name} already exsist" };
            }

            if(discount.EndDate <= discount.StartDate)
            {
                return new MvcResponse<Discount> { IsSuccess = false, Message = $"Start or End Date is wrong" };
            }


            await _repository.AddAsync(discount);
            await _repository.SaveAsync();
            return new MvcResponse<Discount> { IsSuccess = true, Message = $"{discount.Name} is created successfully", Data = discount };
        }

        public Task<MvcResponse<Discount>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvcResponse<List<Discount>>> GetAllAsync()
        {
            IQueryable<Discount> query = await _repository.GetAllAsync(x => !x.IsDeleted,"DiscountCategories");
            List<Discount> discounts = new List<Discount>();
            discounts = await query.Select(x => new Discount { Name = x.Name, Id = x.Id, CreatedAt = x.CreatedAt, StartDate=x.StartDate,EndDate=x.EndDate}).ToListAsync();

            return new MvcResponse<List<Discount>> { IsSuccess = true, Data = discounts };
        }

        public async Task<MvcResponse<Discount>> GetAsync(int? id)
        {
            Discount? discount = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id,"DiscountCategories");
            if (discount == null)
            {
                return new MvcResponse<Discount> { IsSuccess = false, Message = "This Discount doesnt exist" };
            }


            return new MvcResponse<Discount> { IsSuccess = true, Data = discount };
        }

        public Task<MvcResponse<Discount>> UpdateAsync(int id, Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}
