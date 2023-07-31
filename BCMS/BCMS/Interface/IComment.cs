using BCMS.DTO.Interact;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IComment
    {
        Task<Comment> comment(CommentDTO comment);
        Task<Comment> ReplyComment(ReplyCommentDTO reply);
        Task<List<Comment>> GetComment();
        Task<List<Comment>> GetCommentUser();
        Task<List<Comment>> GetCommentPost(string postid);
        Task<bool> deleteComment(string id);
        Task<Comment> updateComment(updateCommentDTO comment);
    }
}
