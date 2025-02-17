using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.Data.Models.Location;
using PrestigePathway.Data.Models.Service;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.ServiceLocation
{
    public class ServiceLocationResponse : IEntity, IEntityTracker
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int LocationID { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
