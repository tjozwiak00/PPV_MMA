
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
    public class ModelZakupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelZakupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModelZakup
        public async Task<IActionResult> Index()
        {
              return _context.ModelZakup != null ? 
                          View(await _context.ModelZakup.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ModelZakup'  is null.");
        }

        // GET: ModelZakup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelZakup == null)
            {
                return NotFound();
            }

            var modelZakup = await _context.ModelZakup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelZakup == null)
            {
                return NotFound();
            }

            return View(modelZakup);
        }

        // GET: ModelZakup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelZakup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,fullName,cardNumber,expirationDate,cvv")] ModelZakup modelZakup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelZakup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelZakup);
        }

        // GET: ModelZakup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelZakup == null)
            {
                return NotFound();
            }

            var modelZakup = await _context.ModelZakup.FindAsync(id);
            if (modelZakup == null)
            {
                return NotFound();
            }
            return View(modelZakup);
        }

        // POST: ModelZakup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,fullName,cardNumber,expirationDate,cvv")] ModelZakup modelZakup)
        {
            if (id != modelZakup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelZakup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelZakupExists(modelZakup.Id))
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
            return View(modelZakup);
        }

        // GET: ModelZakup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelZakup == null)
            {
                return NotFound();
            }

            var modelZakup = await _context.ModelZakup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelZakup == null)
            {
                return NotFound();
            }

            return View(modelZakup);
        }

        // POST: ModelZakup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelZakup == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModelZakup'  is null.");
            }
            var modelZakup = await _context.ModelZakup.FindAsync(id);
            if (modelZakup != null)
            {
                _context.ModelZakup.Remove(modelZakup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelZakupExists(int id)
        {
          return (_context.ModelZakup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
