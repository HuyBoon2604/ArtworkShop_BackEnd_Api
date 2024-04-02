using AWS.DTO;
using AWS.DTO.ArtworkDTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SArtCustome : IArtCustome
    {

        private readonly ARTWORKPLATFORMContext cxt;
        public SArtCustome(ARTWORKPLATFORMContext Cxt)
        {
            cxt = Cxt;
        }

        public async Task<ArtworkCustome> CreateNewCustome(string userid, ArtCustomeDTO artcustome)
        {
            try
            {

                var user = await cxt.Usertbs.FindAsync(userid);
                if (user != null && (user.StatusPost == true || user.PremiumId != null))
                {
                    var artworkCustome = new ArtworkCustome
                    {
                        ArtworkCustomeId = int.MaxValue,
                        UserId = userid,
                        Status = artcustome.Status,
                        DeadlineDate = artcustome.DeadlineDate,
                        Description = artcustome.Description,
                    };

                    // Add Genres to the artwork if provided
                    if (artcustome.Genres != null && artcustome.Genres.Any())
                    {
                        foreach (var genreDto in artcustome.Genres)
                        {
                            var genre = await cxt.Genres.FindAsync(genreDto.GenreID);
                            if (genre != null)
                            {
                                artworkCustome.Genre = genre;
                            }
                            else
                            {
                                // Handle error if Genre doesn't exist
                                throw new Exception($"Genre with ID {genreDto.GenreID} not found.");
                            }
                        }
                    }

                    cxt.ArtworkCustomes.Add(artworkCustome); // Corrected to ArtworkCustomes
                    await cxt.SaveChangesAsync();

                    return artworkCustome;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<ArtworkCustome>> GetAllArtworkCustome()
        {
            try
            {
                var y = await this.cxt.ArtworkCustomes.ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ArtworkCustome> GetCustomeArtworkById(int artid)
        {
            try
            {
                var y = await this.cxt.ArtworkCustomes.Where(x => x.ArtworkCustomeId == artid).FirstOrDefaultAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
