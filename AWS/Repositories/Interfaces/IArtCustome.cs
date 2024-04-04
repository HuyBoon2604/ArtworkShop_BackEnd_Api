using AWS.DTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IArtCustome
    {
        Task<List<ArtworkCustome>> GetAllArtworkCustome();
        Task<ArtworkCustome> CreateNewCustome(string userid, ArtCustomeDTO artcustome);
        Task<bool> UpdateStaus(string artid);
        Task<bool> Delete(string artid);
        Task<ArtworkCustome> GetCustomeArtworkById(string artid);
     
    }
}
