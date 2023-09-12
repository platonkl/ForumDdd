using ForumDdd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForumDdd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Recently.cshtml");
        }

        public IActionResult Popular()
        {
            return View("~/Views/Home/Popular.cshtml");
        }

        public IActionResult WithoutAnswer()
        {
            return View("~/Views/Home/WithoutAnswear.cshtml");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}