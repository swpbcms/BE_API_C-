using BCMS.DTO.ReportType;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BCMS.Services
{
    public class ReportTypeService : IReportType
    {
        private readonly BCMSContext _context;
        public ReportTypeService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<ReportType> GetById(string id)
        {
            try
            {
                var check = await this._context.ReportType.Where(x=>x.ReportTypeId.Equals(id)).FirstOrDefaultAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ReportType>> GetByName(string name)
        {
            try
            {
                var check = await this._context.ReportType.Where(x => x.ReportTypeName.Contains(name)).ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ReportType>> GetList()
        {
            try
            {
                var check = await this._context.ReportType.ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReportType> Insert(CreateReportTypeDTO type)
        {
            try
            {
                var rpt = new ReportType();
                rpt.ReportTypeId = "RPT"+Guid.NewGuid().ToString().Substring(0,7);
                rpt.ReportTypeName = type.ReportTypeName;

                await this._context.ReportType.AddAsync(rpt);
                await this._context.SaveChangesAsync();

                return rpt;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReportType> Update(ReportTypeDTO type)
        {
            try
            {
                var check = await this._context.ReportType.Where(x => x.ReportTypeId.Equals(type.ReportTypeId)).FirstOrDefaultAsync();
                check.ReportTypeName = type.ReportTypeName;
                this._context.ReportType.Update(check);
                await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
