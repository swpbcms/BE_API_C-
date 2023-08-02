using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BCMS.DTO.Media;

namespace BCMS.DTO.Blog
{
    public class BlogCreateDTO
    {
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string ManagerId { get; set; }
        public List<MediaCreateDTO>? media { get; set; }
    }
}
