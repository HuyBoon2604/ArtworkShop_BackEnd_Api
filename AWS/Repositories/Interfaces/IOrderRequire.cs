using AWS.DTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IOrderRequire
    {
        Task<List<OrderRequire>> GetAllOrderRequire();
        Task<OrderRequire> GetOrderRequireById(string id);
        Task<OrderRequire> GetOrderRequireByArtCustomeId(string id);
        Task<OrderRequire> CreateNewOrderRequire(NewOrderRequireDTO order);
        Task<bool> UpdateStatusOrderRequire(string OrderRequireId);

    }
}
