using AWS.DTO;
using AWS.DTO.ArtworkDTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeCollectionController : ControllerBase
    {
        private readonly ICollection collection;

        public LikeCollectionController(ICollection collection)
        {
            this.collection = collection;
        }

        [HttpPost]
        [Route("Love")]

        public async Task<IActionResult> AddToCollection(CollectionDTO create)
        {
            try
            {
                var a = await this.collection.Love(create);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the AddToCollection method: {ex}");

                throw;
            }

        }

        [HttpDelete]
        [Route("Un-Love")]

        public async Task<IActionResult> RemoveToCollection(DeleteCollectionDTO create)
        {
            try
            {
                var a = await this.collection.UnLove(create);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the RemoveToCollection method: {ex}");

                throw;
            }

        }
    }
}
