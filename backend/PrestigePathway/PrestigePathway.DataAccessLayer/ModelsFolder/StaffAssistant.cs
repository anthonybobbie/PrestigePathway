﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.DataAccessLayer.NewFolder
{
    public class StaffAssistant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffAssistantID { get; set; }

        [ForeignKey("Staff")]
        public int StaffID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        [Required]
        public DateTime AssignmentDate { get; set; } = DateTime.UtcNow;

        public string? Notes { get; set; }

        public Staff Staff { get; set; }
        public Booking Booking { get; set; }
    }
}
