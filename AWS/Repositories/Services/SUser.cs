using AWS.Models;
using AWS.Repositories.Interfaces;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.DTO.UserDTO.SearchUserID;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtWorkShop.Repositories.Services
{
    public class SUser : IUser
    {
        private readonly IConfiguration _configuration;

        private readonly ARTWORKPLATFORMContext context;

        public SUser(ARTWORKPLATFORMContext Context, IConfiguration configuration)
        {
            context = Context;
            _configuration = configuration;
        }

       

        public async Task<List<Usertb>> GetAllUsers()
        {
            try
            {
                var y = await this.context.Usertbs.ToListAsync();
                return y;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
            
        }

        public async Task<Usertb> getUserByID(SearchUserID id)
        {
            try
            {
                var search = await this.context.Usertbs.Where(x => x.UserId.Equals(id.userID))
                                                                .FirstOrDefaultAsync();
                return search;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
          
        }

        public async Task<List<Usertb>> SearchByName(SearchByFullNameDTO name)
        {
            try
            {
                var list = await this.context.Usertbs.Where(x => x.Username.Contains(name.Username)).ToListAsync();
                if (list != null) return list;
                throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        private string CreateToken(Usertb user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, user.RoleId),
                new Claim("userid", user.UserId),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
        public async Task<string> Login(LoginDTO request)
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
                var token = CreateToken(user);
                return token;
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
                            throw new Exception("UserName has been existted!");
                        }
                    }
                    r.UserId = "US" + Guid.NewGuid().ToString().Substring(0, 5);
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

        public async Task<bool> Dellete(RemoveDTO id)
        {
            try
            {
                if (id != null)
                {
                    var obj = await this.context.Usertbs.Where(x => x.UserId.Equals(id.UserID)).FirstOrDefaultAsync();
                    this.context.Usertbs.Remove(obj);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Usertb> Update(string id,UpdateDTO user)
        {
            try
            {
                //var r = await this.context.Usertbs.Where(x => user.UserID.Equals(x.UserId))
                //                                .FirstOrDefaultAsync();
                //var userS = await this.context.Usertbs.Where(x => x.Equals(user.Username)).FirstOrDefaultAsync();
                //if (userS != null)
                //    throw new Exception("Duplicate UserName please try another one.");
                //if (user != null && r != null)
                //{
                //    r.Username = user.Username ?? r.Username;
                //    r.Fullname = user.fullName ?? r.Fullname;
                //    r.Address = user.address ?? r.Address;
                //    //r.Email = user.Email ?? r.Email;
                //    r.Sex = user.gender ?? r.Sex;
                //    r.PhoneNumber = user.Phone ?? r.PhoneNumber;
                //    //r.RoleId = user.RoleID ?? r.RoleId;
                //    r.BankNumber = user.Bank ?? r.BankNumber;
                //    r.ImageUrl = user.imgURL ?? r.ImageUrl;
                //    r.DateOfBirth = user.dateOfBird ?? r.DateOfBirth;
                //    this.context.Usertbs.Update(r);
                //    await this.context.SaveChangesAsync();
                //    return r;
                //}
                //return r;
                var existingUser = await context.Usertbs.FirstOrDefaultAsync(x => x.UserId == id);
                if (existingUser == null)
                    throw new Exception("USER IS NOT FOUND");

                //var userWithSameUsername = await context.Usertbs.FirstOrDefaultAsync(x => x.Username == user.Username && x.UserId != id);
                //if (userWithSameUsername != null)
                //    throw new Exception("Dupplicate Username");

                existingUser.Username = user.Username ?? existingUser.Username;
                existingUser.Fullname = user.fullName ?? existingUser.Fullname;
                existingUser.Address = user.address ?? existingUser.Address;
                existingUser.Sex = user.gender ?? existingUser.Sex;
                existingUser.PhoneNumber = user.Phone ?? existingUser.PhoneNumber;
                existingUser.BankNumber = user.Bank ?? existingUser.BankNumber;
                existingUser.ImageUrl = user.imgURL ?? existingUser.ImageUrl;
                existingUser.DateOfBirth = user.dateOfBird ?? existingUser.DateOfBirth;

                context.Usertbs.Update(existingUser);
                await context.SaveChangesAsync();
                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
