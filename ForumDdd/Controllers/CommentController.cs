﻿using Microsoft.AspNetCore.Mvc;

namespace ForumDdd.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
