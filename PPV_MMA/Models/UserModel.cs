using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PPVMMA.Models
{
    public class UserModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        // Dodaj inne potrzebne właściwości użytkownika
    }
}


