using System.ComponentModel.DataAnnotations;

namespace KasiEats.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } 

        public string Description { get; set; }
        public string? LogoUrl { get; set; }
    }
}