using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.ProcessEvent
{
    public class ProcessEventDTO
    {
        public string ProcessId { get; set; }
        public string? PostId { get; set; }
        public string? EventRule { get; set; }
        public string? EventReward { get; set; }
    }
}
