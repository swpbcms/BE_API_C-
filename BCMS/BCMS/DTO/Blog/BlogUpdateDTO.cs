using BCMS.DTO.Media;

namespace BCMS.DTO.Blog
{
    public class BlogUpdateDTO
    {
        public string BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public bool Status { get; set; }
        public List<MediaCreateDTO>? media { get; set; }
    }
}
