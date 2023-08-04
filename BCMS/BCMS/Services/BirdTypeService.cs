using BCMS.DTO.BirdType;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class BirdTypeService : IBirdType
    {
        private readonly BCMSContext _context;
        public BirdTypeService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<BirdType> create(BirdTypeCreateDTO dto)
        {
            try
            {
                var bt = new BirdType();
                bt.Status = true;
                bt.BirdTypeName = dto.BirdTypeName;
                bt.BirdTypeDescription = dto.BirdTypeDescription;
                bt.BirdTypeId = "BType" + Guid.NewGuid().ToString().Substring(0, 5);

                await this._context.BirdType.AddAsync(bt);
                await this._context.SaveChangesAsync();
                return bt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<BirdType> delete(string id)
        {
            try
            {
                var check = await this._context.BirdType.Where(x => x.BirdTypeId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = false;
                    this._context.BirdType.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }
                else
                {
                    throw new Exception("null data id");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BirdType>> GetAll()
        {
            try
            {
                var check = await this._context.BirdType.Where(x=>x.Status).ToListAsync();
                if(check != null)
                {
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

        public async Task<BirdType> getbyId(string id)
        {
            try
            {
                var check = await this._context.BirdType.Where(x => x.BirdTypeId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    return check;
                }
                else
                {
                    throw new Exception("null data id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BirdType> update(BirdTypeUpdateDTO dto)
        {
            try
            {
                var check = await this._context.BirdType.Where(x => x.BirdTypeId.Equals(dto.BirdTypeId)).FirstOrDefaultAsync();
                if(check != null)
                {
                    check.BirdTypeName = dto.BirdTypeName;
                    check.BirdTypeDescription = dto.BirdTypeDescription;
                    this._context.BirdType.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }
                else
                {
                    throw new Exception("fail update");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
