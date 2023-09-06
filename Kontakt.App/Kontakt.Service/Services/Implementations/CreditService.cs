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
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;

        public CreditService(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public async Task<MvcResponse<Credit>> CreateAsync(Credit credit)
        {
            if (credit == null)
            {
                return new MvcResponse<Credit> { IsSuccess = false, Message = $"This percent was not found" };
            }
            if (await _creditRepository.isExist(x => x.Percent==credit.Percent))
            {
                return new MvcResponse<Credit> { IsSuccess = false, Message = $"{credit.Percent}% already exsist" };
            }


            await _creditRepository.AddAsync(credit);
            await _creditRepository.SaveAsync();
            return new MvcResponse<Credit> { IsSuccess = true, Message = $"{credit.Percent}% is created successfully", Data = credit };
        }

        public Task<MvcResponse<Credit>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MvcResponse<List<Credit>>> GetAllAsync()
        {
            IQueryable<Credit> query = await _creditRepository.GetAllAsync(x => !x.IsDeleted,"Credits");
            List<Credit> credits = new List<Credit>();
            credits = await query.Select(x => new Credit { Percent = x.Percent,Id=x.Id,InitialPayment=x.InitialPayment,NumberofMonths=x.NumberofMonths, Credits=x.Credits }).ToListAsync();

            return new MvcResponse<List<Credit>> { IsSuccess = true, Data = credits };
        }

        public async Task<MvcResponse<Credit>> GetAsync(int? id)
        {
            Credit? credit = await _creditRepository.GetByIdAsync(x => !x.IsDeleted && x.Id == id, "Credits");
            if (credit == null)
            {
                return new MvcResponse<Credit> { IsSuccess = false, Message = $"This percent was not found" };
            }


            return new MvcResponse<Credit> { IsSuccess = true, Data = credit };
        }

        public Task<MvcResponse<Credit>> UpdateAsync(int id, Credit credit)
        {
            throw new NotImplementedException();
        }
    }
}
