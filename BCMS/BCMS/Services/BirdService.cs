using BCMS.DTO.Bird;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class BirdService : IBird
    {
        private readonly BCMSContext _context;
        public BirdService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Bird> createBird(BirdCreateDTO dto)
        {
            try
            {
                var bird = new Bird();
                bird.BirdId = "BIRD"+Guid.NewGuid().ToString().Substring(0,6);
                bird.Status = true;
                bird.Size = dto.Size;
                bird.Age = dto.Age;
                bird.BirdName = dto.BirdName;
                bird.BirdTypeId = dto.BirdTypeId;
                bird.Image = dto.Image;
                bird.Weight = dto.Weight;
                bird.MemberId = dto.MemberId;
                
                await this._context.Bird.AddAsync(bird);
                await this._context.SaveChangesAsync();

                var check = await this._context.Member.Where(x=>x.MemberId== dto.MemberId).FirstOrDefaultAsync();
                check.NumberOfBird += 1;
                this._context.Member.Update(check);
                await this._context.SaveChangesAsync();
                return bird;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bird> delete(string id)
        {
            try
            {
                var check = await this._context.Bird.Where(x => x.BirdId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status= false;
                    this._context.Bird.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }
                else
                {
                    throw new Exception("null data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Bird>> getAll()
        {
            try
            {
                var check = await this._context.Bird.ToListAsync();
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

        public Task<List<Bird>> getBirdJoinEvent(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Bird> getById(string id)
        {
            try
            {
                var check = await this._context.Bird.Where(x => x.BirdId.Equals(id)).FirstOrDefaultAsync();
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

        public async Task<List<Bird>> listBirdMember(string memberId)
        {
            try
            {
                var check = await this._context.Bird.Where(x => x.MemberId.Equals(memberId)).ToListAsync();
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

        public async Task<Bird> updateBird(BirdUpdateDTO dto)
        {
            try
            {
                var check = await this._context.Bird.Where(x=>x.BirdId== dto.BirdId).FirstOrDefaultAsync();
                check.Weight = dto.Weight;
                check.Age = dto.Age;
                check.BirdTypeId = dto.BirdTypeId;
                check.BirdName = dto.BirdName;
                check.Image = dto.Image;
                check.Size = dto.Size;
                
                this._context.Bird.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
