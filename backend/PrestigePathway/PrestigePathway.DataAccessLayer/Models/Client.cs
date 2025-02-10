using PrestigePathway.DataAccessLayer.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Client
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
    }
}
