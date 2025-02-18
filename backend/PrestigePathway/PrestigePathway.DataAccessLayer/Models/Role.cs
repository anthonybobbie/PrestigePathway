using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class Role : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ICollection<UserRole>? UserRoles { get; set; } = new List<UserRole>();
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}