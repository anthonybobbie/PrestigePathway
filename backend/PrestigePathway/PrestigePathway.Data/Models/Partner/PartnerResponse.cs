﻿using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Partner
{
    public class PartnerResponse : IEntity, IEntityTracker
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string PartnerName { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
