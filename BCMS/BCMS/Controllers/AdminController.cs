using BCMS.DTO;
using BCMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdmin _Service;
        public AdminController(IAdmin Service)
        {
            this._Service = Service;
        }

        [Route("login-admin")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            ResponseAPI<List<Admin>> responseAPI = new ResponseAPI<List<Admin>>();
            try
            {
                responseAPI.Data =  this._Service.login(username,password);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-admin")]
        [HttpPost]
        public async Task<IActionResult> update(string username, string password, string newPass)
        {
            ResponseAPI<List<Admin>> responseAPI = new ResponseAPI<List<Admin>>();
            try
            {
                responseAPI.Data = this._Service.update(username, password, newPass);
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
