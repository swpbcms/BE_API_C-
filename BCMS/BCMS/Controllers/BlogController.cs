using BCMS.DTO;
using BCMS.DTO.Blog;
using BCMS.DTO.Category;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlog service;
        public BlogController(IBlog service)
        {
            this.service = service;
        }
        [Route("All-Blog")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.findAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("All-Blog-user")]
        [HttpGet]
        public async Task<IActionResult> GetAlluser()
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.blogForUser();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("Blog-id")]
        [HttpGet]
        public async Task<IActionResult> GetID(string Id)
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.find(Id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("Insert-blog")]
        [HttpPost]
        public async Task<IActionResult> Insert(BlogCreateDTO dto)
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
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

        [Route("Update-Blog")]
        [HttpPut]
        public async Task<IActionResult> update(BlogUpdateDTO dto)
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
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
        [Route("Blog-delete")]
        [HttpDelete]
        public async Task<IActionResult> deleteID(string Id)
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.delete(Id);
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
