using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVP.Data;
using MVP.Models;

namespace MVP.Controllers
{
    [Authorize]
    public class HistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            string currentUsername = User.Identity.Name;
            if (_context.History.Any(h => h.UserName == currentUsername))
            {
                ViewBag.Alert = "true";
            }
            var userHistory = await _context.History
                .Where(h => h.UserName == currentUsername)
                .ToListAsync();
            if (userHistory.Count > 0)
            {
                ViewBag.userHistory = "true";
            }

            return View(userHistory);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            string currentUsername = User.Identity.Name;
            if (_context.History.Any(h => h.UserName == currentUsername))
            {
                ViewBag.Alert = "true";
            }
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,FullName,cardNumber,expirationDate,cvv,Data")] History history)
        {
            string currentUsername = User.Identity.Name;
            if (_context.History.Any(h => h.UserName == currentUsername))
            {
                ViewBag.Alert = "true";
            }
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(history);
        }

        private bool HistoryExists(int id)
        {
            return _context.History.Any(e => e.ID == id);
        }
    }
}
