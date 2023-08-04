using BCMS.DTO;
using BCMS.DTO.Bird;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private IBird service;
        public BirdController(IBird service)
        {
            this.service = service;
        }
        [Route("All-bird")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
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
        [Route("id-bird")]
        [HttpGet]
        public async Task<IActionResult> Getid(string id)
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.getById(id);
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
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.listBirdMember(mem);
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
        public async Task<IActionResult> create(BirdCreateDTO mem)
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.createBird(mem);
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
        public async Task<IActionResult> update(BirdUpdateDTO mem)
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.updateBird(mem);
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
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
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
