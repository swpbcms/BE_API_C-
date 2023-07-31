using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class NotificationService : INotification
    {
        private readonly BCMSContext _context;
        public NotificationService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<List<Notification>> getAll()
        {
            try
            {
                var check = await this._context.Notification.
                    OrderByDescending(x=>x.NotificationDateTime).ToListAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Notification>> GetNotificationAsync(string id)
        {
            try
            {
                var check = await this._context.Notification.Where(x=>x.MemberId.Equals(id)).Include(x=>x.Member).OrderByDescending(x => x.NotificationDateTime).ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
