using PrestigePathway.DataAccessLayer.Common.Enums;
using PrestigePathway.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.Data.Models.Client
{
    public class ClientResponse : IEntity, IEntityTracker
    {
         public int ID { get; set; }
         [Required]
         public string? FirstName { get; set; }
         [Required]
         public string? LastName { get; set; }
         [DataType(DataType.EmailAddress)]
         public string? Email { get; set; }
         [DataType(DataType.PhoneNumber)]
         public string? PhoneNumber { get; set; }
         public string? Address { get; set; }
         public string ClientType { get; set; }
         public DateTime RegistrationDate { get; set; } 
         public string? Notes { get; set; }

         public DateTime? ModifiedOnUtc { get; set; }
         public DateTime CreatedOnUtc { get; set; }
    }

}
