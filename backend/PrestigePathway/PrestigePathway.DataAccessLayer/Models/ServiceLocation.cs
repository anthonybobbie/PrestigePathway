using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class ServiceLocation : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public bool IsActive { get; set; } = true;

        public Service Service { get; set; }
        public Location Location { get; set; }
    }
}
