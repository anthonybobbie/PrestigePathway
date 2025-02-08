using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Common.Enums;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public string? Notes { get; set; }

        public Client Client { get; set; }
        public Service Service { get; set; }
        public Payment Payment { get; set; }
        public ICollection<StaffAssistant> StaffAssistants { get; set; }
    }
}
