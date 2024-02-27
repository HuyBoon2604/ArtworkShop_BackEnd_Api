using AWS.DTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetComments();  
        Task<Comment> GetCommentByID(string id);
        Task<Comment> GetCommentByUserID(string userID);
        Task<Comment> GetCommentByArtworkID(string ArtworkID);
        Task<Comment> CreateNewComment(NewComment newComment);
    }
}
