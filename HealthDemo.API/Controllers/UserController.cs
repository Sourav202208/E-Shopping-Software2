using Microsoft.AspNetCore.Mvc;

namespace HealthDemo.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
