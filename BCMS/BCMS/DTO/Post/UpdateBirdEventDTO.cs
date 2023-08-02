namespace BCMS.DTO.Post
{
    public class UpdateBirdEventDTO
    {
        public string BirdEventId { get; set; }
        public string? Bird1 { get; set; }
        public string? Bird2 { get; set; }
        public int? Bird1Score { get; set; }
        public int? Bird2Score { get; set; }
        public string? Winner { get; set; }
        
    }
}
