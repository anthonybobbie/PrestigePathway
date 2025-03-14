﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Testimonial : IEntity, IEntityTracker
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
        public Client? Client { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
