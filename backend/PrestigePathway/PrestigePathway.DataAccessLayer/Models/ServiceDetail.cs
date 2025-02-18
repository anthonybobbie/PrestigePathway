using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class ServiceDetail : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string ServiceName { get; set; }
    public string? Description { get; set; }
    public int ServicePartnerID { get; set; }
    public int ServiceTypeID { get; set; }
    public int ServiceOptionID { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public ServicePartner? ServicePartner { get; set; }
    public ServiceType? ServiceType { get; set; }
    public ServiceOption? ServiceOption { get; set; }
}