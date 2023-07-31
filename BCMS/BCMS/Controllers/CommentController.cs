using BCMS.DTO.Interact;
using BCMS.DTO;
using BCMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.Models;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IComment service;
        public CommentController(IComment service)
        {
            this.service = service;
        }

        [Route("comment")]
        [HttpPost]
        public async Task<IActionResult> comment(CommentDTO comment)
        {
            ResponseAPI<Comment> responseAPI = new ResponseAPI<Comment>();
            try
            {
                responseAPI.Data = await this.service.comment(comment);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("reply-comment")]
        [HttpPost]
        public async Task<IActionResult> replyComment(ReplyCommentDTO comment)
        {
            ResponseAPI<Comment> responseAPI = new ResponseAPI<Comment>();
            try
            {
                responseAPI.Data = await this.service.ReplyComment(comment);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-comment")]
        [HttpGet]
        public async Task<IActionResult> getComment()
        {
            ResponseAPI<List<Comment>> responseAPI = new ResponseAPI<List<Comment>>();
            try
            {
                responseAPI.Data = await this.service.GetComment();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-comment-user")]
        [HttpGet]
        public async Task<IActionResult> getCommentUser()
        {
            ResponseAPI<List<Comment>> responseAPI = new ResponseAPI<List<Comment>>();
            try
            {
                responseAPI.Data = await this.service.GetCommentUser();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-comment-post")]
        [HttpGet]
        public async Task<IActionResult> getCommentPost(string postid)
        {
            ResponseAPI<List<Comment>> responseAPI = new ResponseAPI<List<Comment>>();
            try
            {
                responseAPI.Data = await this.service.GetCommentPost(postid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-comment")]
        [HttpPut]
        public async Task<IActionResult> updateComment(updateCommentDTO comment)
        {
            ResponseAPI<Comment> responseAPI = new ResponseAPI<Comment>();
            try
            {
                responseAPI.Data = await this.service.updateComment(comment);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("delete-comment")]
        [HttpDelete]
        public async Task<IActionResult> deleteComment(string id)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.service.deleteComment(id);
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
