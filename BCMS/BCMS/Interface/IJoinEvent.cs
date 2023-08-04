using BCMS.DTO.Interact;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IJoinEvent
    {
        Task<bool> Join(JoinEventDTO join);
        Task<bool> DisJoin(JoinEventDTO join);
        Task<bool> Follow(JoinEventDTO join);
        Task<bool> UnFollow(JoinEventDTO join);
        Task<List<Bird>> birdJoin(BirdJoin dto);
        Task<List<JoinEvent>> get(string join);
        Task<bool> manager(JoinEventDTO join);
    }
}
