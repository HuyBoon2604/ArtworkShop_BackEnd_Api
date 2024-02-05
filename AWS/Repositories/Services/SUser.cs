using AWS.Models;
using AWS.Repositories.Interfaces;
using backend_not_clear.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace ArtWorkShop.Repositories.Services
{
    public class SUser : IUser
    {
        private readonly ARTWORKPLATFORMContext context;

        public SUser(ARTWORKPLATFORMContext Context)
        {
            context = Context;
        }

        public Task<Usertb> DeleteBird(string BirdId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usertb>> GetAllUsers()
        {

           var y = await this.context.Usertbs.ToListAsync();    
            return y;   
        }

        public Task<Usertb> getBirdByID(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usertb> Login(LoginDTO request)
        {
            try
            {
                var user = await this.context.Usertbs.Where(x => x.Username.Equals(request.UserName))
                                                   .Include(y => y.Roles)
                                                   .FirstOrDefaultAsync();
                if (user == null)
                    throw new Exception("USER IS NOT FOUND");
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                    throw new Exception("INVALID PASSWORD");
                //if (!user.Status)
                //    throw new Exception("ACCOUNT WAS BANNED OR DELETED");
                //var token = CreateToken(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async  Task<Usertb> Registration(RegisterDTO request)
        {
            try
            {
                var r = new Usertb();
                if (request != null)
                {
                    foreach (var x in this.context.Usertbs)
                    {
                        if (request.Username.Equals(x.Username))
                        {
                            throw new Exception("Duplicate UserName");
                        }
                    }
                    r.UserId = "US" + Guid.NewGuid().ToString().Substring(0, 7);
                    r.Username = request.Username;
                    r.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    //r.Email = request.Email;
                    r.RoleId = "2";
                    //r.Status = true;
                    await this.context.Usertbs.AddAsync(r);
                    await this.context.SaveChangesAsync();
                    return r;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<List<Usertb>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
