using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.Data.Models.Location;
using PrestigePathway.Data.Models.Service;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.ServiceLocation
{
    public class ServiceLocationResponse : IEntity
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int LocationID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
