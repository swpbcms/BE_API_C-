using BCMS.DTO.Interact;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class LikeService : ILike
    {
        private readonly BCMSContext _context;
        public LikeService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<bool> DisLike(LikeDTO like)
        {
            try
            {
                var db = await this._context.Like.Where(x=>x.PostId.Equals(like.PostId) && x.MemberId.Equals(like.MemberId)).FirstOrDefaultAsync();

                this._context.Like.Remove(db);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    var check = await this._context.Post.Where(x => x.PostId.Equals(like.PostId)).FirstOrDefaultAsync();
                    check.PostNumberLike = check.PostNumberLike -1;
                    this._context.Post.Update(check);
                    await this._context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Like(LikeDTO like)
        {
            try
            {
                var li = await this._context.Like.Where(x => x.MemberId.Equals(like.MemberId) && x.PostId.Equals(like.PostId)).FirstOrDefaultAsync();
                if(li != null)
                {
                    return true;
                }
                var db = new Like();
                db.PostId = like.PostId;
                db.MemberId = like.MemberId;
                db.DateTime = DateTime.Now;

                await this._context.Like.AddAsync(db);
                if(await this._context.SaveChangesAsync() >0)
                {
                    var check = await this._context.Post.Where(x=>x.PostId.Equals(like.PostId)).Include(x=>x.Member).FirstOrDefaultAsync();
                    check.PostNumberLike = check.PostNumberLike+1;
                    this._context.Post.Update(check);
                    await this._context.SaveChangesAsync();

                    var mem = await this._context.Member.Where(x => x.MemberId.Equals(like.MemberId)).FirstOrDefaultAsync();
                    var noti = new Notification();

                    noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                    noti.MemberId = check.MemberId;
                    noti.NotificationDateTime = DateTime.Now;
                    noti.NotificationTitle = "Reply comment";
                    noti.NotificationContent = mem.MemberFullName + " đã thích bài viết của bạn";
                    noti.NotificationStatus = true;

                    await this._context.Notification.AddAsync(noti);
                    await this._context.SaveChangesAsync();
                    return true;
                }return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
