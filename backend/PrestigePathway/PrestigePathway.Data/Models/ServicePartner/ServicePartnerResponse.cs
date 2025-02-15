using PrestigePathway.DataAccessLayer.Repositories;
namespace PrestigePathway.Data.Models.ServicePartner;

public class ServicePartnerResponse : IEntity
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
}