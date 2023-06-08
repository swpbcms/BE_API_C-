using BCMS.DTO;
using BCMS.DTO.Media;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IMedia service;
        public MediaController(IMedia service)
        {
            this.service = service;
        }

        [Route("All-media")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string postID)
        {
            ResponseAPI<List<Media>> responseAPI = new ResponseAPI<List<Media>>();
            try
            {
                responseAPI.Data = await this.service.geMediaPost(postID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("create-media")]
        [HttpPost]
        public async Task<IActionResult> create(MediaDTO dto)
        {
            ResponseAPI<List<Media>> responseAPI = new ResponseAPI<List<Media>>();
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
        [Route("update-media")]
        [HttpPut]
        public async Task<IActionResult> update(MediaDTO dto)
        {
            ResponseAPI<List<Media>> responseAPI = new ResponseAPI<List<Media>>();
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
        [Route("delete-media")]
        [HttpPost]
        public async Task<IActionResult> delete(string id)
        {
            ResponseAPI<List<Media>> responseAPI = new ResponseAPI<List<Media>>();
            try
            {
                responseAPI.Data = await this.service.delete(id);
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
