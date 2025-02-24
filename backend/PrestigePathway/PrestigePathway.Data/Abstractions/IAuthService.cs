using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PrestigePathway.Data.Models.Auth;
using PrestigePathway.Data.Utilities;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IAuthService 
    {
        Task<string> LoginAsync(string username, string password);
        Task<User> RegisterAsync(User user);
        Task ChangePasswordAsync(ChangePasswordRequest request);
    }
}