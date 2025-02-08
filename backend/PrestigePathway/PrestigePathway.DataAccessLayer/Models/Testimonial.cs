using PrestigePathway.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.ModelsFolder
{
    public class Testimonial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; } // The client who provided the testimonial

        [Required]
        [StringLength(500)]
        public string? Content { get; set; } // The testimonial text

        [Required]
        public DateTime TestimonialDate { get; set; } = DateTime.UtcNow; 

        [Required]
        public bool IsApproved { get; set; } = false; 

        public int Rating { get; set; } 
        public Client Client { get; set; }
    }
}
