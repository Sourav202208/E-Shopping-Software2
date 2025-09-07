using Microsoft.AspNetCore.Mvc;

namespace HealthDemo.WebApp.Controllers
{
    public class EmployeeController1 : Controller
    {
        public IActionResult Index()
        {
             string message=string.Empty;
            return View();
        }
    }
}
