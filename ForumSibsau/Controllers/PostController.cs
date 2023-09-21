using ForumSibsau.Areas.Identity.Data;
using ForumSibsau.Data;
using ForumSibsau.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumSibsau.Controllers
{
    public class PostController : Controller
    {

        private readonly ForumSibsauDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(ForumSibsauDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            post.ResponsesCount = 7;
            post.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Recently", "Home");
            
        }

    }
}
