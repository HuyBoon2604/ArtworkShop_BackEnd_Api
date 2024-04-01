using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtCustomeController : ControllerBase
    {
        private readonly IArtCustome artCustome;

        public ArtCustomeController(IArtCustome artCustome)
        {
            this.artCustome = artCustome;
        }
    }
}
