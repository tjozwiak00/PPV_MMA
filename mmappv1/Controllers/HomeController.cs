using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mmappv1.Models;
using System.Diagnostics;

namespace mmappv1.Controllers
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
            return View();
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

        public IActionResult KupPPV()
        {
            return View();
        }

        public IActionResult HistoriaZakupow()
        {
            return View();
        }

        public IActionResult KartaWalk()
        {
            return View();
        }
    }

}