using AWS.DTO.ArtworkDTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IArtwork
    {
        Task<List<Artwork>> GetAllArtworks();
        Task<Artwork> GetArtworkId(string id);
        Task<List<Artwork>> SearchByName(string name);
        Task<Artwork> CreateArtwork(CreateArtwork createArtwork);
        Task<List<Artwork>> GetByGenre(string genreId);

    }
}
