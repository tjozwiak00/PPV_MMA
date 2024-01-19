using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mmappv1.Models;

namespace mmappv1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ensure that your DbSet properties are initialized
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; } = null!;
        // Add similar initialization for other DbSet properties if applicable
    }

}