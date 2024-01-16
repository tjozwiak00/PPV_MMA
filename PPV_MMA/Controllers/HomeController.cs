using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PPV_MMA.Models;
using System.Diagnostics;

namespace PPV_MMA.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            // Logika przeglądania dostępnych walk
            return View();
        }

        public IActionResult PurchaseHistory()
        {
            // Logika historii zakupów
            return View();
        }

        [HttpGet]
        public IActionResult PurchasePPV()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PurchasePPV(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userModel.Email,
                    Email = userModel.Email,
                    FullName = userModel.FullName
                    // Dodaj inne właściwości użytkownika
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Zapisz dane zakupu do historii
                    return RedirectToAction("PurchaseHistory");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userModel);
        }
    }
}