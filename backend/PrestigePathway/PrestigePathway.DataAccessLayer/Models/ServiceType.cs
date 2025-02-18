using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class ServiceType : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string TypeName { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public ICollection<ServiceOption>? ServiceOptions { get; set; }
    public ICollection<ServicePartner>? ServicePartners { get; set; }
    public ICollection<ServiceDetail>? ServiceDetails { get; set; }
}