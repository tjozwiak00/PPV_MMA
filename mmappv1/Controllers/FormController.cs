using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmappv1.Data;
using mmappv1.Models;
using System.Diagnostics;

namespace mmappv1.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PurchasePPV([FromForm] ModelZakup model)
        {
            
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var zakup = new Zakup
                    {
                        FullName = model.fullName,
                        CardNumber = model.cardNumber,
                        ExpirationDate = model.expirationDate,
                        Cvv = model.cvv
                    };

                    dbContext.Zakups.Add(zakup);
                    await dbContext.SaveChangesAsync();
                }
                return RedirectToAction("KartaWalk", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas przetwarzania żądania.");
                Debug.WriteLine(ex.Message);
                return View(model);
            }
        }
    }
}
