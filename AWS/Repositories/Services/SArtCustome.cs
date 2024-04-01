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
    }
}
