using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrestigePathway.Data.Models.Location
{
    public class LocationResponse
    {
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
 
    }
}
