using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SPremium:IPremium
    {
        private readonly ARTWORKPLATFORMContext cxt;
        public SPremium(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }
       

        public async Task<List<Premium>> GetAll()
        {
            try
            {
                var list = await this.cxt.Premium.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
    }
}
