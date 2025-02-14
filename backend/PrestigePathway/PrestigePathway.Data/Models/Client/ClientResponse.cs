using PrestigePathway.DataAccessLayer.Common.Enums;
using PrestigePathway.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrestigePathway.Data.Models.Client
{
    public class ClientResponse : IEntity
    {
         public int ID { get; set; }

         public string? FirstName { get; set; }
         public string? LastName { get; set; }

         public string? Email { get; set; }

         public string? PhoneNumber { get; set; }

         public string? Address { get; set; }

         public string ClientType { get; set; }

         public DateTime RegistrationDate { get; set; } 

         public string? Notes { get; set; }

    }

}
