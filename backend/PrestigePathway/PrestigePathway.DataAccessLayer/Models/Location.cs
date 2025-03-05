using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Location : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
       // public ICollection<ServiceLocation> ServiceLocations { get; set; }
       public DateTime? ModifiedOnUtc { get; set; }
       public DateTime CreatedOnUtc { get; set; }
    }
}
