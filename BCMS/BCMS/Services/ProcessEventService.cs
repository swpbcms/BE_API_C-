using BCMS.DTO.ProcessEvent;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class ProcessEventService : IProcessEvent
    {
        private readonly BCMSContext _context;
        public ProcessEventService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<ProcessEvent> create(ProcessEventDTO dto)
        {
            try
            {
                var processEvent = new ProcessEvent();

                processEvent.ProcessId = "PCEV"+Guid.NewGuid().ToString().Substring(0,6);
                processEvent.PostId = dto.PostId;
                processEvent.EventRule = dto.EventRule;
                processEvent.EventReward = dto.EventReward;
                
                await this._context.ProcessEvent.AddAsync(processEvent);
                await this._context.SaveChangesAsync();
                return processEvent;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProcessEvent>> getall()
        {
            try
            {
                var check = await this._context.ProcessEvent.ToListAsync();
                if(check != null)
                {
                    return check;
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProcessEvent>> getForPost(string id)
        {
            try
            {
                var check = await this._context.ProcessEvent.Where(x=>x.PostId.Equals(id)).ToListAsync();
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

        public async Task<ProcessEvent> update(ProcessEventDTO dto)
        {
            try
            {
                var check = await this._context.ProcessEvent.Where(x => x.ProcessId.Equals(dto.ProcessId)).FirstOrDefaultAsync();
                check.EventRule = dto.EventRule;
                check.EventReward = dto.EventReward;
                this._context.ProcessEvent.Update(check);
                await this._context.SaveChangesAsync();
                 return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
