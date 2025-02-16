using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.Data.Models.Testimonial
{
    public class TestimonialPostRequest
    {
        public int ClientID { get; set; } // The client who provided the testimonial
        public string? Content { get; set; }
        public DateTime TestimonialDate { get; set; }
        public bool IsApproved { get; set; } = false; 
        public int Rating { get; set; } 
    }
}
