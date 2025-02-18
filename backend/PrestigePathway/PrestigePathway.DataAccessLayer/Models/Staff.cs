using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Common.Enums;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Staff : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        public StaffRole? Role { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<StaffAssistant>? StaffAssistants { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
