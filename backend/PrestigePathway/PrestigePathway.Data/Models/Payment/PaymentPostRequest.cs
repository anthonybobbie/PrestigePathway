namespace PrestigePathway.Data.Models.Payment
{
    public class PaymentPostRequest
    {
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string TransactionID { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
