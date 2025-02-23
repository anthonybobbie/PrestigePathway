using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class UserRole : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
    public User? User { get; set; }
    public Role? Role { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}
public class UserPermission : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int PermissionID { get; set; }
    public User? User { get; set; }
    public Permission? Permission { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}
public class Permission : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string Name { get; set; } // eg Read:Booking
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}