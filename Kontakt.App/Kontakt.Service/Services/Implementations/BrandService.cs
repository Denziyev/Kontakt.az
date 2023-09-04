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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<MvcResponse<Brand>> CreateAsync(Brand brand)
        {
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == brand.Name.Trim().ToLower()))
            {
                return new MvcResponse<Brand> { IsSuccess = false, Message = $"{brand.Name} already exsist" };
            }


            await _repository.AddAsync(brand);
            await _repository.SaveAsync();
            return new MvcResponse<Brand> { IsSuccess = true, Message = $"{brand.Name} is created successfully", Data = brand };
        }

        public Task<MvcResponse<Brand>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvcResponse<List<Brand>>> GetAllAsync()
        {
            IQueryable<Brand> query = await _repository.GetAllAsync(x => !x.IsDeleted, "Products");
            List<Brand> brands = new List<Brand>();
            brands = await query.Select(x => new Brand { Name = x.Name, Id = x.Id, CreatedAt = x.CreatedAt, Image=x.Image,formFile=x.formFile}).ToListAsync();

            return new MvcResponse<List<Brand>> { IsSuccess = true, Data = brands };
        }

        public async Task<MvcResponse<Brand>> GetAsync(int? id)
        {
            Brand? brand = await _repository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "Products");
            if (brand == null)
            {
                return new MvcResponse<Brand> { IsSuccess = false, Message = "This brand doesnt exist" };
            }


            return new MvcResponse<Brand> { IsSuccess = true, Data = brand };
        }

        public Task<MvcResponse<Brand>> UpdateAsync(int id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
