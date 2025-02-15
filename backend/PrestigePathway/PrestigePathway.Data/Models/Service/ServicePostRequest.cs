namespace PrestigePathway.Data.Models.Service
{
    public class ServicePostRequest
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? DurationHours { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
