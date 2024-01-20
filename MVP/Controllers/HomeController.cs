using Microsoft.AspNetCore.Mvc;
using MVP.Data;
using MVP.Models;
using System.Diagnostics;

namespace MVP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string currentUsername = User.Identity.Name;
            if (_context.History.Any(h => h.UserName == currentUsername))
            {
                ViewBag.Alert = "true";
            }
            return View();
        }

        public IActionResult KartaWalk()
        {
            string currentUsername = User.Identity.Name;
            if (_context.History.Any(h => h.UserName == currentUsername))
            {
                ViewBag.Alert = "true";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
