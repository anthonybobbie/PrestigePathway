using PrestigePathway.DataAccessLayer.Repositories;
namespace PrestigePathway.Data.Models.ServiceOption;

public class ServiceOptionResponse : IEntity
{
    public int ID { get; set; }
    public int ServiceTypeID { get; set; }
    public string OptionName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}