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
            // Get the currently logged-in user's ID
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value;

            // Check if there are any transactions for the user
            var transactions = _context.PurchaseHistory
                .Where(p => p.UserId == userId)
                .ToList();

            if (transactions.Any())
            {
                // Display transactions
                return View(transactions);
            }
            else
            {
                // No transactions, display a message
                ViewBag.Message = "No transactions found.";
                return View();
            }
        }
    }
}
