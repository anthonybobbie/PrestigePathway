using PrestigePathway.DataAccessLayer.Repositories;
namespace PrestigePathway.Data.Models.ServiceDetail;

public class ServiceDetailResponse : IEntity
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
}