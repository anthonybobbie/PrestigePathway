using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class ServiceOption : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public int ServiceTypeID { get; set; }
    public string OptionName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedOnUtc { get; set; } 
    public DateTime? ModifiedOnUtc { get; set; }
    public ServiceType? ServiceType { get; set; }
    public ICollection<ServicePartner>? ServicePartners { get; set; }
    public ICollection<ServiceDetail>? ServiceDetails { get; set; }
}