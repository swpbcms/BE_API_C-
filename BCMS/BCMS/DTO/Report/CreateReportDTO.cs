namespace BCMS.DTO.Report
{
    public class CreateReportDTO
    {
        public string ReportTitle { get; set; }
        public string MemberId { get; set; }
        public string ReportType { get; set; }
        public string ReportDescription { get; set; }
        public string? PosId { get; set; }
    }
}
