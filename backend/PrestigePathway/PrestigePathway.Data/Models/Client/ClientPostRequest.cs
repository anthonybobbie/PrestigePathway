namespace PrestigePathway.Data.Models.Client
{
    public class ClientPostRequest
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
