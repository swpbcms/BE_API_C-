using BCMS.DTO.Interact;
using BCMS.DTO.Post;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IPost
    {
        Task<List<Post>> GetPost();
        Task<List<Post>> GetPostUser();
        Task<Post> CreatePost(CreatePostDTO post);
        Task<Post> UpdatePost(updatePostDTO post);
        Task<Post> DeletePost(string id);
        Task<Post> getPostID(string id);
        Task<List<Post>> searchPost(string search);
        Task<List<Post>> searchPostManager();
        Task<Post> moderate(string id, bool option,string managerID);
        Task<List<Like>> getLikeMember(string id);
        Task<List<JoinEvent>> getJoinMember(string id);
        Task<Post> reStatus(string id);
        Task<List<Post>> PostHome();
        Task<Post> admin(string id, bool option);
    }
}
