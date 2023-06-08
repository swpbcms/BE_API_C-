namespace BCMS.DTO.Post
{
    public class updatePostDTO
    {
        public string PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public bool PostIsEvent { get; set; }
        public string? EventLocation { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string MemberId { get; set; }
    }
}
