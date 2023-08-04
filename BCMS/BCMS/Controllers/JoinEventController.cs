using BCMS.DTO.Interact;
using BCMS.DTO;
using BCMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.Models;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinEventController : ControllerBase
    {
        private IJoinEvent service;
        public JoinEventController(IJoinEvent service)
        {
            this.service = service;
        }

        [Route("get")]
        [HttpPost]
        public async Task<IActionResult> get(string like)
        {
            ResponseAPI<List<JoinEvent>> responseAPI = new ResponseAPI<List<JoinEvent>>();
            try
            {
                responseAPI.Data = await this.service.get(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("birdJoin")]
        [HttpPost]
        public async Task<IActionResult> birdJoin(BirdJoin like)
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.birdJoin(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("manager")]
        [HttpPost]
        public async Task<IActionResult> manager(JoinEventDTO like)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.manager(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Join")]
        [HttpPost]
        public async Task<IActionResult> Join(JoinEventDTO like)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.Join(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Follow")]
        [HttpPost]
        public async Task<IActionResult> Follow(JoinEventDTO like)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.Follow(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("UnJoin")]
        [HttpPut]
        public async Task<IActionResult> UnJoin(JoinEventDTO like)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.DisJoin(like);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("UnFollow")]
        [HttpPut]
        public async Task<IActionResult> UnFollow(JoinEventDTO like)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.UnFollow(like);
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
