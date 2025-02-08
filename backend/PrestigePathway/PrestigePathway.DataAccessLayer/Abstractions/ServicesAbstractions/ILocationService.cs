using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task AddLocationAsync(Location location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(int id);
    }
}