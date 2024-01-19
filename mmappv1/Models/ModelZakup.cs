namespace mmappv1.Models
{
    public class ModelZakup
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? fullName { get; set; }
        public string? cardNumber { get; set; }
        public string? expirationDate { get; set; }
        public string? cvv { get; set; }
    }
}
