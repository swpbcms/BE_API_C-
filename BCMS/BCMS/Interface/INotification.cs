using BCMS.Models;

namespace BCMS.Interface
{
    public interface INotification
    {
        Task<List<Notification>> GetNotificationAsync(string id);
        Task<List<Notification>> getAll();
    }
}
