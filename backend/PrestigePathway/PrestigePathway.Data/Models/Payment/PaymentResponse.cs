using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Payment
{
    public class PaymentResponse : IEntity
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string TransactionID { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
