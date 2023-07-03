using BCMS.DTO.Interact;
using BCMS.DTO.Post;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

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

                pst.Category = new List<Category>();
                foreach (var x in post.categories)
                {
                    var check = await this._context.Category.Where(c => c.CategoryId.Equals(x.CategoryID)).FirstOrDefaultAsync();
                    if(check != null)
                    {
                        pst.Category.Add(check);
                    }
                }


                await this._context.Post.AddAsync(pst);
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
                    await this._context.SaveChangesAsync();
                    return check;
                }return null;
            }catch(Exception ex)
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
                    //.Select(x=> new Post
                    //{
                    //    ManagerId= x.ManagerId,
                    //    PostId= x.PostId,
                    //    MemberId= x.MemberId,
                    //    PostTitle= x.PostTitle,
                    //    PostDescription= x.PostDescription,
                    //    PostIsEvent= x.PostIsEvent,
                    //    EventStartDate= x.EventStartDate,
                    //    EventEndDate= x.EventEndDate,
                    //    EventLocation= x.EventLocation,
                    //    PostCreateAt= x.PostCreateAt,
                    //    PostNumberJoin= x.PostNumberJoin,
                    //    PostNumberLike  = x.PostNumberLike,
                    //    PostStatus= x.PostStatus
                    //})
                    //.Include(x=>x.ManagerId)
                    .Include(x=> x.Category)
                    .Include(x=>x.Member)
                    .Include(x=>x.Media)
                    .Include(x=>x.JoinEvent)
                    .Include(x=>x.Like)
                    .Include(x=>x.Comment)
                        .ThenInclude(u=>u.Member)
                    .Include(x=>x.ProcessEvent)
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
                    .Include(x => x.Category)
                    .Include(x => x.Member)
                    .Include(x => x.Media)
                    //.Include(x => x.JoinEvent)
                    //.Include(x => x.Like)
                    .Include(x => x.Comment)
                        .ThenInclude (u=>u.Member)
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
                await this._context.SaveChangesAsync();
                return check;
            }
            catch(Exception ex)
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
                        }
                    }
                }
                await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
