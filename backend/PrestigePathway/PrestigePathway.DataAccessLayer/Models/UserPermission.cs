using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.DataAccessLayer.Models
{
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
}