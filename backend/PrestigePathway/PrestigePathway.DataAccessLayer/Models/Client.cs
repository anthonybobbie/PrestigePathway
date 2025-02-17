using PrestigePathway.DataAccessLayer.Common.Enums;
using PrestigePathway.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Client : IEntity, IEntityTracker
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
        [StringLength(200)]
        public string? Address { get; set; }
        [Required]
        public ClientType ClientType { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
