using BCMS.DTO.Media;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IMedia
    {
        Task<Media> create(MediaDTO media);
        Task<Media> update(MediaDTO media);
        Task<Media> delete( string id);
        Task<List<Media>> geMediaPost(string post);
    }
}
