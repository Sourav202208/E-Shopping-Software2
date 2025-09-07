using Microsoft.AspNetCore.Mvc;

namespace HealthDemo.WebApp.Controllers
{
    public class IteamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
