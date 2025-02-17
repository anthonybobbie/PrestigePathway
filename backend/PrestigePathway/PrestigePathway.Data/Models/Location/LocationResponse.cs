using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Location
{
    public class LocationResponse : IEntity, IEntityTracker
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string LocationName { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
