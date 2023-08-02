namespace BCMS.DTO.Bird
{
    public class BirdUpdateDTO
    {
        public string BirdId { get; set; }
        public string BirdName { get; set; }
        public string MemberId { get; set; }
        public string BirdTypeId { get; set; }
        public string Image { get; set; }
        public decimal Size { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
    }
}
