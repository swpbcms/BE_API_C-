using BCMS.DTO.Interact;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class CommentService : IComment
    {
        private readonly BCMSContext _context;
        public CommentService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Comment> comment(CommentDTO comment)
        {
            try
            {
                var cmt = new Comment();
                cmt.Status = true;
                cmt.PostId = comment.PostId;
                cmt.CommentContent = comment.CommentContent;
                cmt.CommentId = "CMT"+Guid.NewGuid().ToString().Substring(0,7);
                cmt.DateTime = DateTime.Now;
                cmt.MemberId= comment.MemberId;

                await this._context.Comment.AddAsync(cmt);
                await this._context.SaveChangesAsync();

                var post = await this._context.Post.Where(x=>x.PostId.Equals(comment.PostId)).Include(x=>x.Member).FirstOrDefaultAsync();
                var mem = await this._context.Member.Where(x => x.MemberId.Equals(comment.MemberId)).FirstOrDefaultAsync();
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(comment.PostId) && x.IsFollow && x.Status.Equals("tham gia")).ToListAsync();
                foreach(var item in check)
                {
                    var noti = new Notification();

                    noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                    noti.MemberId = item.MemberId;
                    noti.NotificationDateTime = DateTime.Now;
                    noti.NotificationTitle = "Comment";
                    noti.NotificationContent = mem.MemberFullName + " đã bình luận bài viết của " + post.Member.MemberFullName;
                    noti.NotificationStatus = true;

                    await this._context.Notification.AddAsync(noti);
                    await this._context.SaveChangesAsync();
                    noti = new Notification();
                }
                var noti2 = new Notification();

                noti2.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                noti2.MemberId = post.MemberId;
                noti2.NotificationDateTime = DateTime.Now;
                noti2.NotificationTitle = "Comment";
                noti2.NotificationContent = mem.MemberFullName + " đã bình luận bài viết của " + post.Member.MemberFullName;
                noti2.NotificationStatus = true;

                await this._context.Notification.AddAsync(noti2);
                await this._context.SaveChangesAsync();
                return cmt;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteComment(string id)
        {
            try
            {
                var cmt = await this._context.Comment.Where(x=>x.CommentId.Equals(id)).FirstOrDefaultAsync();
                var rep = await this._context.Comment.Where(x => x.ReplyId.Equals(cmt.CommentId)).ToListAsync();
                foreach( var rep2 in rep)
                {
                    rep2.Status= false;
                }
                cmt.Status = false;
                this._context.Update(cmt);
                this._context.SaveChanges();
                this._context.Update(rep); 
                if(await this._context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Comment>> GetComment()
        {
            try
            {
                var db = await this._context.Comment
                    .Include(x => x.Member)
                    .Include(x => x.InverseReply)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Post)
                    .ToListAsync();
                return db;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Comment>> GetCommentPost(string postid)
        {
            try
            {
                var db = await this._context.Comment.Where(x => x.Status ||x.PostId.Equals(postid))
                    .Include(x => x.Member)
                    .Include(x => x.InverseReply)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Post)
                    .ToListAsync();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Comment>> GetCommentUser()
        {
            try
            {
                var db = await this._context.Comment.Where(x=>x.Status)
                    .Include(x => x.Member)
                    .Include(x=>x.InverseReply)
                        .ThenInclude(x=>x.Member)
                    .Include(x => x.Post)
                    .ToListAsync();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> ReplyComment(ReplyCommentDTO reply)
        {
            try
            {
                var rep = new Comment();

                rep.Status = true;
                rep.PostId = reply.PostId;
                rep.CommentContent = reply.CommentContent;
                rep.CommentId = "CMT" + Guid.NewGuid().ToString().Substring(0, 7);
                rep.DateTime = DateTime.Now;
                rep.ReplyId = reply.CommentIDReply;
                rep.MemberId = reply.MemberId;

                await this._context.Comment.AddAsync(rep);
                await this._context.SaveChangesAsync();

                var mem = await this._context.Member.Where(x => x.MemberId.Equals(reply.MemberId)).FirstOrDefaultAsync();
                var check = await this._context.Comment.Where(x => x.CommentId.Equals(rep.ReplyId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    var noti = new Notification();

                    noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0,6);
                    noti.MemberId = check.MemberId;
                    noti.NotificationDateTime = DateTime.Now;
                    noti.NotificationTitle = "Reply comment";
                    noti.NotificationContent = mem.MemberFullName + " đã trả lời bình luận của bạn";
                    noti.NotificationStatus = true;

                    await this._context.Notification.AddAsync(noti);
                    await this._context.SaveChangesAsync();
                }
                return rep;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> updateComment(updateCommentDTO comment)
        {
            try
            {
                var check = await this._context.Comment.Where(x => x.CommentId.Equals(comment.CommentId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.CommentContent= comment.CommentContent;
                    this._context.Comment.Update(check);
                    await this._context.SaveChangesAsync();
                }
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
