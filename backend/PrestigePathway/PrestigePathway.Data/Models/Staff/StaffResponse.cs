using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Staff
{
    public class StaffResponse : IEntity
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
