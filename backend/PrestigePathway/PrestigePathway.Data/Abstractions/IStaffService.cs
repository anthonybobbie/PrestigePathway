using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.Data.Models.Staff;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IStaffService : IService<Staff, StaffResponse>
    {
        
    }
}