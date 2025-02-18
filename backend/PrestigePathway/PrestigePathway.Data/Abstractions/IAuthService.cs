using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PrestigePathway.Data.Models.Auth;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IAuthService 
    {
        Task<string> LoginAsync(string username, string password);
        Task RegisterAsync(User user);
    }
}