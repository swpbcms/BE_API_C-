using BCMS.DTO.Blog;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IBlog
    {
        Task<Blog> create(BlogCreateDTO dto);
        Task<Blog> update(BlogUpdateDTO dto);
        Task<Blog> delete(string id);
        Task<Blog> find(string id);
        Task<List<Blog>> findAll();
        Task<List<Blog>> blogForUser();
    }
}
