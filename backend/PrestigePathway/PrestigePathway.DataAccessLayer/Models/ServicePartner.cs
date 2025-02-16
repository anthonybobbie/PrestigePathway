using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class ServicePartner : IEntity
{
    public int ID { get; set; }
    public string PartnerName { get; set; }
    public int ServiceTypeID { get; set; }
    public int ServiceOptionID { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Address { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public ServiceType ServiceType { get; set; }
    public ServiceOption ServiceOption { get; set; }
    public ICollection<ServiceDetail> ServiceDetails { get; set; }
}