using AWS.DTO.Order;
using AWS.Models;
using AWS.Repositories.Services;

namespace AWS.Repositories.Interfaces
{
    public interface IOrder
    {
        Task<Ordertb> GetOrderById(string id);
        Task<List<Ordertb>> GetAll();
        Task<Ordertb> CreateNewOrder(CreateOrderDTO order);
    }
}
