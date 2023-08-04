using BCMS.DTO.Report;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class ReportService : IReport
    {
        private readonly BCMSContext _context;
        public ReportService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Report> CreateReport(CreateReportDTO dto)
        {
            try
            {
                var report = new Report();

                report.MemberId= dto.MemberId;
                report.ReportId = "REPT"+Guid.NewGuid().ToString().Substring(0,6);
                report.ReportDescription = dto.ReportDescription;
                report.ReportType = dto.ReportType;
                report.DateTime = DateTime.Now;
                report.ReportStatus = false;
                report.ReportTitle = dto.ReportTitle;
                report.PostId = dto.PosId;
                
                await this._context.AddAsync(report);
                await this._context.SaveChangesAsync();

                var noti = new Notification();

                noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                noti.MemberId = dto.MemberId;
                noti.NotificationDateTime = DateTime.Now;
                noti.NotificationTitle = "Report";
                noti.NotificationContent = "Đơn của bạn đã được gửi thành công " + report.ReportId;
                noti.NotificationStatus = true;

                await this._context.Notification.AddAsync(noti);
                await this._context.SaveChangesAsync();

                return report;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Report>> GetAllReports()
        {
            try
            {
                var check = await this._context.Report
                    .Include(x=>x.Post)
                        .ThenInclude(x=>x.Media)
                    .ToListAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Report>> GetReports()
        {
            try
            {
                var check = await this._context.Report.Where(x=>x.ReportStatus==false)
                    .Include(x => x.Post)
                        .ThenInclude(x => x.Media)
                    .ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Report>> GetReportsUser(string id)
        {
            try
            {
                var check = await this._context.Report.Where(x => x.MemberId.Equals(id))
                    .Include(x => x.Post)
                        .ThenInclude(x => x.Media)
                    .ToListAsync();
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Report> moderate(updateReportDTO dto)
        {
            try
            {
                var mng = await this._context.Manager.Where(x=>x.ManagerId.Equals(dto.ManagerId)).FirstOrDefaultAsync();
                if (mng == null)
                {
                    throw new Exception("Manager moderate");
                }
                var check = await this._context.Report.Where(x=>x.ReportId.Equals(dto.ReportId)).FirstOrDefaultAsync();
                check.ManagerId = dto.ManagerId;
                check.Reply = dto.Reply;
                check.ReportStatus = true;
                this._context.Update(check);

                await this._context.SaveChangesAsync();

                var noti = new Notification();

                noti.NotificationId = "NOTI" + Guid.NewGuid().ToString().Substring(0, 6);
                noti.MemberId = check.MemberId;
                noti.NotificationDateTime = DateTime.Now;
                noti.NotificationTitle = "moderate report";
                noti.NotificationContent = "Đơn của bạn đã được xem xét";
                noti.NotificationStatus = true;

                await this._context.Notification.AddAsync(noti);
                await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Report> moderateAdmin(reportAD ad)
        {
            try
            {
                var check = await this._context.Report.Where(x=>x.ReportId.Equals(ad.reportID)).FirstOrDefaultAsync();
                if(check!=null)
                {
                    check.Reply = ad.Reply;
                }
                this._context.Report.Update(check); await this._context.SaveChangesAsync();
                return check;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
