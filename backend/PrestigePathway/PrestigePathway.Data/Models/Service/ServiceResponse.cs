﻿using PrestigePathway.DataAccessLayer.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PrestigePathway.Data.Models.ServiceLocation;

namespace PrestigePathway.Data.Models.Service
{
    public class ServiceResponse
    {
 
        public int ID { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int? DurationHours { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<ServiceLocationResponse> ServiceLocations { get; set; }
    }
}
