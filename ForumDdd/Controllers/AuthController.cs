using ForumDdd.Data;
using ForumDdd.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDdd.Controllers
{
    public class AuthController : Controller
    {

        ForumDddDbContext _context;
        public AuthController(ForumDddDbContext context)
        {
            _context = context;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Recently", "Home");
        }

    }
}
