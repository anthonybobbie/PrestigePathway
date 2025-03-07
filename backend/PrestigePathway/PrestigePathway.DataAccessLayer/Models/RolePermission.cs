using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class RolePermission : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public int RoleID { get; set; }
    public int PermissionID { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Role? Role { get; set; }
    public Permission? Permission { get; set; }
}