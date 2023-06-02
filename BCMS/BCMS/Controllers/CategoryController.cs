using BCMS.DTO;
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

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
