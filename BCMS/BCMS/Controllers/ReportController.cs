using BCMS.DTO;
using BCMS.DTO.Report;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReport service;
        public ReportController(IReport service)
        {
            this.service = service;
        }

        [Route("All-report")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.GetAllReports();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("report")]
        [HttpGet]
        public async Task<IActionResult> GetReport()
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.GetReports();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("member-report")]
        [HttpGet]
        public async Task<IActionResult> memberReport(string id)
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.GetReportsUser(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("create-report")]
        [HttpPost]
        public async Task<IActionResult> create(CreateReportDTO dto)
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.CreateReport(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("moderate-report")]
        [HttpPost]
        public async Task<IActionResult> moderate(updateReportDTO dto)
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.moderate(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("moderate-report-admin")]
        [HttpPost]
        public async Task<IActionResult> moderateadmin(reportAD ad)
        {
            ResponseAPI<List<Report>> responseAPI = new ResponseAPI<List<Report>>();
            try
            {
                responseAPI.Data = await this.service.moderateAdmin(ad);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
