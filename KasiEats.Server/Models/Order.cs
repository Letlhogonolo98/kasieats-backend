using System.ComponentModel.DataAnnotations;

namespace KasiEats.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public string CustomerName { get; set; } 

        [Required]
        public string OrderDetails { get; set; } 

        [Required]
        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending"; 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}