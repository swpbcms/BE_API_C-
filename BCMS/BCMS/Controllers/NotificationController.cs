using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotification service;
        public NotificationController(INotification service)
        {
            this.service = service;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> get()
        {
            ResponseAPI<List<Notification>> responseAPI = new ResponseAPI<List<Notification>>();
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

        [Route("get-noti-user")]
        [HttpGet]
        public async Task<IActionResult> getUser(string memberId)
        {
            ResponseAPI<List<Notification>> responseAPI = new ResponseAPI<List<Notification>>();
            try
            {
                responseAPI.Data = await this.service.GetNotificationAsync(memberId);
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
