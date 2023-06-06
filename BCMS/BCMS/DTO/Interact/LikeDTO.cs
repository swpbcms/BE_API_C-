using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Interact
{
    public class LikeDTO
    {
        public string MemberId { get; set; }
        public string PostId { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
