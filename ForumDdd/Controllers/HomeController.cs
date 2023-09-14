using ForumDdd.Data;
using ForumDdd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ForumDdd.Controllers
{
    public class HomeController : Controller
    {
        ForumDddDbContext _context;

        public HomeController(ForumDddDbContext context)
        {
            _context = context;
        }

        public IActionResult Recently()
        {
            return View();
        }

        public IActionResult Popular()
        {
            return View();
        }

        public IActionResult WithoutAnswer()
        {
            return View();
        }
    }
}