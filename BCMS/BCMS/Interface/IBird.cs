using BCMS.DTO.Bird;
using BCMS.Models;
using System.Runtime.CompilerServices;

namespace BCMS.Interface
{
    public interface IBird
    {
        Task<Bird> createBird(BirdCreateDTO dto);
        Task<Bird> updateBird(BirdUpdateDTO dto);
        Task<List<Bird>> listBirdMember(string memberId);
        Task<Bird> getById(string id);
        Task<Bird> delete(string id);
        Task<List<Bird>> getAll();
        Task<List<Bird>> getBirdJoinEvent(string postId);
    }
}
