﻿using BlogSystem.Services;
using BlogSystem.Web.Models.Posts;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.User.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IPostsService postsService;

        public UserController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.postsService.Create(model.Title, model.Content, model.Image, userId);

                return this.RedirectToAction("Index", "Posts", new { area = ""});
            }
            else
            {
                return this.RedirectToAction("AddPost");
            }
        }
    }
}