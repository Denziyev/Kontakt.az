

using Kontakt.Core.Models;
using Kontakt.Service.ViewModels;

namespace Kontakt.Service.Services.Interfaces
{
    public interface IBasketService
    {
        public Task AddBasket(int id,int?count);
        public Task<List<BasketItemViewModel>> GetAllBaskets();
        public Task Remove(int id);
        public Task Increase(int id);
        public Task Decrease(int id);
    }
}
