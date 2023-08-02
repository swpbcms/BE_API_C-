using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Interact
{
    public class JoinEventDTO
    {
        public string MemberId { get; set; }
        public string PostId { get; set; }
        public string BirdId { get; set; }
        public bool? IsFollow { get; set; }
        public bool Status { get; set; }
    }
}
