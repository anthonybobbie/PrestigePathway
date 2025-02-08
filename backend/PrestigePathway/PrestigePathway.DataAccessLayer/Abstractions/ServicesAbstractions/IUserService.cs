using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
        Task RegisterAsync(User user);
    }
}