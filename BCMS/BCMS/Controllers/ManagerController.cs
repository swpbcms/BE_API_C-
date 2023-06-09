using BCMS.DTO.Member;
using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.DTO.Manager;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManager service;
        public ManagerController(IManager service)
        {
            this.service = service;
        }

        [Route("All-Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
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
        [Route("Name-Manager")]
        [HttpGet]
        public async Task<IActionResult> GetName(string name)
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
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

        [Route("ID-Member")]
        [HttpGet]
        public async Task<IActionResult> GetID(string id)
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
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

        [Route("login-Member")]
        [HttpPost]
        public async Task<IActionResult> Login(ManagerLoginDTO dto)
        {
            ResponseAPI<Manager> responseAPI = new ResponseAPI<Manager>();
            try
            {
                responseAPI.Data = await this.service.Login(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Register-Member")]
        [HttpPost]
        public async Task<IActionResult> Insert(ManagerCreateDTO dto)
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
            try
            {
                responseAPI.Data = await this.service.Register(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("Update-member")]
        [HttpPut]
        public async Task<IActionResult> update(ManagerUpdateDTO dto)
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
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

        [Route("Delete-member")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            ResponseAPI<List<Manager>> responseAPI = new ResponseAPI<List<Manager>>();
            try
            {
                responseAPI.Data = await this.service.DeleteByID(id);
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
