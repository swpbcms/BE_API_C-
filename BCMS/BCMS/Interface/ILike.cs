using BCMS.DTO.Interact;

namespace BCMS.Interface
{
    public interface ILike
    {
        Task<bool> Like(LikeDTO like);
        Task<bool> DisLike(LikeDTO like);
    }
}
