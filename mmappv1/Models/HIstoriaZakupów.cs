using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace mmappv1.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
    }
}
