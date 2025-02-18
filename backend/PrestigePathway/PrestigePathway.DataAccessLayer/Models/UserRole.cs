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