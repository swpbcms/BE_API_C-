using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Report
{
    public class ReportDTO
    {
        public string ReportId { get; set; }
        public string ReportTitle { get; set; }
        public string? ManagerId { get; set; }
        public string MemberId { get; set; }
        public string ReportType { get; set; }
        public bool ReportStatus { get; set; }
        public string ReportDescription { get; set; }
        public DateTime DateTime { get; set; }
        public string? Reply { get; set; }
    }
}
