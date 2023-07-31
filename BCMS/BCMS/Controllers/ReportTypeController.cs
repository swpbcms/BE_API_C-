using BCMS.DTO;
using BCMS.DTO.Category;
using BCMS.DTO.ReportType;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : ControllerBase
    {
        private IReportType service;
        public ReportTypeController(IReportType service)
        {
            this.service = service;
        }

        [Route("All-type")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<ReportType>> responseAPI = new ResponseAPI<List<ReportType>>();
            try
            {
                responseAPI.Data = await this.service.GetList();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Name-type")]
        [HttpGet]
        public async Task<IActionResult> GetName(string name)
        {
            ResponseAPI<List<ReportType>> responseAPI = new ResponseAPI<List<ReportType>>();
            try
            {
                responseAPI.Data = await this.service.GetByName(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("ID-type")]
        [HttpGet]
        public async Task<IActionResult> GetID(string id)
        {
            ResponseAPI<List<ReportType>> responseAPI = new ResponseAPI<List<ReportType>>();
            try
            {
                responseAPI.Data = await this.service.GetById(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Insert-Type")]
        [HttpPost]
        public async Task<IActionResult> Insert(CreateReportTypeDTO dto)
        {
            ResponseAPI<List<ReportType>> responseAPI = new ResponseAPI<List<ReportType>>();
            try
            {
                responseAPI.Data = await this.service.Insert(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Update-type")]
        [HttpPut]
        public async Task<IActionResult> update(ReportTypeDTO dto)
        {
            ResponseAPI<List<ReportType>> responseAPI = new ResponseAPI<List<ReportType>>();
            try
            {
                responseAPI.Data = await this.service.Update(dto);
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
