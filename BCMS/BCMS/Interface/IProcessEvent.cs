using BCMS.DTO.ProcessEvent;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IProcessEvent
    {
        Task<List<ProcessEvent>> getall();
        Task<List<ProcessEvent>> getForPost(string id);
        Task<ProcessEvent> create(ProcessEventDTO dto);
        Task<ProcessEvent> update(ProcessEventDTO dto);
    }
}
