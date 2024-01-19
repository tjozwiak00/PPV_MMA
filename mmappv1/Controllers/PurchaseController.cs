using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mmappv1.Data;
using mmappv1.Models;
using System.Diagnostics;


namespace mmappv1.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PurchaseHistory()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value;

            var transactions = _context.PurchaseHistory
                .Where(p => p.UserId == userId)
                .ToList();

            if (transactions.Any())
            {
                return View(transactions);
            }
            else
            {
                ViewBag.Message = "No transactions found.";
                return View();
            }
        }
    }
}
