using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.ServiceType;

public class ServiceTypeResponse : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string TypeName { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}