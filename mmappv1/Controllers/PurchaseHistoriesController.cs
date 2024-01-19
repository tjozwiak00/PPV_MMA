using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mmappv1.Data;
using mmappv1.Models;

namespace mmappv1.Controllers
{
    public class PurchaseHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseHistories
        public async Task<IActionResult> Index()
        {
              return _context.PurchaseHistory != null ? 
                          View(await _context.PurchaseHistory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PurchaseHistory'  is null.");
        }

        // GET: PurchaseHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchaseHistory == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,fullName")] PurchaseHistory purchaseHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchaseHistory == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }
            return View(purchaseHistory);
        }

        // POST: PurchaseHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,fullName")] PurchaseHistory purchaseHistory)
        {
            if (id != purchaseHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseHistoryExists(purchaseHistory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseHistory);
        }

        // GET: PurchaseHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchaseHistory == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // POST: PurchaseHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchaseHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PurchaseHistory'  is null.");
            }
            var purchaseHistory = await _context.PurchaseHistory.FindAsync(id);
            if (purchaseHistory != null)
            {
                _context.PurchaseHistory.Remove(purchaseHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseHistoryExists(int id)
        {
          return (_context.PurchaseHistory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
