using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Common.Enums;
using System.Text.Json.Serialization;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Payment : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [StringLength(100)]
        public string TransactionID { get; set; }
        public string Status { get; set; } = "Pending";
        [JsonIgnore]
        public Booking Booking { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
