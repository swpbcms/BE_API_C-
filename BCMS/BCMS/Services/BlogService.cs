using BCMS.DTO.Blog;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BCMS.Services
{
    public class BlogService : IBlog
    {
        private readonly BCMSContext _context;
        public BlogService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<List<Blog>> blogForUser()
        {
            try
            {
                var check = await this._context.Blog.Where(x => x.Status)
                    .Include(x=>x.Media)
                    .ToListAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Blog> create(BlogCreateDTO dto)
        {
            try
            {
                var blog = new Blog();
                blog.BlogId = "BLOG"+Guid.NewGuid().ToString().Substring(0,6);
                blog.BlogTitle = dto.BlogTitle;
                blog.BlogDescription = dto.BlogDescription;
                blog.Status = true;
                blog.Datetime = DateTime.Now;
                blog.ManagerId = dto.ManagerId;

                await this._context.Blog.AddAsync(blog);
                await this._context.SaveChangesAsync();

                foreach( var x in dto.media)
                {
                    var med = new Media();

                    med.Status = true;
                    med.BlogId = blog.BlogId;
                    med.LinkMedia = x.LinkMedia;
                    med.MediaId = "MED" + Guid.NewGuid().ToString().Substring(0, 7);

                    await this._context.Media.AddAsync(med);
                    await this._context.SaveChangesAsync();
                    med = new Media();
                }

                await this._context.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Blog> delete(string id)
        {
            try
            {
                var check = await this._context.Blog.Where(x => x.BlogId.Equals(id))
                    .Include(x => x.Media)
                    .FirstOrDefaultAsync();
                check.Status = false;
                this._context.Blog.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Blog> find(string id)
        {
            try
            {
                var check = await this._context.Blog.Where(x => x.BlogId.Equals(id))
                    .Include(x => x.Media)
                    .FirstOrDefaultAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Blog>> findAll()
        {
            try
            {
                var check = await this._context.Blog
                    .Include(x => x.Media)
                    .ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Blog> update(BlogUpdateDTO dto)
        {
            try
            {
                var check = await this._context.Blog.Where(x => x.BlogId.Equals(dto.BlogId))
                    .Include(x => x.Media)
                    .FirstOrDefaultAsync();
                check.BlogTitle = dto.BlogTitle;
                check.Status = dto.Status;
                check.BlogDescription = dto.BlogDescription;
                this._context.Blog.Update(check);
                await this._context.SaveChangesAsync();
                if(dto.media != null)
                {
                    var me = await this._context.Media.Where(x=>x.BlogId.Equals(dto.BlogId)).ToListAsync();
                    this._context.Media.RemoveRange(me);

                    foreach (var x in dto.media)
                    {
                        var med = new Media();

                        med.Status = true;
                        med.PostId = check.BlogId;
                        med.LinkMedia = x.LinkMedia;
                        med.MediaId = "MED" + Guid.NewGuid().ToString().Substring(0, 7);

                        await this._context.Media.AddAsync(med);
                        await this._context.SaveChangesAsync();
                        med = new Media();
                    }
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
