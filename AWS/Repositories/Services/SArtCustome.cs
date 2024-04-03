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
                        ArtworkCustomeId = "AC" + Guid.NewGuid().ToString().Substring(0, 5),
                        UserId = userid,
                        Status = false,
                        Time = DateTime.Now,    
                        Image = artcustome.image,
                        DeadlineDate = artcustome.DeadlineDate,
                        Description = artcustome.Description,
                    };

                    await cxt.ArtworkCustomes.AddAsync(artworkCustome); // Corrected to ArtworkCustomes
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

        public async Task<ArtworkCustome> GetCustomeArtworkById(string artid)
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
