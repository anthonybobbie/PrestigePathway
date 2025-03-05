using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class Role : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public ICollection<RolePermission>?  RolePermissions { get; set; }
}
