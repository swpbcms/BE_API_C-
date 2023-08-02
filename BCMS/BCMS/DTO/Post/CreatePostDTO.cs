using BCMS.DTO.Category;
using BCMS.DTO.Media;

namespace BCMS.DTO.Post
{
    public class CreatePostDTO
    {
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public bool PostIsEvent { get; set; }
        public string EventLocation { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string MemberId { get; set; }
        public List<CategoryEventDTO>? categories { get; set; }
        public List<BirdTypeEventDTO>? birdTypes { get; set; }
        public List<MediaCreateDTO>? media { get; set; }

    }
}
