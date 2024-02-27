using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SComment : IComment
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SComment(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public Task<Comment> CreateNewComment(NewComment newComment)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> GetCommentByArtworkID(string ArtworkID)
        {
            try
            {
                var a = await this.cxt.Artworks.Where(x => x.ArtworkId.Equals(ArtworkID)).FirstOrDefaultAsync();

                var b = await this.cxt.Comments.Where(x => x.CommentId.Equals(a.Comments)).FirstOrDefaultAsync();

                return b;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> GetCommentByID(string id)

        {
            try
            {
                var a = await this.cxt.Comments.Where(x => x.CommentId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        public Task<Comment> GetCommentByUserID(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetComments()
        {
            try
            {
                var y = await this.cxt.Comments.ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
