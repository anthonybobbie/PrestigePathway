using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Common.Enums;
using System.ComponentModel;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Service : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        [Required]
        public ServiceCategory? Category { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [DisplayName("Duration Hours")]
        public int? DurationHours { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<ServiceLocation>? ServiceLocations { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
