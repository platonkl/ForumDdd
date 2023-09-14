using ForumDdd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForumDdd.Controllers
{
    public class HomeController : Controller
    {
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