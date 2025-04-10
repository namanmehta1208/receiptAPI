using System.ComponentModel.DataAnnotations;

namespace receiptAPI.Dtos
{
    public class ReceiptDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
