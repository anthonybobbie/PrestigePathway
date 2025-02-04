﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.NewFolder
{
    public class ServiceLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceLocationID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public bool IsActive { get; set; } = true;

        public Service Service { get; set; }
        public Location Location { get; set; }
    }
}
