using BCMS.DTO.Bird;
using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.DTO.BirdType;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdTypeController : ControllerBase
    {
        private IBirdType service;
        public BirdTypeController(IBirdType service)
        {
            this.service = service;
        }
        [Route("All-bird")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<BirdType>> responseAPI = new ResponseAPI<List<BirdType>>();
            try
            {
                responseAPI.Data = await this.service.GetAll();
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
            ResponseAPI<List<BirdType>> responseAPI = new ResponseAPI<List<BirdType>>();
            try
            {
                responseAPI.Data = await this.service.getbyId(id);
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
        public async Task<IActionResult> create(BirdTypeCreateDTO mem)
        {
            ResponseAPI<List<BirdType>> responseAPI = new ResponseAPI<List<BirdType>>();
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
        public async Task<IActionResult> update(BirdTypeUpdateDTO mem)
        {
            ResponseAPI<List<BirdType>> responseAPI = new ResponseAPI<List<BirdType>>();
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
            ResponseAPI<List<BirdType>> responseAPI = new ResponseAPI<List<BirdType>>();
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
