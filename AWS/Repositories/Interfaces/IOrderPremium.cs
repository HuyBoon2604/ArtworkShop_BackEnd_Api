using AWS.DTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IOrderPremium
    {
        Task<List<OrderPremium>> GetAll();
        Task<OrderPremium> GetByID(string id); 
        Task<OrderPremium> AddNewOrder(CreateOrderPremiumDTO create); 

        
    }
}
