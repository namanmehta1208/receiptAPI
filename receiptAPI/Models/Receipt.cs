namespace receiptAPI.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public required string Description { get; set; }
        public required string FilePath { get; set; }
        public DateTime Create_Date { get; set; }
    }
}
