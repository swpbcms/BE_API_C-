using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Media
{
    public class MediaDTO
    {
        public string? MediaId { get; set; }
        public string PostId { get; set; }
        public string? LinkMedia { get; set; }
        public bool Status { get; set; }
    }
}
