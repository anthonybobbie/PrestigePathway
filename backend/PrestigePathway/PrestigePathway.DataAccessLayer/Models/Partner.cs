using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string PartnerName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Service> Services { get; set; }
    }
}
