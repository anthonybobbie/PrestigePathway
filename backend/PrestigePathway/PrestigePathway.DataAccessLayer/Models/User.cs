using PrestigePathway.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class User : IEntity, IEntityTracker
    {
        public int ID { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}