using BCMS.DTO.Interact;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;


namespace BCMS.Services
{
    public class JoinEventService : IJoinEvent
    {
        private readonly BCMSContext _context;
        public JoinEventService(BCMSContext context)
        {
            _context = context;
        }

        public async Task<List<Bird>> birdJoin(BirdJoin dto)
        {
            try
            {
                var check = await this._context.BirdTypeEvent.Where(x=>x.PostId.Equals(dto.PostId)).FirstOrDefaultAsync();
                var check2 = await this._context.Bird.Where(x=>x.MemberId.Equals(dto.MemberId) && x.BirdTypeId.Equals(check.BirdTypeId)).ToListAsync();
                if(check2 != null)
                {
                    return check2;
                }
                else
                {
                    throw new Exception("null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DisJoin(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId) && x.BirdId.Equals(join.BirdId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = "hủy tham gia";
                    this._context.Update(check);

                    await this._context.SaveChangesAsync();

                    var post = await this._context.Post.Where(x => x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin -= 1;
                    this._context.Update(post);
                    await this._context.SaveChangesAsync();
                    return true;
                }return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Follow(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId)&& x.BirdId.Equals(join.BirdId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.IsFollow = true;
                    this._context.Update(check);

                    await this._context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var joinEV = new JoinEvent();
                    joinEV.PostId = join.PostId;
                    joinEV.MemberId = join.MemberId;
                    if (join.Status)
                    {
                        joinEV.Status = "tham gia";
                    }
                    joinEV.Status = "";
                    joinEV.IsFollow = true;

                    await this._context.JoinEvent.AddAsync(joinEV);
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

        public async Task<bool> Join(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId) && x.BirdId.Equals(join.BirdId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = "tham gia";
                    check.IsFollow = true;
                    check.BirdId = join.BirdId;

                    var post = await this._context.Post.Where(x => x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin += 1;
                    this._context.Post.Update(post);
                    await this._context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var joinEV = new JoinEvent();
                    joinEV.PostId = join.PostId;
                    joinEV.MemberId = join.MemberId;
                    joinEV.BirdId = join.BirdId;
                    joinEV.Status = "tham gia";
                    joinEV.IsFollow = true;
                    joinEV.DateTime = DateTime.Now;

                    await this._context.JoinEvent.AddAsync(joinEV);
                    await this._context.SaveChangesAsync();

                    var post = await this._context.Post.Where(x=>x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin += 1;
                    this._context.Post.Update(post);
                    await this._context.SaveChangesAsync();

                    var post1 = await this._context.Post.Where(x => x.PostId.Equals(join.PostId)).Include(x => x.Member).FirstOrDefaultAsync();
                    var mem = await this._context.Member.Where(x => x.MemberId.Equals(join.MemberId)).FirstOrDefaultAsync();
                    var check1 = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.IsFollow && x.Status.Equals("tham gia")).ToListAsync();
                    foreach (var item in check1)
                    {
                        var noti = new Notification();

                        noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                        noti.MemberId = item.MemberId;
                        noti.NotificationDateTime = DateTime.Now;
                        noti.NotificationTitle = "Tham gia event";
                        noti.NotificationContent = mem.MemberFullName + " đã tham gia sự kiện của " + post1.Member.MemberFullName;
                        noti.NotificationStatus = true;

                        await this._context.Notification.AddAsync(noti);
                        await this._context.SaveChangesAsync();
                        noti = new Notification();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UnFollow(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId) && x.BirdId.Equals(join.BirdId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.IsFollow = false;
                    this._context.Update(check);
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

        public async Task<bool> manager(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId) && x.BirdId.Equals(join.BirdId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status ="success";
                    this._context.Update(check);
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

        public async Task<List<JoinEvent>> get (string join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(join)).ToListAsync();
                if(check != null)
                {
                    return check;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
