using BCMS.DTO.Post;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class BirdEventService : IBirdEvent
    {
        private readonly BCMSContext _context;
        public BirdEventService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<BirdEvent> create(CreateBirdEventDTO dto)
        {
            try
            {
                if (dto.Bird1.Equals(dto.Bird2))
                {
                    throw new Exception("trungf bird");
                }
                var ev = new BirdEvent();
                ev.PostId= dto.PostId;
                ev.Bird1 = dto.Bird1;
                ev.Bird2 = dto.Bird2;
                ev.Bird1Score = 0;
                ev.Bird2Score = 0;
                ev.Winner = null;
                ev.EventDate = dto.EventDate;
                ev.BirdEventId = "EV"+Guid.NewGuid().ToString().Substring(0,8);

                await this._context.BirdEvent.AddAsync(ev);
                await this._context.SaveChangesAsync();
                return ev;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BirdEvent> delete(string id)
        {
            try
            {
                var check = await this._context.BirdEvent.Where(x => x.BirdEventId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    this._context.BirdEvent.Remove(check);
                    this._context.SaveChangesAsync();
                    return check;
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

        public async Task<List<BirdEvent>> getAll()
        {
            try
            {
                var check = await this._context.BirdEvent
                    .Include(x=>x.Bird1Navigation)
                        .ThenInclude(x=>x.Member)
                    .Include(x=>x.Bird2Navigation)
                        .ThenInclude(x => x.Member)
                    .Include(x=>x.Post)
                    .ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BirdEvent>> getAllBirdEventPost(string postId)
        {
            try
            {
                var check = await this._context.BirdEvent.Where(x => x.PostId.Equals(postId))
                    .Include(x => x.Bird1Navigation)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Bird2Navigation)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Post).ToListAsync();
                if (check != null)
                {
                    return check;
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

        public async Task<List<BirdEvent>> getAllBirdEventUser(string memberId)
        {
            try
            {
                var check = await this._context.BirdEvent.Where(x => x.Bird1Navigation.MemberId.Equals(memberId) || x.Bird2Navigation.MemberId.Equals(memberId))
                    .Include(x => x.Bird1Navigation)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Bird2Navigation)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Post).ToListAsync();
                if (check != null)
                {
                    return check;
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

        public async Task<BirdEvent> update(UpdateBirdEventDTO dto)
        {
            try
            {
                var check = await this._context.BirdEvent.Where(x => x.BirdEventId.Equals(dto.BirdEventId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Bird1Score= dto.Bird1Score;
                    check.Bird1 = dto.Bird1 ?? check.Bird1;
                    check.Bird2 = dto.Bird2 ?? check.Bird2;
                    check.Bird2Score = dto.Bird2Score;
                    check.Winner = dto.Winner;
                    this._context.BirdEvent.Update(check);
                    this._context.SaveChangesAsync();
                    return check;
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
        public async Task<List<Bird>> birdjoinev(string post)
        {
            try
            {
                var resl = new List<Bird>();
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(post) && x.Status.Equals("tham gia")).ToListAsync();
                foreach (var x in check)
                {
                    var b = await this._context.Bird.Where(x => x.BirdId.Equals(x.BirdId)).FirstOrDefaultAsync();
                    resl.Add(b);
                }
                return resl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<birdscore>> rank(string postId)
        {
            try
            {
                var resl = new List<birdscore>();
                var tmp = new birdscore();
                tmp.totalscore = 0;
                tmp.rank = 0;
                var check = await this._context.JoinEvent.Where(x=>x.PostId== postId &&x.Status.Equals("tham gia")).ToListAsync();
                var re = await this._context.BirdEvent.Where(x=>x.PostId == postId).ToListAsync();

                foreach(var x in check)
                {
                    tmp.birdId = x.BirdId;
                    foreach(var e in re)
                    {
                        if(x.BirdId.Equals(e.Bird1))
                        {
                            tmp.totalscore += (int)e.Bird1Score;
                        }
                        if (x.BirdId.Equals(e.Bird2))
                        {
                            tmp.totalscore += (int)e.Bird2Score;
                        }
                    }
                    resl.Add(tmp);
                    tmp = new birdscore();
                }
                resl.OrderByDescending(x => x.totalscore);
                foreach (var p in resl)
                {
                    p.rank += 1;
                }
                return resl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
