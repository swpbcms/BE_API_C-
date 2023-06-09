﻿using BCMS.DTO.Category;
using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCMS.DTO.Post;

namespace BCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPost service;
        public PostController(IPost service)
        {
            this.service = service;
        }

        [Route("create-post")]
        [HttpPost]
        public async Task<IActionResult> crete(CreatePostDTO dto)
        {
            ResponseAPI<Post> responseAPI = new ResponseAPI<Post>();
            try
            {
                responseAPI.Data = await this.service.CreatePost(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-post")]
        [HttpGet]
        public async Task<IActionResult> get()
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.GetPost();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-postuser")]
        [HttpGet]
        public async Task<IActionResult> getPost()
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.GetPostUser();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-postuser")]
        [HttpGet]
        public async Task<IActionResult> search(string search)
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.searchPost(search);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-postManager")]
        [HttpGet]
        public async Task<IActionResult> searchManager()
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.searchPostManager();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-post")]
        [HttpPut]
        public async Task<IActionResult> update(updatePostDTO dto)
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.UpdatePost(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("detele-post")]
        [HttpDelete]
        public async Task<IActionResult> detele(string id)
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.DeletePost(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("moderate-post")]
        [HttpPut]
        public async Task<IActionResult> modeeate(string id, bool option, string managerID)
        {
            ResponseAPI<List<Post>> responseAPI = new ResponseAPI<List<Post>>();
            try
            {
                responseAPI.Data = await this.service.moderate(id,option,managerID);
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
