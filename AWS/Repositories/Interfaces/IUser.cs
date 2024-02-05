using AWS.Models;
using ArtWorkShop.Repositories.Services;
using backend_not_clear.DTO.UserDTO;

namespace AWS.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<Usertb>> GetAllUsers();
        Task<Usertb> Registration(RegisterDTO request);
        Task<Usertb> Login(LoginDTO request);
        Task<List<Usertb>> SearchByName(string name);
        //Task<Usertb> CreateBird(CreateBird bird);
        //Task<Usertb> UpdateBird(UpdateBird bird);

        Task<Usertb> DeleteBird(string BirdId);
        Task<Usertb> getBirdByID(string id);
    }
}
