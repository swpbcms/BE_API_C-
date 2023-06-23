using BCMS.DTO;
using BCMS.DTO.ProcessEvent;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessEventController : ControllerBase
    {
        private IProcessEvent service;
        public ProcessEventController(IProcessEvent service)
        {
            this.service = service;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> get()
        {
            ResponseAPI<List<ProcessEvent>> responseAPI = new ResponseAPI<List<ProcessEvent>>();
            try
            {
                responseAPI.Data = await this.service.getall();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-for-post")]
        [HttpGet]
        public async Task<IActionResult> getForPost(string postid)
        {
            ResponseAPI<List<ProcessEvent>> responseAPI = new ResponseAPI<List<ProcessEvent>>();
            try
            {
                responseAPI.Data = await this.service.getForPost(postid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("create-process")]
        [HttpPost]
        public async Task<IActionResult> create(ProcessEventDTO dto)
        {
            ResponseAPI<List<ProcessEvent>> responseAPI = new ResponseAPI<List<ProcessEvent>>();
            try
            {
                responseAPI.Data = await this.service.create(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-process")]
        [HttpPut]
        public async Task<IActionResult> update(ProcessEventDTO dto)
        {
            ResponseAPI<List<ProcessEvent>> responseAPI = new ResponseAPI<List<ProcessEvent>>();
            try
            {
                responseAPI.Data = await this.service.update(dto);
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
