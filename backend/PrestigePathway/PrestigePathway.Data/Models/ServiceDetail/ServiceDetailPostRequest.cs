namespace PrestigePathway.Data.Models.ServiceDetail;

public class ServiceDetailPostRequest
{
    public string ServiceName { get; set; }
    public string? Description { get; set; }
    public int ServicePartnerID { get; set; }
    public int ServiceTypeID { get; set; }
    public int ServiceOptionID { get; set; }
    public decimal Price { get; set; }
}