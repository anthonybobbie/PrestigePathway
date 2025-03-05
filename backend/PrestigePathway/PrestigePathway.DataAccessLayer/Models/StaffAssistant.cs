using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class StaffAssistant : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Staff")]
        public int StaffID { get; set; }
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        [Required]
        public DateTime AssignmentDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
        public Staff? Staff { get; set; }
        [JsonIgnore]
        public Booking? Booking { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
