using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Interact
{
    public class CommentDTO
    {
        public string MemberId { get; set; }
        public string PostId { get; set; }
        public string CommentContent { get; set; }
    }
}
