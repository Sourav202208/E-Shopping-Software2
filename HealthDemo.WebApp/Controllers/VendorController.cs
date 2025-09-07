using Microsoft.AspNetCore.Mvc;

namespace HealthDemo.WebApp.Controllers
{
    public class VendorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
