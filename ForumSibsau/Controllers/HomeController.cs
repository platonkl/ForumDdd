using ForumSibsau.Areas.Identity.Data;
using ForumSibsau.Data;
using ForumSibsau.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForumSibsau.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ForumSibsauDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ForumSibsauDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        //public async Task<List<Post>> GetCurrentUserPostsAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var posts = _context.Posts
        //        .Where(p => p.UserId == user.Id)
        //        .OrderByDescending(p => p.ResponsesCount)
        //        .Take(4)
        //        .ToList();
        //    return posts;
        //}

        public IActionResult Recently()
        {
            //var postsOwn = GetCurrentUserPostsAsync().Result;
            //ViewData["CurrentUserPosts"] = postsOwn;
            var posts = _context.Posts
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount, CreatedAt = p.CreatedAt })
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
            return View(posts);
        }

        public IActionResult Popular()
        {
            //var postsOwn = GetCurrentUserPostsAsync().Result;
            //ViewData["CurrentUserPosts"] = postsOwn;
            var posts = _context.Posts
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount })
                .OrderByDescending(p => p.ResponsesCount)
                .ToList();
            return View(posts);
        }

        public IActionResult WithoutAnswer()
        {
            //var postsOwn = GetCurrentUserPostsAsync().Result;
            //ViewData["CurrentUserPosts"] = postsOwn;
            var posts = _context.Posts
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount })
                .OrderBy(p => p.ResponsesCount)
                .ToList();
            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}