using PrestigePathway.DataAccessLayer.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        public string? Description { get; set; }

        [Required]
        public ServiceCategory Category { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [DisplayName("Duration Hours")]
        public int? DurationHours { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<ServiceLocation> ServiceLocations { get; set; }
    }
}
