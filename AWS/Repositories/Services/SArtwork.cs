using AWS.DTO.ArtworkDTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using AWS.Repositories.Interfaces;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace AWS.Repositories.Services
{
    public class SArtwork : IArtwork
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SArtwork(ARTWORKPLATFORMContext Cxt)
        {
            cxt = Cxt;
        }

        public async Task<Artwork> CreateArtwork(CreateArtwork createArtwork)
        {
            try
            {


                var newArtwork = new Artwork
                {
                    ArtworkId = "A" + Guid.NewGuid().ToString().Substring(0, 5),
                    //UserId = createArtwork.UserId,
                    ImageUrl = createArtwork.ImageUrl,
                    Title = createArtwork.Title,
                    Description = createArtwork.Description,
                    Price = createArtwork.Price,
                    //GenreId = createArtwork.GenreId,
                    //LinkShare = createArtwork.LinkShare,
                    //Status = createArtwork.Status,
                    LikeTimes = 0,
                    Time = DateTime.Now,
                    Reason = createArtwork.Reason,
                };


                await this.cxt.Artworks.AddAsync(newArtwork);
                await cxt.SaveChangesAsync();


                if (await this.cxt.SaveChangesAsync() > 0)
                {
                    if (createArtwork.Gernes != null)
                    {
                        foreach (var x in createArtwork.Gernes)
                        {
                            var st = new Gerne();
                            st.ProductId = add.ProductId;
                            st.StyleId = style.StyleID;
                            st.Status = true;
                            await this._context.StyleProduct.AddAsync(st);
                            await this._context.SaveChangesAsync();
                        }
                    }
                }
                    return newArtwork;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Artwork>> GetAllArtworks()
        {
            try
            {
                var y = await this.cxt.Artworks.ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public async Task<Artwork> GetArtworkId(string id)
        {
            try
            {
                var a = await this.cxt.Artworks.Where(x => x.ArtworkId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<List<Artwork>> SearchByName(string name)
        {
            try
            {
                var list = await this.cxt.Artworks
                            .Where(x => x.Title.Contains(name))
                            .ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Artwork>> GetByGenre(string genreId)
        {

            try
            {
                var artworks = await this.cxt.Artworks
               .Where(a => a.GenreId == genreId)
               .ToListAsync();

                return artworks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

        
    
          

