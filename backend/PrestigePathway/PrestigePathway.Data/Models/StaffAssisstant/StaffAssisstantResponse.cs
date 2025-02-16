using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.StaffAssisstant
{
    public class StaffAssisstantResponse : IEntity
    {
        public int ID { get; set; }
        public int StaffID { get; set; }
        public int BookingID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string? Notes { get; set; }
    }
}
