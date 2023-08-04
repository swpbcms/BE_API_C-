using BCMS.DTO.Bird;
using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.DTO.Post;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdEventController : ControllerBase
    {
        private IBirdEvent service;
        public BirdEventController(IBirdEvent service)
        {
            this.service = service;
        }
        [Route("All-bird")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.getAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("getAllBirdEventPost")]
        [HttpGet]
        public async Task<IActionResult> Getid(string id)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.getAllBirdEventPost(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("rank")]
        [HttpGet]
        public async Task<IActionResult> rank(string id)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.rank(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("birdjoinev")]
        [HttpGet]
        public async Task<IActionResult> birdjoinev(string id)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.birdjoinev(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("All-bird-mem")]
        [HttpGet]
        public async Task<IActionResult> GetAllmem(string mem)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.getAllBirdEventUser(mem);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> create(CreateBirdEventDTO mem)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.create(mem);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> update(UpdateBirdEventDTO mem)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.update(mem);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> delete(string mem)
        {
            ResponseAPI<List<BirdEvent>> responseAPI = new ResponseAPI<List<BirdEvent>>();
            try
            {
                responseAPI.Data = await this.service.delete(mem);
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
