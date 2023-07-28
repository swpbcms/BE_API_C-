using BCMS.DTO.Report;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IReport
    {
        Task<Report> CreateReport(CreateReportDTO dto);
        Task<Report> moderate(updateReportDTO dto);
        Task<Report> moderateAdmin(reportAD ad);
        Task<List<Report>> GetReports();
        Task<List<Report>> GetAllReports();
        Task<List<Report>> GetReportsUser(string id);
    }
}
