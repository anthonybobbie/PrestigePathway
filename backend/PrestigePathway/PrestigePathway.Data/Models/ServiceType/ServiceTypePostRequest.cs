namespace PrestigePathway.Data.Models.ServiceType;

public class ServiceTypePostRequest
{
    public string TypeName { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}