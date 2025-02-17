using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.StaffAssisstant
{
    public class StaffAssisstantResponse : IEntity, IEntityTracker
    {
        public int ID { get; set; }
        public int StaffID { get; set; }
        public int BookingID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string? Notes { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
