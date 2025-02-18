using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models;

public class Auth : IEntity, IEntityTracker
{
    public int ID { get; set; }
    public string Username { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public IEnumerable<UserRole>? UserRoles { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}