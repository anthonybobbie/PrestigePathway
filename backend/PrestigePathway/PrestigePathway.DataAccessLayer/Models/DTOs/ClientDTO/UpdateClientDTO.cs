using PrestigePathway.DataAccessLayer.Abstractions.DTOAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Models.DTOs.ClientDTO
{
    public class UpdateClientDTO : IClientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
