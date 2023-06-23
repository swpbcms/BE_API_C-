using BCMS.DTO;
using BCMS.DTO.Category;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategory service;
        public CategoryController(ICategory service)
        {
            this.service = service;
        }

        [Route("All-Category")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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

        [Route("Name-Category")]
        [HttpGet]
        public async Task<IActionResult> GetName(string name)
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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

        [Route("ID-Category")]
        [HttpGet]
        public async Task<IActionResult> GetID(string id)
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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

        [Route("Insert-Category")]
        [HttpPost]
        public async Task<IActionResult> Insert(CategoryDTO dto)
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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

        [Route("Update-Category")]
        [HttpPut]
        public async Task<IActionResult> update(updateCategoryDTO dto)
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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
