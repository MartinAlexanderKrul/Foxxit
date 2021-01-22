using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Domain.Uow;
using Foxxit.Attributes.RoleServices;
using Foxxit.Enums;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Foxxit.Controllers
{
    [Route("[controller]")]
    public class APIController : Controller
    {
        public APIController(ISubRedditService subRedditService, ICommentService commentService, IPostService postService)
        {
            PostService = postService;
            SubRedditService = subRedditService;
            CommentService = commentService;
        }

        public IPostService PostService { get; set; }
        public ISubRedditService SubRedditService { get; set; }
        public ICommentService CommentService { get; set; }

        [HttpPut("edit/post")]
        public async Task<ActionResult> EditPost([FromBody] EditPostBaseDTO dto)
        {
            var password = Environment.GetEnvironmentVariable("password-foxxit");

            if (password != dto.Password)
            {
                return StatusCode(400);
            }

            var post = await PostService.GetByIdAsync(dto.Id);

            dto.Title ??= post.Title;
            dto.ImageUrl ??= post.ImageURL;
            dto.Url ??= post.URL;
            dto.Text ??= post.Text;

            post.Title = dto.Title;
            post.ImageURL = dto.ImageUrl;
            post.URL = dto.Url;
            post.Text = dto.Text;

            PostService.Update(post);
            await PostService.SaveAsync();

            return StatusCode(200);
        }

        [HttpPut("edit/comment")]
        public async Task<ActionResult> EditComment([FromBody] EditPostBaseDTO dto)
        {
            var password = Environment.GetEnvironmentVariable("password-foxxit");

            if (password != dto.Password)
            {
                return StatusCode(400);
            }

            var comment = await CommentService.GetByIdAsync(dto.Id);

            comment.Text = dto.Text;

            CommentService.Update(comment);
            await CommentService.SaveAsync();

            return StatusCode(200);
        }

        [HttpPut("edit/subreddit")]
        public async Task<ActionResult> EditSubReddit([FromBody] EditSubRedditDTO dto)
        {
            var password = Environment.GetEnvironmentVariable("password-foxxit");

            if (password != dto.Password)
            {
                return StatusCode(400);
            }

            var subReddit = await SubRedditService.GetByIdAsync(dto.Id);

            dto.Name ??= subReddit.Name;
            dto.About ??= subReddit.About;

            subReddit.Name = dto.Name;
            subReddit.About = dto.About;

            SubRedditService.Update(subReddit);
            await SubRedditService.SaveAsync();

            return StatusCode(200);
        }

        [HttpGet("comments")]
        public async Task<ActionResult> GetAllComments()
        {
            var comments = await CommentService.GetAllAsync();
            var result = new List<CommentToSendDTO>();

            foreach (var comment in comments)
            {
                result.Add(new CommentToSendDTO(comment.Id, comment.UserId, comment.Text));
            }

            return Json(new { result });
        }
    }
}