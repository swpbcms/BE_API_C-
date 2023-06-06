using BCMS.DTO;
using BCMS.DTO.Category;
using BCMS.DTO.Member;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMember service;
        public MemberController(IMember service)
        {
            this.service = service;
        }

        [Route("All-Member")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
        [Route("Name-Member")]
        [HttpGet]
        public async Task<IActionResult> GetName(string name)
        {
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
        public async Task<IActionResult> Login(MemberLoginDTO dto)
        {
            ResponseAPI<Member> responseAPI = new ResponseAPI<Member>();
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
        public async Task<IActionResult> Insert(MemberRegisterDTO dto)
        {
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
        public async Task<IActionResult> update(updateMemberDTO dto)
        {
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
            ResponseAPI<List<Member>> responseAPI = new ResponseAPI<List<Member>>();
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
