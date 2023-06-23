using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Post
{
    public class PostDTO
    {
        public string PostId { get; set; }
        public DateTime PostCreateAt { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public bool PostIsEvent { get; set; }
        public string PostStatus { get; set; }
        public int PostNumberLike { get; set; }
        public int PostNumberJoin { get; set; }
        public string EventLocation { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string MemberId { get; set; }
        public string ManagerId { get; set; }
    }
}
