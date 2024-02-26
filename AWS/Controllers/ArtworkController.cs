
using AWS.Repositories.Interfaces;
using AWS.DTO.ArtworkDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtwork artwork;

        public ArtworkController(IArtwork artwork )
        {
            this.artwork = artwork;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.artwork.GetAllArtworks();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAll method: {ex}");

                throw;
            }
           
        }

        [HttpGet]
        [Route("get-by-id")]

        public async Task<IActionResult> GetByID(string id)
        {
            try
            {
                var a = await this.artwork.GetArtworkId(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetByID method: {ex}");

                throw;
            }
          
        }

        [HttpGet]
        [Route("search-by-name")]

        public async Task<IActionResult> SearchByName(string name)
        {
            try
            {
                var a = await this.artwork.SearchByName(name);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the SearchByName method: {ex}");

                throw;
            }
           
        }

        [HttpGet]
        [Route("search-by-gerne")]

        public async Task<IActionResult> GetByGenre(string genreId)
        {
            try
            {
                var a = await this.artwork.GetByGenre(genreId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetByGenre method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("create-new-artwork")]

        public async Task<IActionResult> CreateArtwork(CreateArtwork createArtwork)
        {
            try
            {
                var a = await this.artwork.CreateArtwork(createArtwork);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateArtwork method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("update-artwork")]

        public async Task<IActionResult> UpdateArtwork(string artworkId, UpdateArtWork updatedArtwork)
        {
            try
            {
                var a = await this.artwork.UpdateArtWork(artworkId,updatedArtwork);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateArtwork method: {ex}");

                throw;
            }

        }
    }
}
