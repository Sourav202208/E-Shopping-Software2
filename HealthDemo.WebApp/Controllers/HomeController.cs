using HealthDemo.Data.ModelDbContext;
using HealthDemo.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthDemo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDb _db;
        public HomeController( ApplicationDb db)
        {
     
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

    
    }
}