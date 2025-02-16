using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Testimonial
{
    public class TestimonialResponse : IEntity
    {
        public int ID { get; set; }
        public int ClientID { get; set; } // The client who provided the testimonial
        public string? Content { get; set; }
        public DateTime TestimonialDate { get; set; }
        public bool IsApproved { get; set; } = false; 
        public int Rating { get; set; } 
    }
}
