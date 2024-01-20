using System.ComponentModel.DataAnnotations;

namespace MVP.Models
{
    public class History
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required]
        public string? UserName { get; set; }
        [Display(Name = "Imię i Nazwisko")]
        [Required]
        public string? FullName { get; set; }
        [Display(Name = "Numer karty")]
        [Required]
        public string? cardNumber { get; set; }
        [Display(Name = "Data ważności")]
        [Required]
        public string? expirationDate { get; set; }
        [Display(Name = "Kod CVV")]
        [Required]
        public string? cvv { get; set; }
        public DateTime? Data { get; set; }
    }
}
