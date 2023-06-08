using BCMS.DTO.Category;
using BCMS.DTO.ReportType;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IReportType
    {
        Task<List<ReportType>> GetList();
        Task<ReportType> GetById(string id);
        Task<List<ReportType>> GetByName(string name);
        Task<ReportType> Insert(CreateReportTypeDTO type);
        Task<ReportType> Update(ReportTypeDTO type);
    }
}
