using BCMS.DTO.Interact;

namespace BCMS.Interface
{
    public interface IJoinEvent
    {
        Task<bool> Join(JoinEventDTO join);
        Task<bool> DisJoin(JoinEventDTO join);
        Task<bool> Follow(JoinEventDTO join);
        Task<bool> UnFollow(JoinEventDTO join);
    }
}
