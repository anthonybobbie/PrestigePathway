namespace PrestigePathway.Data.Models.Booking
{
    public class BookingPostRequest
    {
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
    }

}
