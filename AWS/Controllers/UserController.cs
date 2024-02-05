
using AWS.Repositories.Interfaces;
using AWS.Repositories.Services;
using backend_not_clear.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user) {
            this.user = user;
        }

        [HttpGet]
        [Route("get all user")]
        public async Task<IActionResult> GetAll() {
            
                var a = await this.user.GetAllUsers();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
        }


        /// <summary>
        /// register for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterDTO user)
        {
            try
            {
                var a = await this.user.Registration(user);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Login with username, password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            try
            {
                var a = await this.user.Login(user);
                return Ok(a);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex);
            }
        }
    }
}
