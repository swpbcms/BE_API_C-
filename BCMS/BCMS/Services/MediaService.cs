using BCMS.DTO.Media;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class MediaService : IMedia
    {
        private readonly BCMSContext _context;
        public MediaService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Media> create(MediaDTO media)
        {
            try
            {
                var med = new Media();

                med.Status = true;
                med.PostId = media.PostId;
                med.LinkMedia = media.LinkMedia;
                med.MediaId = "MED"+Guid.NewGuid().ToString().Substring(0,7);

                await this._context.Media.AddAsync(med);
                await this._context.SaveChangesAsync();

                return med;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Media> delete(string id)
        {
            try
            {
                var check = await this._context.Media.Where(x => x.MediaId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status= false;
                    await this._context.SaveChangesAsync();

                    return check;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Media>> geMediaPost(string post)
        {
            try
            {
                var check = await this._context.Media.Where(x => x.PostId.Equals(post)).ToListAsync();
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

        public async Task<Media> update(MediaDTO media)
        {
            try
            {
                var check = await this._context.Media.Where(x => x.MediaId.Equals(media.MediaId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.LinkMedia = media.LinkMedia;
                    await this._context.SaveChangesAsync();

                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
