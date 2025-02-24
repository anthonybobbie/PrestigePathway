using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Abstractions.DTOAbstractions
{
    public interface IClientDTO
    {
        string Name { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
    }
}
