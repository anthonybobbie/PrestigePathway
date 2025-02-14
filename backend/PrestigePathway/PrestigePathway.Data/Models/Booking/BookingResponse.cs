using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Booking
{
    public class BookingResponse : IEntity
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
        //public ClientResponse Client { get; set; }
        //public ServiceResponse Service { get; set; }
        //public PaymentResponse Payment { get; set; }
        //public ICollection<StaffAssistantResponse> StaffAssistants { get; set; }
    }

}
