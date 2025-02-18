using PrestigePathway.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Promotion : IEntity, IEntityTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string PromotionName { get; set; } 
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountAmount { get; set; }
        [Required]
        public DateTime StartDate { get; set; } 
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsActive { get; set; } = true; 
        [ForeignKey("Service")]
        public int? ServiceID { get; set; } 
        public Service? Service { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
