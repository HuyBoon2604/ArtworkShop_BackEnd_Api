using AWS.Models;
using ArtWorkShop.Repositories.Services;
using backend_not_clear.DTO.UserDTO;
using AWS.DTO;


namespace AWS.Repositories.Interfaces
{
    public interface IPremium
    {
        
        Task<List<Premium>> GetAll();
        
    }
}
