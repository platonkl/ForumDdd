using Microsoft.AspNetCore.Mvc;

namespace ForumDdd.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
