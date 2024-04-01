using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IArtCustome
    {
        Task<List<ArtworkCustome>> GetAllArtworkCustome();
     
    }
}
