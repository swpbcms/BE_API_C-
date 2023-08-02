using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Post
{
    public class CreateBirdEventDTO
    {
        public string Bird1 { get; set; }
        public string Bird2 { get; set; }
        public int? Bird1Score { get; set; }
        public int? Bird2Score { get; set; }
        public string? Winner { get; set; }
        public DateTime EventDate { get; set; }
        public string PostId { get; set; }
    }
}
