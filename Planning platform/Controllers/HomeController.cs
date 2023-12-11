using Microsoft.AspNetCore.Mvc;
using Planning_platform.Models;
using System.Diagnostics;

namespace Planning_platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Lessons");
            }
            else
            {
                return Redirect("~/Identity/Account/Login");
            }
            //return RedirectToAction(nameof(LessonsController.Index));
            //return View("Index","Lessons");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}