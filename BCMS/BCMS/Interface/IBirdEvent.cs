using BCMS.DTO.Post;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IBirdEvent
    {
        Task<BirdEvent> create(CreateBirdEventDTO dto);
        Task<BirdEvent> update(UpdateBirdEventDTO dto);
        Task<BirdEvent> delete(string id); 
        Task<List<BirdEvent>> getAll();
        Task<List<BirdEvent>> getAllBirdEventUser(string memberId);
        Task<List<BirdEvent>> getAllBirdEventPost(string postId);
        Task<List<Bird>> birdjoinev(string post);
        Task<List<birdscore>> rank(string postId);
    }
}
