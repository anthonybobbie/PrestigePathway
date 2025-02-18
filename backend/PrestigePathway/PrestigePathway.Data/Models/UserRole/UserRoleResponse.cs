using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.UserRole;

public class UserRoleResponse : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}