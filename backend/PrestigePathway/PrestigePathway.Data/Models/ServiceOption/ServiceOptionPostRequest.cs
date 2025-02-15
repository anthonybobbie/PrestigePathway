namespace PrestigePathway.Data.Models.ServiceOption;

public class ServiceOptionPostRequest
{
    public int ServiceTypeID { get; set; }
    public string OptionName { get; set; } 
    public string? Description { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}