using ForumSibsau.Areas.Identity.Data;
using ForumSibsau.Data;
using ForumSibsau.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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

        public async Task<List<Post>> GetCurrentUserPostsAsync(ClaimsPrincipal user)
        {
            if (user == null)
            {
                // пользователь не залогинен, возвращаем пустой список
                return new List<Post>();
            }

            var currentUser = await _userManager.GetUserAsync(user);
            var posts = _context.Posts
                .Where(p => p.UserId == currentUser.Id)
                .OrderByDescending(p => p.ResponsesCount)
                .Take(4)
                .AsEnumerable()
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount, CreatedAt = p.CreatedAt })
                .ToList();
            return posts;
        }

        public async Task<IActionResult> Recently()
        {
            var user = User;
            if (User.Identity.IsAuthenticated)
            {
                var postsOwn = await GetCurrentUserPostsAsync(user);
                ViewData["CurrentUserPosts"] = postsOwn;
            }
            var posts = _context.Posts
                .AsEnumerable()
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount, CreatedAt = p.CreatedAt })
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            if (posts.Count == 0)
            {
                return View("NoPostsFound");
            }

            return View(posts);
        }

        public async Task<IActionResult> Popular()
        {
            var user = User;
            if (User.Identity.IsAuthenticated)
            {
                var postsOwn = await GetCurrentUserPostsAsync(user);
                ViewData["CurrentUserPosts"] = postsOwn;
            }
            var posts = _context.Posts
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount })
                .OrderByDescending(p => p.ResponsesCount)
                .ToList();
            if (posts.Count == 0)
            {
                return View("NoPostsFound");
            }
            return View(posts);
        }

        public async Task<IActionResult> WithoutAnswer()
        {
            var user = User;
            if (User.Identity.IsAuthenticated)
            {
                var postsOwn = await GetCurrentUserPostsAsync(user);
                ViewData["CurrentUserPosts"] = postsOwn;
            }
            var posts = _context.Posts
                .Select(p => new Post { Title = p.Title, ResponsesCount = p.ResponsesCount })
                .OrderBy(p => p.ResponsesCount)
                .ToList();
            if (posts.Count == 0)
            {
                return View("NoPostsFound");
            }
            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}