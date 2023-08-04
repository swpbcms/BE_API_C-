using BCMS.DTO.Interact;
using BCMS.DTO.Post;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BCMS.Services
{
    public class PostService : IPost
    {
        private readonly BCMSContext _context;
        public PostService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Post> CreatePost(CreatePostDTO post)
        {
            try
            {
                var pst = new Post();
                
                pst.PostId = "Post"+Guid.NewGuid().ToString().Substring(0,6);
                pst.PostTitle = post.PostTitle;
                pst.PostDescription= post.PostDescription;
                pst.PostNumberLike = 0;
                pst.PostNumberJoin = 0;
                pst.PostCreateAt= DateTime.Now;
                pst.MemberId= post.MemberId;

                if(post.PostIsEvent)
                {
                    pst.PostIsEvent = true;
                    pst.PostStatus = "Chờ duyệt";
                    pst.EventStartDate = post.EventStartDate;
                    pst.EventEndDate = post.EventEndDate;
                    pst.EventLocation = post.EventLocation;
                }
                else
                {
                    pst.PostIsEvent = false;
                    pst.PostStatus = "Thành công";
                }
                await this._context.Post.AddAsync(pst);
                await this._context.SaveChangesAsync();
                foreach (var x in post.categories)
                {
                    var check = await this._context.Category.Where(c => c.CategoryId.Equals(x.CategoryID)).FirstOrDefaultAsync();
                    if(check != null)
                    {
                        var postCate = new PostCategory();

                        postCate.PostId = pst.PostId;
                        postCate.CategoryId = check.CategoryId;
                        postCate.Status = true;

                        await this._context.PostCategory.AddAsync(postCate);
                        await this._context.SaveChangesAsync();

                        postCate = new PostCategory();
                    }
                }
                foreach(var bird in post.birdTypes)
                {
                    var check = await this._context.BirdType.Where(c => c.BirdTypeId.Equals(bird.BirdTypeId)).FirstOrDefaultAsync();
                    if (check != null)
                    {
                        var type = new BirdTypeEvent();

                        type.PostId = pst.PostId;
                        type.BirdTypeId = check.BirdTypeId;
                        type.DateTime = DateTime.Now;

                        await this._context.BirdTypeEvent.AddAsync(type);
                        await this._context.SaveChangesAsync();

                        type = new BirdTypeEvent();
                    }
                }

                    foreach(var media in post.media)
                    {
                        var med = new Media();

                        med.Status = true;
                        med.PostId = pst.PostId;
                        med.LinkMedia = media.LinkMedia;
                        med.MediaId = "MED" + Guid.NewGuid().ToString().Substring(0, 7);

                        await this._context.Media.AddAsync(med);
                        await this._context.SaveChangesAsync();
                        med = new Media();
                    }
                
                await this._context.SaveChangesAsync();

                return pst;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> DeletePost(string id)
        {
            try
            {
                var check = await this._context.Post.Where(x=>x.PostId.Equals(id)).FirstOrDefaultAsync();    
                if(check != null)
                {
                    check.PostStatus = "hủy";
                    this._context.Post.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> getPostID(string id)
        {
            try
            {
                var check = await this._context.Post.Where(x => x.PostId.Equals(id))
                    .Include(x => x.PostCategory).ThenInclude(x => x.Category)
                    .Include(x => x.Member)
                    .Include(x => x.Media)
                    .Include(x => x.JoinEvent)
                    .Include(x => x.Like)
                    .Include(x => x.Comment)
                        .ThenInclude(u => u.Member)
                    .Include(x => x.Comment)
                        .ThenInclude(x => x.InverseReply)
                        .ThenInclude(u => u.Member)
                    .Include(x => x.ProcessEvent)
                    .OrderByDescending(x => x.PostCreateAt).FirstOrDefaultAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<JoinEvent>> getJoinMember(string id)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(id)).ToListAsync();
                if(check != null)
                {
                    return check;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Like>> getLikeMember(string id)
        {
            try
            {
                var check = await this._context.Like.Where(x => x.PostId.Equals(id)).ToListAsync();
                if (check != null)
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

        public async Task<List<Post>> GetPost()
        {
            try
            {
                var check = await this._context.Post
                    .Include(x=> x.PostCategory).ThenInclude(x=>x.Category)
                    .Include(x=>x.Member)
                    .Include(x=>x.Media)
                    .Include(x=>x.JoinEvent)
                    .Include(x=>x.Like)
                    .Include(x=>x.Comment)
                        .ThenInclude(u=>u.Member)
                    .Include(x => x.Comment)
                        .ThenInclude(x=>x.InverseReply)
                        .ThenInclude(u => u.Member)
                    .Include(x=>x.ProcessEvent)
                    .OrderByDescending(x=>x.PostCreateAt)
                    .ToListAsync();
                if(check != null)
                {
                    return check;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetPostUser()
        {
            try
            {
                var check = await this._context.Post
                    //.Include(x => x.ManagerId)
                    .Include(x => x.PostCategory).ThenInclude(x => x.Category)
                    .Include(x => x.Member)
                    .Include(x => x.Media)
                    .Include(x => x.JoinEvent)
                    .Include(x => x.Like)
                    .Include(x => x.Comment)
                        .ThenInclude(u => u.Member)
                    .Include(x => x.Comment)
                        .ThenInclude(x => x.InverseReply)
                        .ThenInclude(u => u.Member)
                    .Include(x => x.ProcessEvent)
                    .Where(x=>x.PostStatus.Equals("Thành công")).ToListAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> moderate(string id,bool option, string managerID)
        {
            try
            {
                var mng = await this._context.Manager.Where(x=>x.ManagerId.Equals(managerID)).FirstOrDefaultAsync();
                if (mng == null)
                {
                    throw new Exception("Manager moderate");
                }
                var check = await this._context.Post.Where(x=>x.PostId.Equals(id)).FirstOrDefaultAsync();
                if(check.PostStatus.Contains("Chờ duyệt"))
                {
                    if (option)
                    {
                        check.ManagerId= managerID;
                        check.PostStatus = "Thành công";
                    }
                    else
                    {
                        check.ManagerId = managerID;
                        check.PostStatus = "hủy";
                    }
                }
                this._context.Post.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Post> admin(string id, bool option)
        {
            try
            {
                var check = await this._context.Post.Where(x => x.PostId.Equals(id)).FirstOrDefaultAsync();
                if (check.PostStatus.Contains("Chờ duyệt"))
                {
                    if (option)
                    {
                        check.PostStatus = "Thành công";
                    }
                    else
                    {
                        check.PostStatus = "hủy";
                    }
                }
                this._context.Post.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> searchPost(string search)
        {
            try
            {
                var check = await this._context.Post.Where(x=>x.PostTitle.Contains(search)).ToListAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> searchPostManager()
        {
            try
            {
                var check = await this._context.Post.Where(x => x.PostStatus.Contains("Chờ duyệt")).ToListAsync();
                if(check != null)
                {
                    return check;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> UpdatePost(updatePostDTO post)
        {
            try
            {
                var check = await this._context.Post.Where(x=>x.PostId.Equals(post.PostId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.PostTitle = post.PostTitle;
                    check.PostDescription = post.PostDescription;
                    if(check.PostIsEvent)
                    {
                        check.EventStartDate = post.EventStartDate;
                        check.EventEndDate = post.EventEndDate;
                        check.EventLocation= post.EventLocation;
                    }
                    if (!check.PostIsEvent)
                    {
                        if (post.PostIsEvent)
                        {
                            check.EventStartDate = post.EventStartDate;
                            check.EventEndDate = post.EventEndDate;
                            check.EventLocation = post.EventLocation;
                            check.PostStatus = "Chờ duyệt";
                            check.PostIsEvent = true;
                        }
                    }
                }
                this._context.Post.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> reStatus(string id)
        {
            try
            {
                var check = await this._context.Post.Where(x => x.PostId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.PostStatus = "Thành công";
                }
                this._context.Post.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> PostHome()
        {
            try
            {
                var check = await this._context.Post.OrderByDescending(x => x.PostNumberLike).Include(x=>x.Media).ToListAsync();
                if (check != null)
                {
                    return check;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
